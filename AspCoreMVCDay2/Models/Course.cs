using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspCoreMVCDay2.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        [MinLength(3)]
        [MaxLength(25)]
        [StringLength(25)]
        //[UniqueCourse]
        [Remote(action: "IsCourseInDatabase", controller: "Course", ErrorMessage ="This Course is Already Exists!")]
        public string Name { get; set; }

        [DisplayName("Course Degree")]
        [Range(50,100)]
        public int Degree { get; set; }

        //[MinDegreeValid]
        [DisplayName("Min Degree")]
        public int MinDegree { get; set; }

        public virtual ICollection<Instructor>? Instructors { get; set; }
        public virtual ICollection<CourseResult>? CourseResults { get; set; }

        public virtual Department? Department { get; set; }
    }
}
