using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public abstract class InterimProviderBasePage : Navigate
    {
        #region Helpers and Context
        protected readonly string ukprn;
        #endregion
        
        protected By NotificationSettingsLink => By.LinkText("Notification settings");
        private By SignOutLink => By.LinkText("Sign out");
        protected override By AcceptCookieButton => By.CssSelector(".das-cookie-banner__button-accept");

        public InterimProviderBasePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            ukprn = context.Get<ObjectContext>().GetUkprn();
            VerifyPage();
        }

        public void SignsOut() => formCompletionHelper.ClickElement(SignOutLink);
    }
}
