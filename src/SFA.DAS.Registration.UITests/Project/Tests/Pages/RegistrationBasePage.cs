using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public abstract class RegistrationBasePage : VerifyBasePage
    {
        #region Helpers and Context
        protected readonly RegistrationDataHelper registrationDataHelper;
        #endregion

        #region Locators
        private static By SignOutLink => By.LinkText("Sign out");
        #endregion

        protected RegistrationBasePage(ScenarioContext context) : base(context) => registrationDataHelper = context.Get<RegistrationDataHelper>();

        public HomePage GoToHomePage() => new(context, true);

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
