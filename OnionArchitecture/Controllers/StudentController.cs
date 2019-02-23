using OnionArchitecture.Core.DomainModels;
using OnionArchitecture.Core.Services;
using OnionArchitecture.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnionArchitecture.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IService<Student> _service;


        public StudentController(IService<Student> service)
        {
            _service = service;
         }
        public ActionResult Index(string currentFilter,string searchString)
        {
            ViewBag.CurrentFilter = searchString;
            var studentList =  _service.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                studentList = (List<Student>) studentList
                    .Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())||
                          s.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(studentList);
        }

        public ActionResult Create()
        {
            var student = new Student {EnrollmentDate = DateTime.Now};
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentDto model)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    EnrollmentDate = model.EnrollmentDate
                };
                await _service.AddAsync(student);
                await _service.UnitOfWork.SaveChangesAsync();
            }
            else
            {
                ModelState.AddModelError("", @"Unable to create new student.");
                return View();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var student = _service.GetById(id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<ActionResult> Edit (Student model)
        {
            try
            {
                if (!ModelState.IsValid) return RedirectToAction("Index");

                await _service.UpdateAsync(model);
                await _service.UnitOfWork.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty,@"Unable to save changes. 
                Try again, and if the problem persists contact your system administrator.");
            }
            return View(model);
        }

        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage =
                    "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            var student = _service.GetById(id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var student = _service.GetById(id);
                await _service.DeleteAsync(student);
                await _service.UnitOfWork.SaveChangesAsync();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new {id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

       
    }
}