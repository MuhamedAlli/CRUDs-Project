namespace AspCoreMVCDay2.Models
{
    public class ViewModelInstructorsWithCoursesAndDepartments
    {
        public List<Course> Courses { get; set; }
        public List<Department> Departments { get; set; }
        public Instructor instructor { get; set; }
    }
}
