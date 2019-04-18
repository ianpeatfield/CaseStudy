using System;
using CaseStudyIanPeatfield.Models;

namespace CaseStudyIanPeatfield.Services
{
    public interface IDecisionService
    {
        int GetApplicationResultId(ApplicationViewModel applicationViewModel, DateTime dob);
    }
}