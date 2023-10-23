using System.ComponentModel.DataAnnotations;

namespace AspCoreMVCDay2.Models
{
    public class MinDegreeValidAttribute:ValidationAttribute
    {
        ITIContext context;
        public MinDegreeValidAttribute(ITIContext _context) {
            context = _context;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            
            int minDeg =Convert.ToInt32(value);
            Course course = validationContext.ObjectInstance as Course;

            if (minDeg < course.Degree)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Min Degree Must be Less Than Degree Of Course!");
        }
    }
}
