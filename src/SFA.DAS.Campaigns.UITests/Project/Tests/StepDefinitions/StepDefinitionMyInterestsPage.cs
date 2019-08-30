using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionMyInterestsPage
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private MyInterestsPage myInterestsPage;
        private FindAnApprenticeShipViaMyInterestsPage findAnApprenticeShipViaMyInterestsPage;
        #endregion

        public StepDefinitionMyInterestsPage(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetProjectConfig<CampaignsConfig>();
            _objectContext = context.Get<ObjectContext>();
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