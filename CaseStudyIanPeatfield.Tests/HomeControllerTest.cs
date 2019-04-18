using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaseStudyIanPeatfield;
using CaseStudyIanPeatfield.Controllers;
using CaseStudyIanPeatfield.Services;
using CaseStudyIanPeatfield.Models;
using System.ComponentModel.DataAnnotations;

namespace CaseStudyIanPeatfield.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        public HomeControllerTest()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(new DecisionService(), new ApplicationRepository());

            // Act
            ViewResult result = controller.Application() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexReturnsNoErrorsForMissingName()
        {
            // Arrange
            HomeController controller = new HomeController(new DecisionService(), new ApplicationRepository());
            var model = new ApplicationViewModel
            {
                AnnualIncome = "3000.00",
                DOB = "2000-7-14",
                DOBDay = "14",
                DOBMonth="7",
                DOBYear = "2000",
                FirstName = "Ian",
                LastName ="Peatfield"
            };
            // Act
            var result = controller.Application(model);
            var redirectToRouteResult = result as RedirectToRouteResult;

            // Assert
            Assert.AreEqual(2, redirectToRouteResult.RouteValues.Count());
            Assert.AreEqual(3, (int)redirectToRouteResult.RouteValues.First().Value);
        }


        [TestMethod]
        public void ApplicationViewModelReturnsOneErrorForMissingFirstName()
        {
            // Arrange
            HomeController controller = new HomeController(new DecisionService(), new ApplicationRepository());
            var model = new ApplicationViewModel
            {
                AnnualIncome = "3000.00",
                DOB = "2000-7-14",
                DOBDay = "14",
                DOBMonth = "7",
                DOBYear = "2000",
                FirstName = "",
                LastName = "Peatfield"
            };

            controller.ModelState.Clear();
            controller.ValidateRequest = true; //.TryValidateModel(model);


            var results = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, results, true);

            // Assert
            Assert.AreEqual(1, results.Count(x=>x.ErrorMessage.Contains("First Name")));


        }



    }
}
