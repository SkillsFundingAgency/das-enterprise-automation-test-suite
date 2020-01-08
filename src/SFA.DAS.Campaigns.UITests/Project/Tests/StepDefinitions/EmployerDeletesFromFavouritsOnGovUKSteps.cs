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
    public class EmployerDeletesFromFavouritsOnGovUKSteps
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
        private YourSavedFavouritesGovUkPage yourSavedFavouritesGovUkPage;
        #endregion
        public EmployerDeletesFromFavouritsOnGovUKSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }

        [Then(@"I Can Delete From My Favourites on Gov UK Short List")]
        public void ThenICanDeleteFromMyFavouritesOnGovUKShortList()
        {
            yourSavedFavouritesGovUkPage = new YourSavedFavouritesGovUkPage(_context);
            yourSavedFavouritesGovUkPage.RemoveApprenticeshipAndProviderFromFavourites()
                .ConfirmRemovalOfApprenticeship();
        }
    }
}
