using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionHomePage
    {
        #region Private Variables
        private readonly JsonConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        #endregion

        public StepDefinitionHomePage(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.Get<JsonConfig>();
            _objectContext = context.Get<ObjectContext>();
            //fireItUpHomePage = new FireItUpHomePage(_context);
        }

        [Given(@"I navigate to Fire It Up home page")]
        public void NavigateToGovUkHomePage()
        {
            var url = _configuration.BaseUrl;
            TestContext.Progress.WriteLine("Navigating to Fire It Up home page");
            _webDriver.Url = url;

            fireItUpHomePage = new FireItUpHomePage(_context);
            fireItUpHomePage.clickOnCookieContinueButton();
            fireItUpHomePage.verifyApprenticesHeaderSupportText();
            fireItUpHomePage.verifyEmployersHeaderSupportText();
        }

        [When(@"I launch the Find An Apprentice page")]
        public void launchFindAnApprenticePage()
        {
            fireItUpHomePage.launchApprenticeMenu();
            TestContext.Progress.WriteLine("Navigating to Find An Apprenticeship page");
            fireItUpHomePage.clickOnFindAnApprenticeLink();
        }

        [When(@"I launch the Your Apprenticeship page")]
        public void launchYourApprenticeshipPage()
        {
            fireItUpHomePage.launchApprenticeMenu();
            TestContext.Progress.WriteLine("Navigating to Your Apprenticeship page");
            fireItUpHomePage.clickOnYourApprenticeshipLink();
        }

        

    }
}