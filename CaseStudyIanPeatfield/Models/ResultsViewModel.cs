using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseStudyIanPeatfield.Models
{
    public class ResultsViewModel
    {
        public IEnumerable<Application> Applications { get; set; }
        public Application Application { get; set; }
    }
}