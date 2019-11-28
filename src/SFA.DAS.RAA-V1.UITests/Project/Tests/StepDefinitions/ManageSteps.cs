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
            GoToManageHomePage(false);
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
            GoToManageHomePage(true);

            _manage_HomePage.ApproveAVacancy();
        }

        [When(@"the Reviewer refer a vacancy with comments")]
        public void WhenTheReviewerReferAVacancyWithComments()
        {
            GoToManageHomePage(true);

            _manage_EnterBasicVacancyDetailsPage = _manage_HomePage.EditOrCommentTitle();

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

        private void GoToManageHomePage(bool restart)
        {
            _manage_HomePage = _manageStepsHelper.GoToManageHomePage(restart);
        }
    }
}

