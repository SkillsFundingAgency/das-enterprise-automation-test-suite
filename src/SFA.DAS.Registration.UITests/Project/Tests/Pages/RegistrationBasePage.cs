using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Registration.UITests.Project.Helpers;
using OpenQA.Selenium;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public abstract class RegistrationBasePage : VerifyBasePage
    {
        #region Helpers and Context
        protected readonly RegistrationConfig config;
        protected readonly RegistrationDataHelper registrationDataHelper;
        
        #endregion

        #region Locators
        private static By SignOutLink => By.LinkText("Sign out");
        #endregion

        protected RegistrationBasePage(ScenarioContext context) : base(context)
        {   
            config = context.GetRegistrationConfig<RegistrationConfig>();
            registrationDataHelper = context.Get<RegistrationDataHelper>();
        }

        public HomePage GoToHomePage() => new HomePage(context, true);

        public HomePage ClickBackLink()
        {
            NavigateBack();
            return new HomePage(context);
        }

        public YouveLoggedOutPage SignOut()
        {
            formCompletionHelper.Click(SignOutLink);
            return new YouveLoggedOutPage(context);
        }
    }
}
