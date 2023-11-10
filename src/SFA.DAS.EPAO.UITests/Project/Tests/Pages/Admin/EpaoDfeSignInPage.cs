namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class EpaoDfeSignInPage : EsfaSignInPage
{
    #region Helpers and Context
    private readonly EPAOAdminUser _user;
    #endregion

    protected override string PageTitle => "Department for Education Sign-in";

    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

    private static By SignInButton => By.CssSelector("button.govuk-button[type='submit']");

    public EpaoDfeSignInPage(ScenarioContext context) : base(context) => _user = context.GetUser<EPAOAdminUser>();

    public StaffDashboardPage SignInWithValidDetails()
    {
        SubmitValidLoginDetails(_user.Username, _user.Password);
        return new(context);
    }

    protected override void ClickSignInButton() => formCompletionHelper.ClickButtonByText(SignInButton, "Sign in");
}
