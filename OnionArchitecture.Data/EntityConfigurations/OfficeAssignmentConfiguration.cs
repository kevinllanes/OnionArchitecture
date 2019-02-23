using OnionArchitecture.Core.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnionArchitecture.Data.EntityConfigurations
{
    public class OfficeAssignmentConfiguration:EntityTypeConfiguration<OfficeAssignment>
    {
        public OfficeAssignmentConfiguration()
        {
            ToTable("OfficeAssignment");

            HasKey(of => of.Id);

            Property(of => of.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        }
    }
}
