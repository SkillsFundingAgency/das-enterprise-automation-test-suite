namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class EvaluationSubmittedPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Evaluation submitted";

    public EvaluationSubmittedPage(ScenarioContext context) : base(context) => VerifyPage();

    public FinancialAssesmentPage ReturnToAccountHome()
    {
        formCompletionHelper.ClickLinkByText("Return to account home");
        return new FinancialAssesmentPage(context);
    }

}

