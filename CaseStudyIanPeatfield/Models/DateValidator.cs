using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CaseStudyIanPeatfield.Models;
using System.Web;

namespace CaseStudyIanPeatfield.Models
{
    public class DateValidator : ValidationAttribute
    {


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //The string will only be empty if day month and year have not been filled in. These fields have their own validators
            var model = (ApplicationViewModel)validationContext.ObjectInstance;
            int day = 0, month = 0, year = 0;
            
            if(!int.TryParse(model.DOBDay, out day)  || !int.TryParse(model.DOBMonth, out month)  || !int.TryParse(model.DOBYear, out year)) return ValidationResult.Success; //show other validators

            var dob = value.ToString();
            DateTime dateOfBirth;
            if (!DateTime.TryParse(dob, out dateOfBirth))
                return new ValidationResult("The date of birth you have entered is invalid, please try again.");
               

            return ValidationResult.Success;
        }

    }


}
