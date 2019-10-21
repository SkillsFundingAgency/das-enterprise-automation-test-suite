using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionMyInterestsPage
    {
        #region Private Variables
        private readonly ScenarioContext _context;
        private readonly MyInterestsPage myInterestsPage;
        private FindAnApprenticeShipViaMyInterestsPage findAnApprenticeShipViaMyInterestsPage;
        #endregion

        public StepDefinitionMyInterestsPage(ScenarioContext context)
        {
            _context = context;
            myInterestsPage = new MyInterestsPage(_context);
        }

        [Then(@"I verify all the industry names on the My Interests page")]
        public void VerifySoYouHaveFoundTheApprenticeshipSection()
        {
            myInterestsPage.verifyContentUnderWhatIsAnApprenticeshipSection();
        }

        [When(@"I click on the industry name (.*)")]
        public void ClickOnTheRequiredIndustryName(string requiredIndustryName)
        {
            myInterestsPage.selectAnyRequiredIndustry(requiredIndustryName);
        }

        [When(@"I can enter a valid post code (.*)")]
        public void EnterPostcode(string postcode)
        {
            findAnApprenticeShipViaMyInterestsPage = new FindAnApprenticeShipViaMyInterestsPage(_context);
            findAnApprenticeShipViaMyInterestsPage.EnterPostCode(postcode);
        }

        [When(@"I can select miles as (.*)")]
        public void SelectMiles(string noOfMiles)
        {
            findAnApprenticeShipViaMyInterestsPage.SelectMiles(noOfMiles);
        }

        [When(@"I can click on search button")]
        public void ClickOnSearchButton()
        {
            findAnApprenticeShipViaMyInterestsPage.ClickOnSearchButton();
        }

    }
}