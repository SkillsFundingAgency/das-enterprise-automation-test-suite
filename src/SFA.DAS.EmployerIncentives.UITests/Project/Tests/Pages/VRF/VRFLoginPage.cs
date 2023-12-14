using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFLoginPage(ScenarioContext context) : EIBasePage(context)
    {
        protected override string PageTitle => "Log In";

        #region Locators
        protected override By PageHeader => By.CssSelector("h1");
        private static By Username => By.CssSelector("input[name='username']");
        private static By Password => By.CssSelector("input[name='password']");
        private static By SignInButton => By.CssSelector("button.primary[type='submit']");

        #endregion

        public VRFHomePage SignIntoVRF()
        {
            formCompletionHelper.EnterText(Username, eIConfig.EI_DfeUatUsername);
            formCompletionHelper.EnterText(Password, eIConfig.EI_DfeUatPassword);
            formCompletionHelper.Click(SignInButton);
            return new VRFHomePage(context);
        }
    }
}
