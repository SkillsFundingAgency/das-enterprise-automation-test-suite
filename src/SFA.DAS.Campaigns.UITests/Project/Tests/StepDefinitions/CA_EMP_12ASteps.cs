using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CA_EMP_12ASteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private EmployerHubPage employerHubPage;
        private readonly ScenarioContext _context;
       
        public CA_EMP_12ASteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
        }
        [Given(@"the user navigates to Hire An Apprentice hub Page")]
        public void GivenTheUserNavigatesToHireAnApprenticeHubPage()
        {
            _stepsHelper.GoToFireItUpHomePage()
                .NavigateToEmployerHubPage();
        }

        [Given(@"Verify the content on Hire An Apprentice hub Page")]
        public void GivenVerifyTheContentOnHireAnApprenticeHubPage()
        {
            employerHubPage = new EmployerHubPage(_context);
            employerHubPage.VerifyHireAnApprenticeCard1()
                .VerifyHireAnApprenticeCard2()
                .VerifyHireAnApprenticeCard3()
                .VerifyHireAnApprenticeCard4()
                .VerifyHireAnApprenticeCard5()
                .VerifyHireAnApprenticeCard6()
                .VerifyHireAnApprenticeCard7()
                .VerifyHireAnApprenticeCard8()
                .VerifyHireAnApprenticeCard9()
                .VerifyHireAnApprenticeCard10();
        }
    }
}
