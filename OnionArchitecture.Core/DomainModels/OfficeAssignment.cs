using OnionArchitecture.Core.DomainModels.Common;

namespace OnionArchitecture.Core.DomainModels
{
    public class OfficeAssignment:BaseEntity
    {
        public int PersonId { get; set; }

        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}
