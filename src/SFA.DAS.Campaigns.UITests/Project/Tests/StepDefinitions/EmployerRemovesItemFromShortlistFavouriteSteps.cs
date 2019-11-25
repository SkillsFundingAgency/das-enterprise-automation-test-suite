using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerRemovesItemFromShortlistFavouriteSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        private EmployerMenuOptionPage employerMenuOptionPage;
        private EmployerFavouritePage employerFavouritePage ;
        #endregion
        public EmployerRemovesItemFromShortlistFavouriteSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }

        [Then(@"I Can Remove an Apprenticeship from the Shortlist Favourite")]
        public void ThenICanRemoveAnApprenticeshipFromTheShortlistFavourite()
        {
            employerFavouritePage= new EmployerFavouritePage(_context);
            employerFavouritePage.RemoveAnApprenticeshipFromTheShortlist();
        }
    }
}
