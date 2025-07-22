using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class YourProfilePage(ScenarioContext context) : AppBasePage(context)
    {
        protected static By YourProfileHeader => By.CssSelector("h1.app-page-header__heading");

        protected override string PageTitle => "Your profile";
        public string YourProfilePageTitle()
        {
            return pageInteractionHelper.FindElement(YourProfileHeader).Text;
        }
    }
}
