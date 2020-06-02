using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_InvalidCredentialsSignInPage : RAAV1BasePage
    {
        protected override By PageHeader => By.Name("forms.loginForm");
        protected override string PageTitle => "Invalid user ID, email address or password";
        public RAA_InvalidCredentialsSignInPage(ScenarioContext context) : base(context) { }
    }
}
