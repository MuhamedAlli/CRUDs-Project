using AspCoreMVCDay2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace AspCoreMVCDay2.Repository
{
    public class InstructorRepository:IInstructorRepository
    {
        ITIContext context;
        private readonly IWebHostEnvironment hostEnvironment;

        public InstructorRepository(ITIContext _context , IWebHostEnvironment _hostEnvironment) {
            context =_context;
            hostEnvironment = _hostEnvironment;
        }

        public  Instructor GetById(int id)
        {
          return context.Instructors.Include("Course")
                .Include("Department")
                .FirstOrDefault(i => i.Id == id);
           
        }
        public List<Instructor> GetAll()
        {
            return context.Instructors.ToList();
        }
        public void Create(Instructor instructor)
        {
            Department department = context.Departments.FirstOrDefault(d=>d.DepartmentID==instructor.Department.DepartmentID);
            Course course = context.Courses.FirstOrDefault(c => c.CourseID == instructor.Course.CourseID);
            instructor.Department = department;
            instructor.Course = course;
            context.Instructors.Add(instructor);
            context.SaveChanges();
        }
        public void Update(int id, Instructor ins)
        {
            Course? c = context.Courses.FirstOrDefault(c => c.CourseID == ins.Course.CourseID);
            Department? d = context.Departments.FirstOrDefault(d => d.DepartmentID == ins.Department.DepartmentID);
            Instructor? instructor = context.Instructors.FirstOrDefault(i => i.Id == id);
            instructor.Course = c;
            instructor.Department = d;
            instructor.Name = ins.Name;
            instructor.Address = ins.Address;
            instructor.Salary = ins.Salary;
            instructor.Image = ins.Image;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Instructor? instructor = context.Instructors.FirstOrDefault(i => i.Id == id);
            context.Instructors.Remove(instructor);
            context.SaveChanges();
        }

        public async Task<string> UploadImage(IFormFile formFile)
        {
            string wwwRootPath = hostEnvironment.WebRootPath;
            string fileName = Guid.NewGuid().ToString()+formFile.FileName;
            string filePath = Path.Combine(wwwRootPath, "Images", fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }
}
