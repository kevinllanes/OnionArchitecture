using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OnionArchitecture.Core.DomainModels.Common;

namespace OnionArchitecture.Core.DomainModels
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }

        public decimal? Budget { get; set; }

        public DateTime StartDate { get; set; }

        public int? PersonId { get; set; }

        public Instructor Administrator { get; set; }

        public ICollection<Course>Courses { get; set; }

        public Department()
        {
            Courses=new Collection<Course>();
        }
    }
}
