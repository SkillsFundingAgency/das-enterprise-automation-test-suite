namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class FinancialAssesmentPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "New assessments";

    public FinancialAssesmentPage(ScenarioContext context) : base(context) => VerifyPage();

    public FinancialHealthEvaluationPage GoToNewApplicationOverviewPage()
    {
        formCompletionHelper.ClickLinkByText(objectContext.GetApplyOrganisationName());
        return new FinancialHealthEvaluationPage(context);
    }

    public new StaffDashboardPage ReturnToDashboard() => base.ReturnToDashboard();
}