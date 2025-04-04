using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class AccountPage(ScenarioContext context) : AppBasePage(context)
    {
        protected override string PageTitle => "Your account";
        protected static By AccountHeader => By.CssSelector("h1.govuk-heading-xl");
        public string AccountPageTitle()
        {
            return pageInteractionHelper.FindElement(AccountHeader).Text;
        }
    }    
}
