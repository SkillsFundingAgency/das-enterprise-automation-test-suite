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
    public class EmployerSelectsAnApprenticeshipFromTheSearchResultListSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        private EmployerMenuOptionPage employerMenuOptionPage;
        private ApprenticeshipSearchResultPage apprenticeshipSearchResultPage ;
        private SummeryOfThisApprenticeshipPage summeryOfThisApprenticeshipPage;
        private TrainingProviderResulPage trainingProviderResulPage;
        private RegisterMyInterestPage registerMyInterestPage;
        #endregion
        public EmployerSelectsAnApprenticeshipFromTheSearchResultListSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }
        [Then(@"I Can Select An Apprenticeship From Search Result  List")]
        public void ThenICanSelectAnApprenticeshipFromSearchResultList()
        {
           registerMyInterestPage = new RegisterMyInterestPage(_context);
           registerMyInterestPage.RemoveTheAlertBanner();
           apprenticeshipSearchResultPage = new ApprenticeshipSearchResultPage (_context);
           apprenticeshipSearchResultPage .SelectTheApprenticeshipFromSearchResult();

            summeryOfThisApprenticeshipPage = new SummeryOfThisApprenticeshipPage(_context);
            summeryOfThisApprenticeshipPage.VerifyTheSummargePage()
                    .EnterProviderPostCode()
                    .ClickProviderSearchButton()
                    .VerifyProviderResult();

        }
    }
}
