using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class CampaingnsHomePage(ScenarioContext context) : CampaingnsHeaderBasePage(context)
    {
        protected override string PageTitle => "APPRENTICES EMPLOYERS INFLUENCERS";

        protected override By PageHeader => By.CssSelector(".fiu-header");

        private static By CookieButton => By.Id("fiu-cb-button-accept");

        private static By CloseCookieButton => By.Id("fiu-cb-close-accept");

        public CampaingnsHomePage AcceptCookieAndAlert()
        {
            if (pageInteractionHelper.WaitUntilAnyElements(CookieButton))
            {
                formCompletionHelper.ClickElement(CookieButton);
                formCompletionHelper.ClickElement(CloseCookieButton);
            }
            return new CampaingnsHomePage(context);
        }
    }
}
