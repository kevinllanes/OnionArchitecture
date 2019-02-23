using OnionArchitecture.Core.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnionArchitecture.Data.EntityConfigurations
{
    public class PeopleConfiguration:EntityTypeConfiguration<Person>
    {
        public PeopleConfiguration()
        {
            ToTable("Person");

            HasKey(p => p.Id);

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
          
            Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.MiddleName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
 
}
