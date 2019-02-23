using System.ComponentModel.DataAnnotations.Schema;
using OnionArchitecture.Core.DomainModels;
using System.Data.Entity.ModelConfiguration;

namespace OnionArchitecture.Data.EntityConfigurations
{
    public class CourseConfiguration:EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            ToTable("Course");

            Property(c => c.CourseId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            Property(c => c.Title)
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.Credits)
                .IsRequired();

            HasMany(c => c.Instructors)
                .WithMany(i => i.Courses)
                .Map(t => t
                    .MapLeftKey("CourseId")
                    .MapRightKey("InstructorId")
                    .ToTable("CourseInstructor"));

        }
    }
}
