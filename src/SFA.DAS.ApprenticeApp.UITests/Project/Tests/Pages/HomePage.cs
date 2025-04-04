using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class HomePage(ScenarioContext context) : AppBasePage(context)
    {
        protected static By signInButtonLocator = By.CssSelector("button.app-button");
        protected override string PageTitle => "Your Apprenticeship";

        public StubSignInPage AppSignIn()
        {
            formCompletionHelper.Click(signInButtonLocator);
            return new StubSignInPage(context);
        }
    }
}
