using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Tests.Pages
{
    public abstract class SignInBasePage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".pageTitle");
        protected override string PageTitle => "Sign in";
        private readonly FormCompletionHelper _formCompletionHelper;

        #region Locators
        protected By UsernameField => By.Id("username");
        protected By PasswordField => By.Id("password");
        protected By SignInButton => By.XPath("//button[@value='Log in']");
        #endregion

        protected SignInBasePage(ScenarioContext context) : base(context)
        {
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected void SubmitValidLoginDetails(string username, string password)
        {
            _formCompletionHelper.EnterText(UsernameField, username);
            _formCompletionHelper.EnterText(PasswordField, password);
            _formCompletionHelper.ClickElement(SignInButton);
        }
    }
}
