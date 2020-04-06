using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ManageSteps
    {
        private Manage_HomePage _manage_HomePage;
        private Manage_EnterBasicVacancyDetailsPage _manage_EnterBasicVacancyDetailsPage;
        private Manage_AdminFunctionsPage _manage_AdminFunctionsPage;
        private readonly ManageStepsHelper _manageStepsHelper;
        private readonly ObjectContext _objectContext;
        private readonly TabHelper _tabHelper;

        public ManageSteps(ScenarioContext context)
        {
            _manageStepsHelper = new ManageStepsHelper(context);
            _objectContext = context.Get<ObjectContext>();
            _tabHelper = context.Get<TabHelper>();
        }

        
        [Then(@"the reviewer is able to search and select a candidate")]
        public void ThenTheReviewerIsAbleToSearchAndSelectACandidate()  => _manageStepsHelper.SearchForACandidate();
        
        [Then(@"the Candidate is removed from the Manage")]
        public void ThenTheCandidateIsRemovedFromTheRecruit() => _manageStepsHelper.SearchForDeletedCandidate();

        [Then(@"the Candidate details is updated in Manage")]
        public void ThenTheCandidateDetailsIsUpdatedInManage() => _manageStepsHelper.VerifyUpdatedCandidateDetails();
        
        [Then(@"the Reviewer approves the vacancy")]
        public void ThenTheReviewerApprovesTheVacancy()
        {
            _manageStepsHelper.ApproveAVacancy(true);
        }

        [When(@"the Reviewer refer a vacancy with comments")]
        public void WhenTheReviewerReferAVacancyWithComments()
        {
            _manage_HomePage = _manageStepsHelper.GoToManageHomePage(true);

            _manage_EnterBasicVacancyDetailsPage = _manage_HomePage.ReviewAVacancy().EditOrCommentTitle();

            if (_objectContext.IsApprenticeshipVacancyType())
            {
                _manage_EnterBasicVacancyDetailsPage
                .AddApprenticeshipTitleComments()
                .ReferVacancy();
            }
            else
            {
                _manage_EnterBasicVacancyDetailsPage
                .AddTraineeshipTitleComments()
                .ReferVacancy();
            }
        }

        [When(@"a Reviewer is on the Admin functions page")]
        public void WhenAReviewerIsOnTheAdminFunctionsPage()
        {
            _manage_AdminFunctionsPage = _manageStepsHelper.GoToManageHomePage(false)
                .NavigateToAdminFuntionsPage();
        }

        [Then(@"Reviewer is able to select '(.*)' link and view the page")]
        public void ThenReviewerIsAbleToSelectLinkAndViewThePage(string adminLink)
        {
            switch (adminLink)
            {
                case "Manage Providers":
                    _manage_AdminFunctionsPage.ClickManageProvidersLink();
                    break;
                case "Manage Provider Sites":
                    _manage_AdminFunctionsPage.ClickManageProviderSitesLink();
                    break;
                case "Manage API Users":
                    _manage_AdminFunctionsPage.ClickManageApiUsersLink();
                    break;
                case "Manage Employers":
                    _manage_AdminFunctionsPage.ClickManageEmployersLink();
                    break;
                case "Sectors":
                    _manage_AdminFunctionsPage.ClickSectorsLink();
                    break;
                case "Standards":
                    _manage_AdminFunctionsPage.ClickStandardsLink();
                    break;
                case "Frameworks":
                    _manage_AdminFunctionsPage.ClickFrameworksLink();
                    break;
            }
            _tabHelper.NavigateBrowserBack();
        }
    }
}