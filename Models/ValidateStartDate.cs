using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMXRentACar.Models
{
    public class ValidateStartDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var request = (Request)validationContext.ObjectInstance;
            if (request.StartDate >= DateTime.Today) return ValidationResult.Success;
            else return new ValidationResult("Početni datum ne može biti u prošlosti");
        }

    }
}