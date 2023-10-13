namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;

public class DfeSignInPage : SignInBasePage
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

    protected override string PageTitle => "Department for Education Sign-in";

    private static By SignInButton => By.CssSelector("button.govuk-button[type='submit']");

    public DfeSignInPage(ScenarioContext context) : base(context) { }

    protected override void ClickSignInButton() => formCompletionHelper.ClickButtonByText(SignInButton, "Sign in");
}
