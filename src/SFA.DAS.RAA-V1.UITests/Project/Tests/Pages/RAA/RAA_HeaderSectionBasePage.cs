using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public abstract class RAA_HeaderSectionBasePage : RAAV1BasePage
    {
        private By SignOut => By.Id("signout-link");

        private By Home => By.CssSelector("#applicationsLink");

        private By Admin => By.CssSelector("#adminLink");

        public RAA_HeaderSectionBasePage(ScenarioContext context, bool navigate = false) : base(context, false)
        {
            if (navigate) { NavigateToHome(); }
            VerifyPage();
        }

        protected void NavigateToHome() => formCompletionHelper.Click(Home);

        protected void NavigateToAdmin() => formCompletionHelper.Click(Admin);

        public void ExitFromWebsite() => formCompletionHelper.Click(SignOut);
    }
}
