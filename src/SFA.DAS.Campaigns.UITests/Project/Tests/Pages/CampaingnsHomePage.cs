using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class CampaingnsHomePage : CampaingnsHeaderBasePage
    {
        protected override string PageTitle => "APPRENTICES EMPLOYERS INFLUENCERS";

        protected override By PageHeader => By.CssSelector(".fiu-header");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CookieButton => By.Id("fiu-cb-button-accept");

        private By CloseCookieButton => By.Id("fiu-cb-close");


        public CampaingnsHomePage(ScenarioContext context) : base(context) => _context = context;
        
        public CampaingnsHomePage AcceptCookieAndAlert()
        {
            if (pageInteractionHelper.WaitUntilAnyElements(CookieButton))
            {
                formCompletionHelper.ClickElement(CookieButton);
                formCompletionHelper.ClickElement(CloseCookieButton);
            }
            return new CampaingnsHomePage(_context);
        }
    }
}
