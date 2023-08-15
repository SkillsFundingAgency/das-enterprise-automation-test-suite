using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AAN_EmployerSteps
    {
        private readonly ScenarioContext _context;

        public AAN_EmployerSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"an employer without onboarding logs into the AAN portal")]
        public void GivenAnEmployerWithoutOnboardingLogsIntoTheAANPortal()
        {
            _context.Get<TabHelper>().OpenInNewTab(UrlConfig.AAN_Emp_Baseurl);

            new StubSignInPage(_context).Login(_context.GetUser<AanEWOUser>()).Continue();

            _ = new EmployerAmbassadorApplicationPage(_context);
        }

    }
}
