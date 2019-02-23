using OnionArchitecture.Core.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnionArchitecture.Data.EntityConfigurations
{
    public class InstructorConfiguration : EntityTypeConfiguration<Instructor>
    {
        public InstructorConfiguration()
        {

            HasKey(i => i.Id);

            Property(i => i.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(i => i.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(i => i.MiddleName)
                .IsRequired()
                .HasMaxLength(50);

            HasOptional(i => i.OfficeAssignment)
                .WithRequired(i => i.Instructor);
        }
    }
}
