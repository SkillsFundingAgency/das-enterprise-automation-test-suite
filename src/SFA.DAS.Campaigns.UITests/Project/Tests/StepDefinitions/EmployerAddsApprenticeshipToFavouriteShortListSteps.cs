using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    [Binding]
    public class EmployerAddsApprenticeshipToFavouriteShortListSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private ApprenticeshipSearchResultPage apprenticeshipSearchResultPage;
        private TrainingProviderResulPage trainingProviderResulPage;
        RegisterMyInterestPage registerMyInterestPage;
        #endregion

        public EmployerAddsApprenticeshipToFavouriteShortListSteps(ScenarioContext context)
        {
            _context = context;
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }

        [Then(@"I Can Add Apprenticeships From Search Result  List to Favourite Short List")]
        public void ThenICanAddApprenticeshipFromSearchResultListToFavouriteShortList()
        {
            trainingProviderResulPage = new TrainingProviderResulPage(_context);
            trainingProviderResulPage.AddFavouriteShortList();
        }

        [Then(@"I Can Click on the Favourite Icon with Apprenticeship")]
        public void ThenICanClickOnTheFavouriteIconWithApprenticeship()
        {
            apprenticeshipSearchResultPage = new ApprenticeshipSearchResultPage(_context);
            apprenticeshipSearchResultPage.ClickOnTheFavouriteIconWithApprenticeship();
        }
    }
}
