using AspCoreMVCDay2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCoreMVCDay2.Controllers
{
    public class TraineeCourseController : Controller
    {

        ITIContext context;//= new ITIContext();
        public TraineeCourseController(ITIContext _context)
        {
            context = _context;
        }
        public IActionResult TraineeWithCourse()
        {

            List<ViewModelTraineeWithCourseWithDegree> list =
               context.CourseResults.Select(CR => 
               new ViewModelTraineeWithCourseWithDegree() { 
                   TraineeName=CR.Trainees.Name,  
                   CourseName= CR.Courses.Name,
                   Degree= CR.degree}
               ).ToList();

                //context.CourseResults.Include("Courses").Include("Trainees")
                //.Where(c=>c.Courses.ID==);
            return View("TraineeWithCourse", list);
        }
    }
}
