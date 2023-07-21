using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;

public abstract class SignInBasePage : IdamsLoginBasePage
{
    protected override By PageHeader => By.CssSelector(".pageTitle");
    
    protected override bool TakeFullScreenShot => false;
    
    protected override string PageTitle => "Sign in";

    #region Locators
    protected By UsernameField => By.Id("username");
    protected By PasswordField => By.Id("password");
    protected By SignInButton => By.XPath("//button[@value='Log in']");
    #endregion

    protected SignInBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

    public void SubmitValidLoginDetails(string username, string password)
    {
        formCompletionHelper.EnterText(UsernameField, username);
        formCompletionHelper.EnterText(PasswordField, password);
        formCompletionHelper.ClickElement(SignInButton);
    }
}
