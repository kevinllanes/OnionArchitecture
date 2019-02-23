using OnionArchitecture.Core.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OnionArchitecture.Data.EntityConfigurations
{
    public class DepartmentConfiguration:EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            ToTable("Deparment");

            HasKey(d => d.Id);

            Property(d => d.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(d => d.Name)
                .HasMaxLength(50)
                .IsRequired();

            HasOptional(i => i.Administrator);

        }
    }
}
