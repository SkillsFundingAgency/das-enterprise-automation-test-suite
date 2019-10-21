using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionYourApprenticeshipPage
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private YourApprenticeshipPage yourApprenticeshipPage;
        #endregion

        public StepDefinitionYourApprenticeshipPage(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaingnsProjectConfig<CampaignsConfig>();
            _objectContext = context.Get<ObjectContext>();
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