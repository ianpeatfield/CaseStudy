using System;
using CaseStudyIanPeatfield.Models;
using CaseStudyIanPeatfield.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaseStudyIanPeatfield.Tests
{
    [TestClass]
    public class DecisionServiceTest
    {
        [TestMethod]
        public void IfIsOneDayUnderEighteenReturnsOne()
        {
            var decisionService = new DecisionService();
            var dateOfBirth = DateTime.Now.AddYears(-18).AddDays(+1);
            var model = new ApplicationViewModel
            {
                AnnualIncome = "3000.00",
                DOB = dateOfBirth.Year +"-" + dateOfBirth.Month + "-" + dateOfBirth.Day,
                DOBDay = dateOfBirth.Day.ToString(),
                DOBMonth = dateOfBirth.Month.ToString(),
                DOBYear = dateOfBirth.Year.ToString(),
                FirstName = "Ian",
                LastName = "Peatfield"
            };

            var result = decisionService.GetApplicationResultId(model, dateOfBirth);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void IfIsEighteenTodayUnder3000ReturnsThree()
        {
            var decisionService = new DecisionService();
            var dateOfBirth = DateTime.Now.AddYears(-18);
            var model = new ApplicationViewModel
            {
                AnnualIncome = "3000.00",
                DOB = dateOfBirth.Year + "-" + dateOfBirth.Month + "-" + dateOfBirth.Day,
                DOBDay = dateOfBirth.Day.ToString(),
                DOBMonth = dateOfBirth.Month.ToString(),
                DOBYear = dateOfBirth.Year.ToString(),
                FirstName = "Ian",
                LastName = "Peatfield"
            };

            var result = decisionService.GetApplicationResultId(model, dateOfBirth);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void IfIsWellOverEighteenOver30000TodayReturnsTwo()
        {
            var decisionService = new DecisionService();
            var dateOfBirth = DateTime.Now.AddYears(-38);
            var model = new ApplicationViewModel
            {
                AnnualIncome = "40000.00",
                DOB = dateOfBirth.Year + "-" + dateOfBirth.Month + "-" + dateOfBirth.Day,
                DOBDay = dateOfBirth.Day.ToString(),
                DOBMonth = dateOfBirth.Month.ToString(),
                DOBYear = dateOfBirth.Year.ToString(),
                FirstName = "Ian",
                LastName = "Peatfield"
            };

            var result = decisionService.GetApplicationResultId(model, dateOfBirth);

            Assert.AreEqual(2, result);
        }
    }
}
