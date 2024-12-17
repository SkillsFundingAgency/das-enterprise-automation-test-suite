using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Helpers
{
    public class AppLogin : Steps
    {
        protected static By PageHeader => By.CssSelector("svg.govuk-header__logotype");

        protected static By SignIn => By.CssSelector(".app-button[onclick*='/Account/Authenticated']");

        public AppLogin(ScenarioContext context)
        {
            
        }

        protected void Login()
        {
           
        }
    }
}
