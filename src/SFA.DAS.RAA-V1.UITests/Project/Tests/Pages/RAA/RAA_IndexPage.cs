using OpenQA.Selenium;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_IndexPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Recruit an apprentice";

        private By SignInButton => By.LinkText("Sign in");
        protected override By AcceptCookieButton => By.XPath("//button[contains(text(),'Accept all cookies')]");

        public RAA_IndexPage(ScenarioContext context) : base(context) { }

        public PreProdDIGBEADFSPage ClickOnSignInButton()
        {
            formCompletionHelper.Click(SignInButton);
            return new PreProdDIGBEADFSPage(context);
        }

        public new RAA_IndexPage AcceptCookies()
        {
            base.AcceptCookies();
            return this;
        }
    }
}
