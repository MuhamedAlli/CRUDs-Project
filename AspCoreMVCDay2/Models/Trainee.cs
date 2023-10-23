namespace AspCoreMVCDay2.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }

        public int Grade { get; set; }

        public ICollection<CourseResult>? CourseResults { get; set; }
        public Department Department { get; set; }
    }
}
