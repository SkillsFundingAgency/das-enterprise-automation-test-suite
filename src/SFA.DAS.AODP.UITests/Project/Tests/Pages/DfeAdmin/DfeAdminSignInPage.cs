

using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Project.Tests.Pages.DfeAdmin
{
    public class DfeAdminSignInPage : AodpBasePage
    {
        public DfeAdminSignInPage(ScenarioContext context) : base(context)
        {
            AcceptCookies();
        }

        private static By StartNowButton => By.LinkText("Start now");


    }
}
