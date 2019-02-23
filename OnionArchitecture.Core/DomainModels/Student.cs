using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OnionArchitecture.Core.DomainModels
{
    public class Student:Person
    {
        public DateTime EnrollmentDate { get; set; }
        
        public  ICollection<Enrollment> Enrollments { get; set; }

        public Student()
        {
            Enrollments=new Collection<Enrollment>();
        }
    }
}
