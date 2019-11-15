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
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        private EmployerMenuOptionPage employerMenuOptionPage;
        private EmployerFavouritePage employerFavouritePage ;
        #endregion
        public EmployerViewsTheFavouriteContnetSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaingnsProjectConfig<CampaignsConfig>();
        }


        [Given(@"I Click on the Favourite Icon")]
        public void GivenIClickOnTheFavouriteIcon()
        {
            employerFavouritePage= new EmployerFavouritePage(_context);
            employerFavouritePage.ClickOnClickingOnTheFavouriteIcon();
        }
        
        [Then(@"I Can Verify the Header for The Favourite Page")]
        public void ThenICanVerifyTheHeaderForTheFavouritePage()
        {
            employerFavouritePage= new EmployerFavouritePage(_context);
            employerFavouritePage.ClickOnClickingOnTheFavouriteIcon();
        }
    }
}
