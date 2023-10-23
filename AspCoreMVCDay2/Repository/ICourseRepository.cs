using AspCoreMVCDay2.Models;

namespace AspCoreMVCDay2.Repository
{
    public interface ICourseRepository
    {
         List<Course> GetAll();
         void Create(Course course, int[] Id);
         Course GetById(int id);
         void Update(Course course, int[] Id);
         List<Instructor> GetInstructorsOfCourse(Course course);
         List<Course> GetCoursesOfDepartment(int id);

         Course GetByName(string Name);
    }
}
