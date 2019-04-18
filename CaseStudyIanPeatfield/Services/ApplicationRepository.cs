using CaseStudyIanPeatfield.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseStudyIanPeatfield.Services
{
    public class ApplicationRepository : IApplicationRepository
    {
        public void Add(ApplicationViewModel applicationViewModel, DateTime dob, int applicationResultId)
        {
            decimal annualIncome = 0.0m;
            decimal.TryParse(applicationViewModel.AnnualIncome, out annualIncome);
            using (var db = new CaseStudyContext())
            {

                db.Applications.Add(
                    new Application
                    {
                        FirstName = applicationViewModel.FirstName,
                        LastName = applicationViewModel.LastName,
                        AnnualIncome = annualIncome,
                        DOB = dob,
                        ApplicationResultId = applicationResultId
                    }
                );

                db.SaveChanges();
            }
        }

        public IEnumerable<Application> GetAllApplications()
        {
            var applications = new List<Application>();

            using (var db = new CaseStudyContext())
            {

                applications = db.Applications.Include(nameof(Application.ApplicationResult)).ToList();

                
            }
            return applications;
        }
    }
}