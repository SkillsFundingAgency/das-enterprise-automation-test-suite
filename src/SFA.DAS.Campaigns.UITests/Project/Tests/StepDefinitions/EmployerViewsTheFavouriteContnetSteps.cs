using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerViewsTheFavouriteContnetSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private EmployerFavouritePage employerFavouritePage ;
        #endregion

        public EmployerViewsTheFavouriteContnetSteps(ScenarioContext context)
        {
            _context = context;
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }

        [Given(@"I Click on the Favourite Icon")]
        public void GivenIClickOnTheFavouriteIcon()
        {
            employerFavouritePage= new EmployerFavouritePage(_context);
            employerFavouritePage.ClickOnClickingOnTheFavouriteIcon();
        }
        
        [Then(@"I Can Verify the Favourite Header")]
        public void ThenICanVerifyTheHeaderForTheFavouritePage()
        {
            employerFavouritePage= new EmployerFavouritePage(_context);
            employerFavouritePage.VerifyFavouritePageHeader();
        }
        [Then(@"I can Verify that there are no Items in the list")]
        public void ThenICanVerifyThatThereAreNoItemsInTheList()
        {
            employerFavouritePage = new EmployerFavouritePage(_context);
            employerFavouritePage.VerifyThatNoItemsAreinTheBasket();
        }

        [Then(@"I Can Verify the Favourite Count")]
        public void ThenICanVerifyTheFavouriteCount()
        {
           employerFavouritePage= new EmployerFavouritePage(_context);
           employerFavouritePage.VerifyApprenticeshipFavouriteCount();
        }

        [Then(@"I Can Verify the Favourite Count for Provider")]
        public void ThenICanVerifyTheFavouriteCountForProvider()
        {
            employerFavouritePage= new EmployerFavouritePage(_context);
            employerFavouritePage.VerifyProviderFavouriteCount();
        }
    }
}
