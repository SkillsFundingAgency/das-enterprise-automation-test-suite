using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class E2ESteps : EPAOBaseSteps
    {
        private string E2eOrgName => "YOUTH FORCE LIMITED";

        private string E2EOrgStandardName => "Software developer";

        private bool FinancialHealthAssessmentLinkExists;

        private string Username;

        public E2ESteps(ScenarioContext context) : base(context) { }

        [Given(@"the apply user submits an Assessment Service Application")]
        public void GivenTheApplyUserSubmitsAnAssessmentServiceApplication()
        {
            var searchForYourOrganisationPage = LoginInAsApplyUser();

            var _applicationOverviewPage = applyStepsHelper.CompletePreambleJourney(searchForYourOrganisationPage, E2eOrgName);

            _applicationOverviewPage = applyStepsHelper.CompleteOrganisationDetailsSection(_applicationOverviewPage);

            _applicationOverviewPage = applyStepsHelper.CompleteDeclarationsSection(_applicationOverviewPage);

            FinancialHealthAssessmentLinkExists = applyStepsHelper.GoToFinancialHealthAssessmentLinkExists(_applicationOverviewPage);

            if (FinancialHealthAssessmentLinkExists)
            {
                _applicationOverviewPage = applyStepsHelper.CompletesTheFHASection(_applicationOverviewPage);
            }

            applyStepsHelper.SubmitApplication(_applicationOverviewPage);
        }

        [Given(@"the admin appoves the assessor")]
        public void GivenTheAdminAppovesTheAssessor() => staffdashboardPage = adminStepshelper.ApproveAnOrganisation(ePAOHomePageHelper.LoginToEpaoAdminHomePage(true), FinancialHealthAssessmentLinkExists);

        [When(@"the apply user applies for a standard")]
        public void WhenTheApplyUserAppliesForAStandard()
        {
            var page = ePAOHomePageHelper.GoToEpaoApplyForAStandardPage();

            applyStepsHelper.ApplyForAStandard(page, E2EOrgStandardName);
        }

        [Then(@"the admin approves the standard")]
        public void ThenTheAdminApprovesTheStandard() => staffdashboardPage = adminStepshelper.ApproveAStandard(ePAOHomePageHelper.AlreadyLoginGoToEpaoAdminStaffDashboardPage());

        [Then(@"make the epao live")]
        public void ThenMakeTheEpaoLive() => adminStepshelper.MakeEPAOOrganisationLive(staffdashboardPage, ePAOAdminSqlDataHelper.GetEPAOId(Username));

        private AP_PR1_SearchForYourOrganisationPage LoginInAsApplyUser()
        {
            Username = ePAOE2EApplyUser.Username;

            ePAOApplySqlDataHelper.ResetApplyUserOrganisationId(Username);

            ePAOAdminSqlDataHelper.DeleteOrganisationStandardDeliveryArea(Username);

            ePAOAdminSqlDataHelper.DeleteOrganisationStanard(Username);

            ePAOAdminSqlDataHelper.DeleteEPAOOrganisation(Username);

            ePAOApplySqlDataHelper.ResetApplyUserEPAOId(Username);

            return ePAOHomePageHelper.LoginInAsApplyUser(ePAOE2EApplyUser);
        }

    }
}
