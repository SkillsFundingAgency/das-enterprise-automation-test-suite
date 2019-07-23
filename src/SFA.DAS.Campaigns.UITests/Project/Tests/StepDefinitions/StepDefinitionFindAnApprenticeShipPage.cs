using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionFindAnApprenticeShipPage
    {
        #region Private Variables
        private readonly JsonConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private FindAnApprenticeShipPage findAnApprenticeShipPage;
        #endregion

        public StepDefinitionFindAnApprenticeShipPage(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.Get<JsonConfig>();
            _objectContext = context.Get<ObjectContext>();
            findAnApprenticeShipPage = new FindAnApprenticeShipPage(_context);
        }

        [Then(@"I select a valid (.*)")]
        public void selectAValidOptionFromInterestDropdown(string interestValue)
        {
            //findAnApprenticeShipPage = new FindAnApprenticeShipPage(_context);
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
            //findAnApprenticeShipPage = new FindAnApprenticeShipPage(_context);
            findAnApprenticeShipPage.clickOnSearchButton();
            TestContext.Progress.WriteLine("Navigating to Serach Results page");
        }

        [Then(@"I enter an invalid (.*)")]
        public void enterAnInvalidPostcode(string postCode)
        {
            findAnApprenticeShipPage.enterPostCode(postCode);
        }

        [Then(@"I can verify the error message for invalid postcode")]
        public void verifyTheInvalidPostcodeMessage()
        {
            findAnApprenticeShipPage.verifyInvalidPostcodeMessage();
        }

        [Then(@"I can verify the error message for not selecting any interest")]
        public void verifyTheMessageForNotSelectingInterest()
        {
            findAnApprenticeShipPage.verifyTheMessageForNonSelectionOfInterest();
        }


        [Then(@"I verify the default value of miles dropdown")]
        public void verifyTheDefaultValueOfMilesDropDown()
        {
            findAnApprenticeShipPage.verifyDefaultValueFromMilesDropDown();
        }



    }
}