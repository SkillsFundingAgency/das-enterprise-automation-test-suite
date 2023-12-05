namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions;

[Binding]
public class E2ESteps : EPAOBaseSteps
{
    private static string E2eOrgName => "TIRO TRAINING LTD";

    private static string E2EOrgStandardName => "Software developer";

    private bool FinancialHealthAssessmentLinkExists;

    private string Username;

    public E2ESteps(ScenarioContext context) : base(context) { }

    [Given(@"the apply user submits an Assessment Service Application")]
    public void GivenTheApplyUserSubmitsAnAssessmentServiceApplication()
    {
        var searchForYourOrganisationPage = LoginInAsApplyUser();

        var _applicationOverviewPage = applyStepsHelper.CompletePreambleJourney(searchForYourOrganisationPage, E2eOrgName);

        _applicationOverviewPage = ApplyStepsHelper.CompleteOrganisationDetailsSection(_applicationOverviewPage);

        _applicationOverviewPage = ApplyStepsHelper.CompleteDeclarationsSection(_applicationOverviewPage);

        FinancialHealthAssessmentLinkExists = ApplyStepsHelper.GoToFinancialHealthAssessmentLinkExists(_applicationOverviewPage);

        if (FinancialHealthAssessmentLinkExists)
        {
            _applicationOverviewPage = ApplyStepsHelper.CompletesTheFHASection(_applicationOverviewPage);
        }

        ApplyStepsHelper.SubmitApplication(_applicationOverviewPage);
    }

    [Given(@"the admin appoves the assessor")]
    public void GivenTheAdminAppovesTheAssessor() => staffDashboardPage = AdminStepshelper.ApproveAnOrganisation(ePAOHomePageHelper.LoginToEpaoAdminHomePage(true), FinancialHealthAssessmentLinkExists);

    [When(@"the apply user applies for a standard")]
    public void WhenTheApplyUserAppliesForAStandard()
    {
        var page = ePAOHomePageHelper.GoToEpaoApplyForAStandardPage();

        applyStepsHelper.ApplyForAStandard(page, E2EOrgStandardName);
    }

    [Then(@"the admin approves the standard")]
    public void ThenTheAdminApprovesTheStandard() => staffDashboardPage = AdminStepshelper.ApproveAStandard(ePAOHomePageHelper.LoginToEpaoAdminHomePage(true));

    [Then(@"make the epao live")]
    public void ThenMakeTheEpaoLive()
    {
        objectContext.SetOrganisationIdentifier(ePAOAdminSqlDataHelper.GetEPAOId(Username));

        AdminStepshelper.MakeEPAOOrganisationLive(staffDashboardPage);
    }

    private AP_PR1_SearchForYourOrganisationPage LoginInAsApplyUser()
    {
        Username = ePAOE2EApplyUser.Username;

        ePAOApplySqlDataHelper.ResetApplyUserOrganisationId(Username);

        ePAOAdminSqlDataHelper.DeleteOrganisationStandardDeliveryArea(Username);

        ePAOAdminSqlDataHelper.DeleteOrganisationStanard(Username);

        ePAOApplySqlDataHelper.DeleteAnyOtherOrganisationId(Username);

        ePAOAdminSqlDataHelper.DeleteEPAOOrganisation(Username);

        ePAOApplySqlDataHelper.ResetApplyUserEPAOId(Username);

        return ePAOHomePageHelper.LoginInAsApplyUser(ePAOE2EApplyUser);
    }

}
