using OnionArchitecture.Core.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnionArchitecture.Data.EntityConfigurations
{
    public class StudentConfiguration: EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {

            HasKey(s => s.Id);

            Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(s => s.MiddleName)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
