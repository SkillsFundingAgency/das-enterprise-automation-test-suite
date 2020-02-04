using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerAddsApprenticeshiptoFavouriteSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private ApprenticeshipSearchResultPage apprenticeshipSearchResultPage;
        private RegisterMyInterestPage registerMyInterestPage;
        #endregion

        public EmployerAddsApprenticeshiptoFavouriteSteps(ScenarioContext context)
        {
            _context = context;
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }

        [Then(@"I Can Add Apprenticeships From Search Result by Clicking On the Title")]
        public void ThenICanAddApprenticeshipsFromSearchResultByClickingOnTheTitle()
        {
            apprenticeshipSearchResultPage = new ApprenticeshipSearchResultPage(_context);
            apprenticeshipSearchResultPage.SelectTheApprenticeshipFromSearchResult()
                .EnterProviderPostCode()
                .ClickProviderSearchButton()
                .VerifyProviderResult()
                .ClickOnProviderTitleLink()
                .VerifyTrainingProviderNameFromTitle();

        }
    }
}
