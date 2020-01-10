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
        private EmployerFavouritePage employerFavouritePage ;
        #endregion

        public EmployerSaveFavouritesToGovUKAccountSteps(ScenarioContext context)
        {
            _context = context;
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
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
    }
}
