using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMXRentACar.Models
{
    public class ValidateEndDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var request = (Request)validationContext.ObjectInstance;
            if (request.EndDate >= request.StartDate) return ValidationResult.Success;
            else return new ValidationResult("Završni datum ne može biti u prošlostiu odnosu na početni datum");
        }
    }
}