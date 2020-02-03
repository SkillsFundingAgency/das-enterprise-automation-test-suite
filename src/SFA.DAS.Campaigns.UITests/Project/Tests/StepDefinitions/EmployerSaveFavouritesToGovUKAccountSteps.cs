using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
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
        private EmployerFavouritePage employerFavouritePage;
        private readonly TabHelper _tabHelper;
        #endregion

        public EmployerSaveFavouritesToGovUKAccountSteps(ScenarioContext context)
        {
            _context = context;
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
            _tabHelper = context.Get<TabHelper>();
        }

        [Then(@"I Can Save the Short list Favourite to my Gov>UK Account button")]
        public void ThenICanSaveTheShortListFavouriteToMyGovUKAccountButton()
        {
           employerFavouritePage= new EmployerFavouritePage(_context);
           employerFavouritePage.ClickOnTheCreateAccountButton()
                .ClickonCreateAccountButton()
                .EmployerLogsIn()
                .ClickOnViewSavedFavouroitesLink()
                .VerifyYourSavedFavouritesHeader();
        }
        [Then(@"I can Switch to Basket  view using the url")]
        public void ThenICanSwitchToBasketViewUsingTheUrl()
        {
            _tabHelper.GoToUrl(_configuration.CA_BasketUrl);
            TestContext.Progress.WriteLine("Navigating to basket page");

        }

    }
}
