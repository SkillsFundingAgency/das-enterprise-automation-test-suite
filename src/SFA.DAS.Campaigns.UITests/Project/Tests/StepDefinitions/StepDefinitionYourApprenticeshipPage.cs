using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionYourApprenticeshipPage
    {
        #region Private Variables
        private readonly ScenarioContext _context;
        private readonly YourApprenticeshipPage yourApprenticeshipPage;
        #endregion

        public StepDefinitionYourApprenticeshipPage(ScenarioContext context)
        {
            _context = context;
            yourApprenticeshipPage = new YourApprenticeshipPage(_context);
        }

        [Then(@"I verify the content under What to bring, and other useful info section")]
        public void VerifyContentUnderWhatToBringSection()
        {
            yourApprenticeshipPage.VerifyConetntUnderWhatToBringSection();
        }

        [Then(@"I verify the content under Meet your new team section")]
        public void VerifyContentUnderMeetYourNewTeamSection()
        {
            yourApprenticeshipPage.VerifyContentUnderMeetYourNewTeamSection();
        }

        [Then(@"I verify the content under What comes after my apprenticeship section")]
        public void VerifyContentUnderWhatComesAfterMyApprenticeshipSection()
        {
            yourApprenticeshipPage.VerifyContentUnderWhatComesAfterMyApprenticeshipSection();
        }

    }
}