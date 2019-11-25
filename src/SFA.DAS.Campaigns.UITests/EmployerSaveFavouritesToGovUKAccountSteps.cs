using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    [Binding]
    public class EmployerSaveFavouritesToGovUKAccountSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        private EmployerMenuOptionPage employerMenuOptionPage;
        private EmployerFavouritePage employerFavouritePage ;
        private ManageApprenticeshipHomePage manageApprenticeshipHomePage;
        private ManageApprenticeshipLoginPage manageApprenticeshipLoginPage;
        #endregion
        public EmployerSaveFavouritesToGovUKAccountSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaingnsProjectConfig<CampaignsConfig>();
        }

        [Then(@"I Can Save the Short list Favourite to my Gov>UK Account button")]
        public void ThenICanSaveTheShortListFavouriteToMyGovUKAccountButton()
        {
           employerFavouritePage= new EmployerFavouritePage(_context);
           employerFavouritePage.ClickOnTheCreateAccountButton()
                    .ClickonCreateAccountButton();
            manageApprenticeshipLoginPage = new ManageApprenticeshipLoginPage(_context);
            manageApprenticeshipLoginPage.EmployerLogsIn();
        }
    }
}
