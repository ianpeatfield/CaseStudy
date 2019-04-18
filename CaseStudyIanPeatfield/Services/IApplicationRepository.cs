using System;
using System.Collections.Generic;
using CaseStudyIanPeatfield.Models;

namespace CaseStudyIanPeatfield.Services
{
    public interface IApplicationRepository
    {
        void Add(ApplicationViewModel applicationViewModel, DateTime dob, int applicationResultId);
        IEnumerable<Application> GetAllApplications();
    }
}