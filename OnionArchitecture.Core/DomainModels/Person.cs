using OnionArchitecture.Core.DomainModels.Common;

namespace OnionArchitecture.Core.DomainModels
{
    public class Person:BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string FullName => LastName + ", " + MiddleName + ". " + FirstName;
    }
}
