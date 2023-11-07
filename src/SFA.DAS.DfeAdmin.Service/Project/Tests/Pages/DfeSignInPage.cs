namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;

public class DfeSignInPage : SignInBasePage
{
    public static string DfePageTitle => "Department for Education Sign-in";

    public static By DfePageheader => By.CssSelector(".govuk-heading-xl");

    protected override By PageHeader => DfePageheader;

    protected override string PageTitle => DfePageTitle;

    private static By SignInButton => By.CssSelector("button.govuk-button[type='submit']");

    public DfeSignInPage(ScenarioContext context) : base(context) { }

    protected override void ClickSignInButton() => formCompletionHelper.ClickButtonByText(SignInButton, "Sign in");
}

public class CheckDfeSignInPage : CheckPageUsingShorterTimeOut
{
    protected override string PageTitle => DfeSignInPage.DfePageTitle;

    protected override By Identifier => DfeSignInPage.DfePageheader;

    public CheckDfeSignInPage(ScenarioContext context) : base(context) { }

    public override bool IsPageDisplayed() => checkPageInteractionHelper.WithoutImplicitWaits(() => pageInteractionHelper.VerifyPage(Identifier, PageTitle));
}