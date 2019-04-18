namespace CaseStudyIanPeatfield
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class ApplicationResult
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }

        [Display( Name = "Description")]
        public string ShortDescription { get; set; }        

        public ICollection<Application> Applications { get; set; }
    }

}
