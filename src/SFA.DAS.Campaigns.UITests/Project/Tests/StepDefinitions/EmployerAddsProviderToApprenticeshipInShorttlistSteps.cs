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
    public class EmployerAddsProviderToApprenticeshipInShorttlistSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private EmployerFavouritePage employerFavouritePage;
        #endregion

        public EmployerAddsProviderToApprenticeshipInShorttlistSteps(ScenarioContext context)
        {
            _context = context;
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }

        [Then(@"I Can Add a Provider to an Apprenticeship in the Shortlist Favourite")]
        public void ThenICanAddAProviderToAnApprenticeshipInTheShortlistFavourite()
        {
            employerFavouritePage= new EmployerFavouritePage(_context);
            employerFavouritePage.AddAProviderToAnApprenticeship()
                .VerifyTheSummargePage()
                .EnterProviderPostCode()
                .ClickProviderSearchButton()
                .VerifyProviderResult()
                .AddProviderToFavouriteShortList();
        }
    }
}
