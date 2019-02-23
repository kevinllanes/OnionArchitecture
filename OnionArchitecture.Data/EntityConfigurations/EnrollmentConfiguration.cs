using OnionArchitecture.Core.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnionArchitecture.Data.EntityConfigurations
{
    public class EnrollmentConfiguration:EntityTypeConfiguration<Enrollment>
    {
        public EnrollmentConfiguration()
        {
            ToTable("Enrollment");

            HasKey(e => e.EnrollmentId);

            Property(e => e.EnrollmentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();


        }
    }
}

