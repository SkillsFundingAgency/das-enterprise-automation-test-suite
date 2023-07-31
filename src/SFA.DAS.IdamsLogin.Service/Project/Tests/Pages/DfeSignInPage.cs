namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;

public class DfeSignInPage : SignInBasePage
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

    protected override By SignInButton => By.CssSelector("button.govuk-button[type='submit']");

    protected override string PageTitle => "Department for Education Sign-in";

    public DfeSignInPage(ScenarioContext context) : base(context) { }
}
