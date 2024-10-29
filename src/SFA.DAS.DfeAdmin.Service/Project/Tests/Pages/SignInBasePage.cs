namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;

public abstract class SignInBasePage(ScenarioContext context) : IdamsLoginBasePage(context)
{
    private class EnterPasswordPage(ScenarioContext context) : IdamsLoginBasePage(context)
    {
        protected override string PageTitle => "Enter your password";

        private static By PasswordField => By.Id("password");

        public void SubmitValidPassword(string password)
        {
            formCompletionHelper.EnterText(PasswordField, password);
        }
    }

    protected override By PageHeader => By.CssSelector(".pageTitle");

    protected override bool TakeFullScreenShot => false;

    protected override string PageTitle => "Sign in"; 

    protected override By ContinueButton => By.XPath("//button[contains(text(),'Next')]");

    #region Locators
    private static By UsernameField => By.Id("username");
    
    private static By SignInButton => By.XPath("//button[@value='Log in']");

    #endregion

    public void SubmitValidLoginDetails(string username, string password)
    {
        formCompletionHelper.EnterText(UsernameField, username);

        Continue();

        new EnterPasswordPage(context).SubmitValidPassword(password);

        ClickSignInButton();
    }

    protected virtual void ClickSignInButton() => formCompletionHelper.ClickElement(SignInButton);
}
