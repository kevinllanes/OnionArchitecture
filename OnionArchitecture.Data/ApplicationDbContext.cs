using Microsoft.AspNet.Identity.EntityFramework;
using OnionArchitecture.Core.DomainModels;
using OnionArchitecture.Core.DomainModels.Common;
using OnionArchitecture.Core.Logging;
using OnionArchitecture.Data.Identity.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using OnionArchitecture.Data.EntityConfigurations;

namespace OnionArchitecture.Data
{
    public class ApplicationDbContext:  IdentityDbContext<
        ApplicationIdentityUser, 
        ApplicationIdentityRole, int, 
        ApplicationIdentityUserLogin, 
        ApplicationIdentityUserRole, 
        ApplicationIdentityUserClaim>, IEntitiesContext
    {
        public ILogger Logger { get; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }


        public ApplicationDbContext() :base("OnionArchitectureConnection")
        {
        }
        public ApplicationDbContext(string nameOrConnectionString,ILogger logger) :
            base(nameOrConnectionString)
        {
            Logger = logger;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);



            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new EnrollmentConfiguration());
            modelBuilder.Configurations.Add(new InstructorConfiguration());
            modelBuilder.Configurations.Add(new OfficeAssignmentConfiguration());
            modelBuilder.Configurations.Add(new PeopleConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());


            modelBuilder.Entity<ApplicationIdentityUser>()
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ApplicationIdentityRole>()
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ApplicationIdentityUserClaim>()
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

           
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public void SetAsAdded<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Added);
        }

        public void SetAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Modified);
        }

        public void SetAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Deleted);
        }

        private void UpdateEntityState<TEntity>(TEntity entity, EntityState entityState) where TEntity : BaseEntity
        {
            var dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = entityState;
        }

        private DbEntityEntry GetDbEntityEntrySafely<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var dbEntityEntry = Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Set<TEntity>().Attach(entity);
            }
            return dbEntityEntry;
        }


    }
}
