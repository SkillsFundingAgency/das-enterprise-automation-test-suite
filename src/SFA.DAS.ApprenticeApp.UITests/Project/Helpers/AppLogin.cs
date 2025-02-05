using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Helpers
{
    public class AppLogin(ScenarioContext context) : Steps
    {
        protected static By PageHeader => By.CssSelector("svg.govuk-header__logotype");

        protected static By SignIn => By.CssSelector(".app-button[onclick*='/Account/Authenticated']");

        private readonly AppLogin _appLogin = new AppLogin(context);

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            
        }

        [When("I login with valid credentials")]
        public void WhenILoginWithValidCredentials()
        {
            _appLogin.Login();
        }

        private void Login()
        {
            throw new NotImplementedException();
        }
    }
}
