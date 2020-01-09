using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.Campaigns.UITests.Project;
using NUnit.Framework;

namespace SFA.DAS.Campaigns.UITests
{
    [Binding]
    public class EmployerLinkHOwMuchIsItGoingToCostSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        private EmployerMenuOptionPage employerMenuOptionPage;
        private HowMuchIsItGoingToCostPage howMuchIsItGoingToCostPage;
        #endregion

        public EmployerLinkHOwMuchIsItGoingToCostSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }

        [Given(@"I launch the How Much Is It Going To Cost\? page")]
        public void GivenILaunchTheHowMuchIsItGoingToCostPage()
        {
            fireItUpHomePage = new FireItUpHomePage(_context);
            fireItUpHomePage.FocusOnEmployerHowDoTheyWorkMenu();
            TestContext.Progress.WriteLine("Navigating to How Much Cost Is It Going to Cost page");
            fireItUpHomePage.ClickOnFundingAnApprenticeshipLink();
        }
        
        [Then(@"I verify the Title of How Much Is It Going To Cost\? the page")]
        public void ThenIVerifyTheTitleOfHowMuchIsItGoingToCostThePage()
        {
            howMuchIsItGoingToCostPage = new HowMuchIsItGoingToCostPage(_context);
            howMuchIsItGoingToCostPage.CheckThePageTitleForHowMuchIsItGoingToCost();
        }
    }
}
