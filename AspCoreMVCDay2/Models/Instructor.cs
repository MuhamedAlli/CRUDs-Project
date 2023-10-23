using System.Collections;

namespace AspCoreMVCDay2.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public Course Course { get; set; }
        public Department Department { get; set; }

    }
}
