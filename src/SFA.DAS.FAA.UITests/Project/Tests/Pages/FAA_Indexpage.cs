using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_Indexpage : FAABasePage
    {
        protected override string PageTitle => "Find an apprenticeship";
        private static By SignIn => By.CssSelector("a[href *= 'signin']");
        protected override By AcceptCookieButton => By.CssSelector("#btn-cookie-accept");

        public FAA_Indexpage(ScenarioContext context) : base(context) => AcceptCookies();

        public FAA_SignInPage GoToSignInPage()
        {
            formCompletionHelper.Click(SignIn);
            return new FAA_SignInPage(context);
        }

        private new FAA_Indexpage AcceptCookies()
        {
            base.AcceptCookies();
            return this;
        }
    }
}
