namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

// the below classes are added temp until the Epao assessor is deployed to PP

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

public class CheckEpaoDfeSignInPage : CheckPageUsingShorterTimeOut
{
    protected override string PageTitle => "Department for Education Sign-in";

    protected override By Identifier => By.CssSelector(".govuk-heading-xl");

    public CheckEpaoDfeSignInPage(ScenarioContext context) : base(context) { }

    public override bool IsPageDisplayed() => checkPageInteractionHelper.WithoutImplicitWaits(() => pageInteractionHelper.VerifyPage(Identifier, PageTitle));
}
