using CaseStudyIanPeatfield.Models;
using CaseStudyIanPeatfield.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseStudyIanPeatfield.Controllers
{

    public class HomeController : Controller
    {
        private IDecisionService _decisionService;
        private IApplicationRepository _applicationRepository;

        public HomeController(IDecisionService decisionService, IApplicationRepository applicationRepository)
        {
            _decisionService = decisionService; // new DecisionService(); //
            _applicationRepository = applicationRepository;
        }
        public ActionResult Application()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Application(ApplicationViewModel applicationViewModel)
        {
            if (!this.ModelState.IsValid) return View(applicationViewModel);


            DateTime dob = DateTime.Parse(applicationViewModel.DOB);

            int applicationResultId = _decisionService.GetApplicationResultId(applicationViewModel, dob);
            _applicationRepository.Add(applicationViewModel, dob, applicationResultId);

            return RedirectToAction(nameof(HomeController.Result), new { applicationResultId });
        }

     

        public ActionResult Result(int applicationResultId)
        {
            if (applicationResultId < 0 || applicationResultId > 3) return RedirectToAction(nameof(HomeController.Error));
            
            return View(new ResultViewModel { ApplicationResultId = applicationResultId });
        }

        public ActionResult Results()
        {
            var model = new ResultsViewModel();
            model.Applications = _applicationRepository.GetAllApplications();

            return View(model);
        }

        public ActionResult Error()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
       
    }

}

/*
 * 
 * using (var db = new CaseStudyContext())
            {
                db.ApplicationResults.Add(new ApplicationResult { Id = 1, Message = "The applicant is under 18 the message ‘no credit cards are available’ was shown" });
                db.ApplicationResults.Add(new ApplicationResult { Id = 2, Message = "The applicant is over 18 and has an annual income over £30,000, they were shown a Barclaycard credit card" });
                db.ApplicationResults.Add(new ApplicationResult { Id = 3, Message = "Applicant £30,000 or less and was shown a Vanquis Card"});                

                db.SaveChanges();
            }

    */