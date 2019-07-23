using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionApprenticeshipSummaryPage
    {
        #region Private Variables
        private readonly JsonConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private ApprenticeshipSummaryPage apprenticeshipSummaryPage;
        #endregion

        public StepDefinitionApprenticeshipSummaryPage(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.Get<JsonConfig>();
            _objectContext = context.Get<ObjectContext>();
        }

        [Then(@"I can see the Apprentice Summary page")]
        public void iCanSeeApprenticeshipSummaryPage()
        {
            apprenticeshipSummaryPage = new ApprenticeshipSummaryPage(_context);
            apprenticeshipSummaryPage.verifyApprenticeSummaryPageHeader();
            apprenticeshipSummaryPage.clickObSignInToApplyButton();
        }
    }
}