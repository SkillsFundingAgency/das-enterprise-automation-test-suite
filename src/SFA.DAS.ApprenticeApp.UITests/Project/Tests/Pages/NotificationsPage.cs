using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class NotificationsPage(ScenarioContext context) : AppBasePage(context)
    {
        protected static By NotificationsHeader => By.CssSelector("h1.govuk-heading-xl");
        protected override string PageTitle => "Notifications";

        public string NotificationsPageTitle()
        {
            return pageInteractionHelper.FindElement(NotificationsHeader).Text;
        }


    }
}
