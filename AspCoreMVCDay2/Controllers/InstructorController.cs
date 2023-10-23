using AspCoreMVCDay2.Models;
using AspCoreMVCDay2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreMVCDay2.Controllers
{
    public class InstructorController : Controller
    {
        ICourseRepository courseRepository;
        IInstructorRepository instructorRepository;
        IDepartmentRepository departmentRepository;
        public InstructorController(IInstructorRepository _inst, ICourseRepository _crs, IDepartmentRepository _dept)
        {
            courseRepository = _crs;
            instructorRepository = _inst;
            departmentRepository = _dept;
        }
        [Authorize]
        public IActionResult Index()
        {
            List<Instructor> instructors = instructorRepository.GetAll();
            return View(instructors);
        }
        public IActionResult Details(int id)
        {
            Instructor instructor = instructorRepository.GetById(id);
            return View(instructor);
        }

        
        public IActionResult NewInst()
        {
            List<Course> courses = courseRepository.GetAll();
            ViewData["courses"] = courses;
            List<Department> departments = departmentRepository.GellAll();
            ViewData["departs"] = departments;

            TempData["msg"] = "mohamed Ali";
            return View("NewInst");
        }
        [HttpPost]
        public async Task<IActionResult> AddNewInst(Instructor ins ,IFormFile formFile)
        {
            if (ins != null && ins.Name !=null && ins.Salary > 0 && ins.Address != null)
            {
                ins.Image= await instructorRepository.UploadImage(formFile); 
                instructorRepository.Create(ins);
                return RedirectToAction("Index");
            }
            List<Course> courses = courseRepository.GetAll();
            ViewData["courses"] = courses;
            List<Department> departments = departmentRepository.GellAll();
            ViewData["departs"] = departments;

            return View("NewInst", ins);
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<Course> courses = courseRepository.GetAll();
            List<Department> departments = departmentRepository.GellAll();
            Instructor? instructor = instructorRepository.GetById(id);
            ViewModelInstructorsWithCoursesAndDepartments vm = new ViewModelInstructorsWithCoursesAndDepartments()
            {
                Courses = courses,
                Departments = departments,
                instructor = instructor
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(int id, Instructor ins)
        {
            if (ins.Name != null)
            {
                instructorRepository.Update(id, ins);
                return RedirectToAction("Index");
            }
            List<Course> courses = courseRepository.GetAll();
            List<Department> departments = departmentRepository.GellAll();
            ViewModelInstructorsWithCoursesAndDepartments vm = new ViewModelInstructorsWithCoursesAndDepartments()
            {
                Courses = courses,
                Departments = departments,
                instructor = ins
            };
            return View(vm);
        }

        public IActionResult Delete(int id)
        {
            instructorRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
