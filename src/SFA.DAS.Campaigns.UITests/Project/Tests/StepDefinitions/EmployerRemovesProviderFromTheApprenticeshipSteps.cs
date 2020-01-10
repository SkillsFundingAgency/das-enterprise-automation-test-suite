using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerRemovesProviderFromTheApprenticeshipSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private EmployerFavouritePage employerFavouritePage ;
        #endregion

        public EmployerRemovesProviderFromTheApprenticeshipSteps(ScenarioContext context)
        {
            _context = context;
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }
        [Then(@"I Can Remove Provider from the Shortlist Favourite")]
        public void ThenICanRemoveProviderFromTheShortlistFavourite()
        {
            employerFavouritePage= new EmployerFavouritePage(_context);
            employerFavouritePage.RemoveAProviderFromTheShortList();
        }
    }
}
