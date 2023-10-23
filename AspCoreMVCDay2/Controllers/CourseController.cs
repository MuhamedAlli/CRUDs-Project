using AspCoreMVCDay2.Models;
using AspCoreMVCDay2.Repository;
using Microsoft.AspNetCore.Mvc;
namespace AspCoreMVCDay2.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository courseRepository;
        IInstructorRepository instructorRepository;
        IDepartmentRepository departmentRepository;
        public CourseController(IInstructorRepository _inst, ICourseRepository _crs , IDepartmentRepository _dept) {
            courseRepository = _crs;
            instructorRepository = _inst;  
            departmentRepository = _dept;
        }
        public IActionResult Index()
        {
            List<Course> courses = courseRepository.GetAll();
            return View(courses);
        }
        public IActionResult New()
        {
            ViewData["inst"] = instructorRepository.GetAll();
            ViewData["Depts"] = departmentRepository.GellAll();
            return View();
        }
        [HttpPost]
        public IActionResult New(Course course, int[] Id)
        {
            if(ModelState.IsValid) //Server Validation
            {
                courseRepository.Create(course,Id);
                return RedirectToAction("Index");
            }
            ViewData["inst"] = instructorRepository.GetAll();
            ViewData["Depts"] = departmentRepository.GellAll();
            return View(course);
        }
        public IActionResult Edit(int id)
        {
            ViewData["inst"] = instructorRepository.GetAll();
            ViewData["Depts"] = departmentRepository.GellAll();
            Course course = courseRepository.GetById(id);
            ViewData["CrsInst"] = courseRepository.GetInstructorsOfCourse(course);
            return View(course);
        }
        [HttpPost]
        public  IActionResult Edit(Course course, int[] Id)
        {
            if (ModelState.IsValid) //Server Validation
            {
             ViewData["CrsInst"] = courseRepository.GetInstructorsOfCourse(course);
             courseRepository.Update(course, Id);
                
             return RedirectToAction("Index");
            }
            List<Instructor> allInst= instructorRepository.GetAll();
            ViewData["inst"]=allInst;
            ViewData["Depts"] = departmentRepository.GellAll();
            return View(course);
        }

        public IActionResult getAllCoursesForDept(int id)
        {
            List<Course> courses = courseRepository.GetCoursesOfDepartment(id);

            return Json(courses);
        }
        public IActionResult IsCourseInDatabase(string Name)
        {
            Course crs = courseRepository.GetByName(Name);
            if(crs == null)
            {
                return Json(true);
            }
           return Json(false);
        }
    }
}
