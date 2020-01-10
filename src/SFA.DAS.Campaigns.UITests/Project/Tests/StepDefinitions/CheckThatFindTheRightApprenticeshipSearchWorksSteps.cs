using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CheckThatFindTheRightApprenticeshipSearchWorksSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private FireItUpHomePage fireItUpHomePage;
        private EmployerMenuOptionPage employerMenuOptionPage;
        private AssessmentAndCertificationPage assessmentAndCertificationPage;
        private RegisterMyInterestPage  registerMyInterestPage;
        private FindTheRightApprenticeshipPage  findTheRightApprenticeshipPage ;
        private FindTheRightApprenticeshipResultPage findTheRightApprenticeshipResultPage;
        #endregion

        public CheckThatFindTheRightApprenticeshipSearchWorksSteps(ScenarioContext context)
        {
            _context = context;
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }

        [Given(@"I Launch Find The Right Apprenticeship page")]
        public void GivenILaunchFindTheRightApprenticeshipPage()
        {
            fireItUpHomePage = new FireItUpHomePage(_context);
           // fireItUpHomePage.LaunchEmployerMenu();
            TestContext.Progress.WriteLine("Navigating to Find the Right Apprenticeship page");
            fireItUpHomePage.ClickFindTheRightApprenticeshipPage();
        }
        
        [Then(@"I Verify the title for Find The Right Apprenticeship  page")]
        public void ThenIVerifyTheTitleForFindTheRightApprenticeshipPage()
        {
            findTheRightApprenticeshipPage = new FindTheRightApprenticeshipPage(_context);
                findTheRightApprenticeshipPage.CheckTheRightApprenticeshipPageHeader();
        }
        
        [Then(@"I Can Perform The Search on the Empty Field")]
        public void ThenICanPerformTheSearchOnTheEmptyField()
        {
           findTheRightApprenticeshipPage = new FindTheRightApprenticeshipPage(_context);
           findTheRightApprenticeshipPage.ClickOnTheFindTheRightApprenticeshipButton();
        }
        
        [Then(@"I Can Verify The Result Page")]
        public void ThenICanVerifyTheResultPage()
        {
            findTheRightApprenticeshipResultPage = new  FindTheRightApprenticeshipResultPage(_context);
            findTheRightApprenticeshipResultPage.CheckSearchResultPageHeader()
                .VerifyTheSearchResult();


        }
    }
}
