using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task2MVC.helpers
{
    public class HireDateValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                if(Convert.ToDateTime(value)>DateTime.Now)
                {
                    return new ValidationResult("Hire Date Should Not grater Than Today");
                }
                else
                {
                    return ValidationResult.Success;
                }
               
            }
            else
            {
                return new ValidationResult("Birth Date Is Required");
            }
        }
    }
}
