using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public abstract class InterimProviderBasePage : Navigate
    {
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        protected readonly ObjectContext objectContext;
        #endregion
        
        protected By NotificationSettingsLink => By.LinkText("Notification settings");

        private By SignOutLink => By.LinkText("Sign out");

        public InterimProviderBasePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            objectContext = context.Get<ObjectContext>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public void SignsOut()
        {
            _formCompletionHelper.ClickElement(SignOutLink);
        }
    }
}
