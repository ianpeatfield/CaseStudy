using System.Web.Mvc;
using CaseStudyIanPeatfield.Services;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace CaseStudyIanPeatfield
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IDecisionService, DecisionService>(); 
            container.RegisterType<IApplicationRepository, ApplicationRepository>();

            return container;
        }
    }
}