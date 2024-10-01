namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;

public abstract class SignInBasePage : IdamsLoginBasePage
{
    protected override By PageHeader => By.CssSelector(".pageTitle");

    protected override bool TakeFullScreenShot => false;

    protected override string PageTitle => "Sign in";
    protected override By ContinueButton => By.XPath("//button[contains(text(),'Next')]");

    #region Locators
    private static By UsernameField => By.Id("username");
    private static By PasswordField => By.Id("password");
    private static By SignInButton => By.XPath("//button[@value='Log in']");
    #endregion

    protected SignInBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

    public void SubmitValidLoginDetails(string username, string password)
    {
        formCompletionHelper.EnterText(UsernameField, username);
        if(!pageInteractionHelper.IsElementDisplayed(PasswordField))
            Continue();

        formCompletionHelper.EnterText(PasswordField, password);
        ClickSignInButton();
    }

    protected virtual void ClickSignInButton() => formCompletionHelper.ClickElement(SignInButton);
}
