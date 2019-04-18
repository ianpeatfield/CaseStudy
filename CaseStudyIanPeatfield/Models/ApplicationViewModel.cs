using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaseStudyIanPeatfield.Models
{
    public class ApplicationViewModel
    {


        [Required(ErrorMessage = "Your First Name is required.")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z\.\-\']*$",
            ErrorMessage = "First name may only contain letters, dashes (-), apostrophes ('), or spaces. Please remove all other characters.")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Your Last Name is required.")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z\.\-\']*$",
            ErrorMessage = "First name may only contain letters, dashes (-), apostrophes ('), or spaces. Please remove all other characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The day of your birthday is required.")]
        [RegularExpression(@"^[0-9]\d{0,9}", ErrorMessage = "This must be numbers only no decimal point or commas")]
        public string DOBDay { get; set; }

        [Required(ErrorMessage = "The month of your birthday is required.")]
        [RegularExpression(@"^[0-9]\d{0,9}", ErrorMessage = "This must be numbers only no decimal point or commas")]
        public string DOBMonth { get; set; }

        [Required(ErrorMessage = "The year of your birthday is required.")]
        [RegularExpression(@"^[0-9]\d{0,9}", ErrorMessage = "This must be numbers only no decimal point or commas")]
        public string DOBYear { get; set; }

        [DateValidator]        
        public string DOB { get; set; }

        [Required(ErrorMessage = "You annual income must be filled in.")]
        [RegularExpression(@"^[0-9]\d{0,9}(\.\d{1,2})?%?$", ErrorMessage = "This must be numbers only no decimal point or commas")]
        public string AnnualIncome { get; set; }

            

    }
}