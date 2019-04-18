namespace CaseStudyIanPeatfield
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Application
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        [Display(Name = "Annual Income")]
        public decimal AnnualIncome { get; set; }

        public int ApplicationResultId { get; set; }

        public ApplicationResult ApplicationResult { get; set; }
    }

}
