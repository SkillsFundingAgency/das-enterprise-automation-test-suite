using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Login.Service.Project.Tests.Pages;

public abstract class StubSignInBasePage : VerifyBasePage
{
    protected override bool TakeFullScreenShot => false;

    protected override bool CanAnalyzePage => false;

    #region Locators
    private static By IdInput => By.CssSelector(".govuk-input[id='Id']");
    private static By EmailInput => By.CssSelector(".govuk-input[id='Email']");
    private static By SignInButton => By.CssSelector(".govuk-button-group .govuk-button[type='submit']");
    #endregion

    public StubSignInBasePage(ScenarioContext context) : base(context) => VerifyPage();

    protected void EnterLoginDetailsAndClickSignIn(string email, string userref)
    {
        formCompletionHelper.EnterText(IdInput, userref);
        formCompletionHelper.EnterText(EmailInput, email);
        formCompletionHelper.ClickElement(SignInButton);
    }

}
