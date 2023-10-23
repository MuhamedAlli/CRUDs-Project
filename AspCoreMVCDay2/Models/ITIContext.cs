using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AspCoreMVCDay2.Models
{
    public class ITIContext:IdentityDbContext
    {
        public ITIContext() : base()
        {

        }
        //inject ITIcontext => IOC Container
        public ITIContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-QFAQ5R9;Database=MVCdb;User Id=hotadm;Password=root;Integrated Security=true;Trusted_Connection=True;Encrypt=false;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
    }
}
