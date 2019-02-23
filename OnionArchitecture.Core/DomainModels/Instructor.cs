using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OnionArchitecture.Core.DomainModels
{
    public class Instructor:Person
    {
        public DateTime HireDate { get; set; }

        public ICollection<Course>Courses { get; set; }

        public OfficeAssignment OfficeAssignment { get; set; }

        public Instructor()
        {
            Courses = new Collection<Course>();
        }

    }
}
