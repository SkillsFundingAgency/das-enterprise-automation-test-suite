namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.SignUp;

public class CheckYourAccountDetailsPage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-l");
    protected override string PageTitle => "Check your account details";

    private static By ConfirmYourAccount => By.CssSelector(".govuk-button");

    public FAASearchApprenticeLandingPage ClickCreateYourAccountConfirmation()
    {

        formCompletionHelper.Click(ConfirmYourAccount);

        return new(context);
    }
}
