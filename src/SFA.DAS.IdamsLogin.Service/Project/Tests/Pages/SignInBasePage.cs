namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;

public abstract class SignInBasePage : IdamsLoginBasePage
{
    protected override By PageHeader => By.CssSelector(".pageTitle");

    protected override bool TakeFullScreenShot => false;

    protected override string PageTitle => "Sign in";

    #region Locators
    private static By UsernameField => By.Id("username");
    private static By PasswordField => By.Id("password");
    private static By SignInButton => By.XPath("//button[@value='Log in']");
    #endregion

    protected SignInBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

    public void SubmitValidLoginDetails(DfeAdminConfig dfeAdminConfig)
    {
        SubmitValidLoginDetails(dfeAdminConfig.AdminUserName, dfeAdminConfig.AdminPassword);
    }

    public void SubmitValidLoginDetails(string username, string password)
    {
        formCompletionHelper.EnterText(UsernameField, username);
        formCompletionHelper.EnterText(PasswordField, password);
        ClickSignInButton();
    }

    protected virtual void ClickSignInButton() => formCompletionHelper.ClickElement(SignInButton);
}
