namespace AspCoreMVCDay2.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public int degree { get; set; }
        public Course Courses { get; set; }
        public Trainee Trainees { get; set; }
    }
}
