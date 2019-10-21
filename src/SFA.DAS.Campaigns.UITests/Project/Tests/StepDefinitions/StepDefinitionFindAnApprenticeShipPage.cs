using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionFindAnApprenticeShipPage
    {
        #region Private Variables
        private readonly ScenarioContext _context;
        private readonly FindAnApprenticeShipPage findAnApprenticeShipPage;
        #endregion

        public StepDefinitionFindAnApprenticeShipPage(ScenarioContext context)
        {
            _context = context;
            findAnApprenticeShipPage = new FindAnApprenticeShipPage(_context);
        }

        [When(@"I select a valid (.*)")]
        public void SelectAValidOptionFromInterestDropdown(string interestValue)
        {
            findAnApprenticeShipPage.SelectAValidInterest(interestValue);
        }

        [When(@"I enter a valid (.*)")]
        public void EnterAValidPostcode(string postCode)
        {
            findAnApprenticeShipPage.EnterPostCode(postCode);
        }

        [When(@"I select miles (.*)")]
        public void SelectNoOfMilesFromMilesDropdown(string noOfMiles)
        {
            findAnApprenticeShipPage.SelectMiles(noOfMiles);
        }

        [When(@"I click on Serach button")]
        public void ClickOnSearchButton()
        {
            findAnApprenticeShipPage.ClickOnSearchButton();
            TestContext.Progress.WriteLine("Navigating to Serach Results page");
        }

        [When(@"I enter an invalid (.*)")]
        public void EnterAnInvalidPostcode(string postCode)
        {
            findAnApprenticeShipPage.EnterPostCode(postCode);
        }

        [Then(@"I can verify the error message for invalid postcode")]
        public void VerifyTheInvalidPostcodeMessage()
        {
            findAnApprenticeShipPage.VerifyInvalidPostcodeMessage();
        }

        [Then(@"I can verify the error message for not selecting any interest")]
        public void VerifyTheMessageForNotSelectingInterest()
        {
            findAnApprenticeShipPage.VerifyTheMessageForNonSelectionOfInterest();
        }


        [Then(@"I verify the default value of miles dropdown")]
        public void VerifyTheDefaultValueOfMilesDropDown()
        {
            findAnApprenticeShipPage.VerifyDefaultValueFromMilesDropDown();
        }
    }
}