
using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Project;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class DevHubSignInPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Sign in";
        protected override bool TakeFullScreenShot => false;

        private readonly By EmailAddress = By.CssSelector("#EmailAddress");
        private readonly By Password = By.CssSelector("#Password");
        private readonly By SigninButton = By.CssSelector("#button-signin");

        public DevHubSignInPage SignIn()
        {
            var providerConfig = context.GetProviderConfig<ProviderConfig>();

            formCompletionHelper.EnterText(EmailAddress, providerConfig.Username);
            formCompletionHelper.EnterText(Password, providerConfig.Password);
            formCompletionHelper.ClickElement(SigninButton);

            return this;
        }
    }
}
