using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EISteps
    {
        private readonly ScenarioContext _context;

        public EISteps(ScenarioContext context) => _context = context;

        [When(@"the Employer Initiates EI Application journey for (Single|Multiple) entity account")]
        public void WhenTheEmployerInitiatesEIApplicationJourneyForSingleEntityAccount(string entities)
        {

        }

        [Then(@"No Eligible apprentices shutter page is displayed for selecting (Yes|No) option in Qualification page")]
        public void ThenNoEligibleApprenticesShutterPageIsDisplayedForSelectingYesOptionInQualificationPage(string selection)
        {

        }

        [When(@"the Employer navigates back on No Eligible apprentices shutter page")]
        public void WhenTheEmployerNavigatesBackOnNoEligibleApprenticesShutterPage()
        {

        }

        [Then(@"Approvals home page is displayed on clicking on Add apprentices link")]
        public void ThenApprovalsHomePageIsDisplayedOnClickingOnAddApprenticesLink()
        {

        }
    }
}
