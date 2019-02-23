using System;

namespace OnionArchitecture.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime EnrollmentDate { get; set; }

    }
}