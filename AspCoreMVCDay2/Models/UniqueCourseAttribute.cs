using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AspCoreMVCDay2.Models
{
    public class UniqueCourseAttribute :ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            ITIContext context = new ITIContext();
            string name = value?.ToString();
            Course course = validationContext.ObjectInstance as Course;

            //check if Course is found in database
            Course crs = context.Courses.Include("Department").FirstOrDefault(c => c.Name == name && c.Department.DepartmentID == course.Department.DepartmentID);
            if (crs != null)
            {
                return new ValidationResult("this Course Already exists in this Deapartment!");

            }

            //check if Course is found in Depart

            //Course crs2 = course.Department.Courses.FirstOrDefault(c => c.Name == name);
            //Department crs2 = context.Departments.Include("Courses").Where(d => d.DepartmentID == course.Department.DepartmentID);
            //if (crs2 !=null)
            //{
            //    return new ValidationResult("this Course Already exists in this Department!");
            //}

            return ValidationResult.Success;


        }
    }
}
