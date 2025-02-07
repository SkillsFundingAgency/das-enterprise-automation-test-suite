

using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Project.Tests.Pages.DfeAdmin
{
    public class DfeAdminStartPage : AodpBasePage
    {
        public DfeAdminStartPage(ScenarioContext context) : base(context)
        {
            AcceptCookies();
        }

        private static By StartNowButton => By.LinkText("Start now");
        protected override By AcceptCookieButton => By.CssSelector(".das-cookie-banner__button-accept");

        public DfeAdminStartPage AodpStartPageToSignIn()
        {
            formCompletionHelper.ClickButtonByText(StartNowButton, "Start now");
            return new DfeAdminStartPage(context);
        }
    }
}
