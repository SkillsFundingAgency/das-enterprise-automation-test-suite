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
        private FindAnApprenticeShipPage findAnApprenticeShipPage;
        private YourResultsPage yourResultsPage;
        #endregion

        public StepDefinitionHomePage(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.Get<JsonConfig>();
            _objectContext = context.Get<ObjectContext>();
        }

        [Given(@"I navigate to Fire It Up home page")]
        public void NavigateToGovUkHomePage()
        {
            var url = _configuration.BaseUrl;
            TestContext.Progress.WriteLine("Navigating to Fire It Up home page");
            _webDriver.Url = url;

            fireItUpHomePage = new FireItUpHomePage(_context);
            fireItUpHomePage.clickOnCookieContinueButton();

        }

        [When(@"I launch the Find An Apprentice page")]
        public void launchFindAnApprenticePage()
        {
            fireItUpHomePage.launchApprenticeMenu();
            fireItUpHomePage.clickOnFindAnApprenticeLink();
        }


        [Then(@"I select a valid (.*)")]
        public void selectAValidOptionFromInterestDropdown(string interestValue)
        {
            findAnApprenticeShipPage = new FindAnApprenticeShipPage(_context);
            findAnApprenticeShipPage.selectAValidInterest(interestValue);
        }

        [Then(@"I enter a valid (.*)")]
        public void enterAValidPostcode(string postCode)
        {
            findAnApprenticeShipPage.enterPostCode(postCode);
        }

        [Then(@"I select miles (.*)")]
        public void selectNoOfMilesFromMilesDropdown(string noOfMiles)
        {
            findAnApprenticeShipPage.selectMiles(noOfMiles);
        }

        [Then(@"I click on Serach button")]
        public void clickOnSearchButton()
        {
            findAnApprenticeShipPage.clickOnSearchButton();
        }

        [When(@"I click on first search result")]
        public void clickOnFirstSearchResult()
        {
            yourResultsPage = new YourResultsPage(_context);
            yourResultsPage.clickOnFirstSearchResult();
            //yourResultsPage.enterPostCode();
        }



    }
}