using AspCoreMVCDay2.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AspCoreMVCDay2.Repository
{
    public class CourseRepository:ICourseRepository
    {
        ITIContext context;
        public CourseRepository(ITIContext _context)
        {
            context = _context;
        }
        public List<Course> GetAll(){
            return context.Courses.Include("Department")
                .Include("Instructors")
                .Select(c => c).ToList();
        }
        public void Create(Course course, int[] Id)
        {
            List<Instructor> insts = new List<Instructor>();
            foreach (var i in Id)
            {
                Instructor instructor = context.Instructors.FirstOrDefault(ins => ins.Id == i);
                insts.Add(instructor);
            }
            course.Department = context.Departments.FirstOrDefault(d => d.DepartmentID == course.Department.DepartmentID);
            if (insts[0] != null)
                course.Instructors = insts;
            context.Courses.Add(course);
            context.SaveChanges();
        }
        public Course GetById(int id)
        {
            return context.Courses.Include("Department").Include("Instructors").FirstOrDefault(c => c.CourseID == id);
        }
        public void Update(Course course, int[] Id)
        {
            List<Instructor> insts = new List<Instructor>();
            foreach (var i in Id)
            {
               Instructor instructor = context.Instructors.FirstOrDefault(ins=>ins.Id==i);
               insts.Add(instructor);
            }
            Department department = context.Departments.FirstOrDefault(d => d.DepartmentID == course.Department.DepartmentID);
            Course crs = GetById(course.CourseID);
            crs.Department = department;
            //crs.Department = context.Departments.FirstOrDefault(d => d.DepartmentID == course.Department.DepartmentID);
            if (insts[0] != null)
                crs.Instructors = insts;
            crs.Name = course.Name;
            crs.Degree = course.Degree;
            crs.MinDegree = course.MinDegree;

            context.SaveChanges();
        }
        public List<Instructor> GetInstructorsOfCourse(Course course)
        {
            Course crs2 = context.Courses.Include("Department").Include("Instructors").FirstOrDefault(c => c.CourseID == course.CourseID);
            return crs2.Instructors.ToList();
        }
        public List<Course> GetCoursesOfDepartment(int id)
        {
            return context.Courses.Where(c => c.Department.DepartmentID == id).ToList();
        }

        public Course GetByName(string Name)
        {
            return context.Courses.FirstOrDefault(c => c.Name == Name);

        }
    }
}
