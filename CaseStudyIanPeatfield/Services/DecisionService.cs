using CaseStudyIanPeatfield.Controllers;
using CaseStudyIanPeatfield.Enum;
using CaseStudyIanPeatfield.EnumAndConstants;
using CaseStudyIanPeatfield.Models;
using System;

namespace CaseStudyIanPeatfield.Services
{
    public class DecisionService : IDecisionService
    {
        public int GetApplicationResultId(ApplicationViewModel applicationViewModel, DateTime dob)
        {
            var yearsDiff = DateTime.Now.Year - dob.Year;
            if (yearsDiff < 18) return (int)ApplicationResultsEnum.UnderEighteen;
            if (yearsDiff == 18)
            {
                if (DateTime.Now.DayOfYear - dob.DayOfYear < 0)
                {
                    return (int)ApplicationResultsEnum.UnderEighteen;
                }
            }
    
            if (Convert.ToDecimal(applicationViewModel.AnnualIncome) >= Constants.Threshold)
            {
                return (int)ApplicationResultsEnum.OverEigthteenAndIncomeAboveThirtyThousand;
            }
            return (int)ApplicationResultsEnum.OverEighteenAndLessThanThirtyThousand;
        }

    }
}