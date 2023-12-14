namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;

public class CheckYourAnswersPage(ScenarioContext context) : AedBasePage(context)
{
    protected override string PageTitle => "Check your answers";

    private static By Confirm => By.CssSelector("#submit-demand");

    public EmailVerificationPage ConfirmYourAnswers()
    {
        formCompletionHelper.Click(Confirm);
        return new EmailVerificationPage(context);
    }
}
