using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OnionArchitecture.Core.DomainModels
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        

        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Instructor>Instructors { get; set; }

        public Course()
        {
            Enrollments=new Collection<Enrollment>();
            Instructors=new Collection<Instructor>();
        }
    }
}