using TechTalk.SpecFlow;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers.StubPages;
using SFA.DAS.Registration.UITests.Project.Helpers;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers.RATEmployerStepHelpers
{
    public class RATLoginHelper
    {
        private readonly ScenarioContext _context;
        private readonly RATTransitionLinkPage _rATTransitionLinkPage;        


        public RATLoginHelper(ScenarioContext context)
        {
            _context = context;
            _rATTransitionLinkPage = new RATTransitionLinkPage(context);        
        }

        public void RATTransitionLinkPage ()
        {
            _rATTransitionLinkPage.TransitionToRATFromFAT();        
        }

     
    }
}
