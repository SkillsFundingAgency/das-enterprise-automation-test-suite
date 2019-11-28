using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ManageSteps
    {
        private Manage_HomePage _manage_HomePage;
        private Manage_EnterBasicVacancyDetailsPage _manage_EnterBasicVacancyDetailsPage;
        private Manage_HelpdeskAdviserPage manage_HelpdeskAdviserPage;
        private Manage_SearchForACandidatePage manage_SearchForACandidatePage;
        private readonly ManageStepsHelper _manageStepsHelper;
        private readonly ObjectContext _objectContext;

        public ManageSteps(ScenarioContext context)
        {
            _manageStepsHelper = new ManageStepsHelper(context);
            _objectContext = context.Get<ObjectContext>();
        }

        [Given(@"the reviewer logged in to the manage application")]
        public void GivenTheReviewerLoggedInToTheManageApplication()
        {
            _manage_HomePage = _manageStepsHelper.GoToManageHomePage(false);
        }

        [Given(@"switches the role to helpdesk adviser")]
        public void GivenSwitchesTheRoleToHelpdeskAdviser()
        {
            manage_HelpdeskAdviserPage = _manage_HomePage.HelpdeskAdviser();
        }

        [Then(@"the reviewer is able to search and select a candidate")]
        public void ThenTheReviewerIsAbleToSearchAndSelectACandidate()
        {
            manage_SearchForACandidatePage = manage_HelpdeskAdviserPage.SearchForACandidate();
        }

        [Then(@"view the candidate's applications")]
        public void ThenViewTheCandidatesApplications()
        {
            manage_SearchForACandidatePage.Search().ViewApplications();
        }

        [Then(@"the Reviewer approves the vacancy")]
        public void ThenTheReviewerApprovesTheVacancy()
        {
            _manage_HomePage = _manageStepsHelper.GoToManageHomePage(true);

            _manage_HomePage.ApproveAVacancy();
        }

        [When(@"the Reviewer initiates reviewing the Vacancy in Manage")]
        public void WhenTheReviewerInitiatesReviewingTheVacancyInManage()
        {
            _manage_HomePage = _manageStepsHelper.GoToManageHomePage(true);
        }

        [Then(@"the Reviewer is able to approve the Vacancy '(.*)','(.*)'")]
        public void ThenTheReviewerIsAbleToApproveTheVacancy(string changeTeam, string changeRole)
        {
            _manage_HomePage.ApproveAVacancy(changeTeam, changeRole);
        }

        [When(@"the Reviewer refer a vacancy with comments '(.*)','(.*)'")]
        public void WhenTheReviewerReferAVacancyWithComments(string changeTeam, string changeRole)
        {
            _manage_EnterBasicVacancyDetailsPage = _manage_HomePage.EditOrCommentTitle(changeTeam, changeRole);

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
    }
}

