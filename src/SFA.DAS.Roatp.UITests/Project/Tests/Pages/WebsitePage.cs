using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class WebsitePage : RoatpBasePage
    {
        protected override string PageTitle => "Does your organisation have a website?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By MainWebsiteField => By.Id("YO-41");

        public WebsitePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public TradingPeriodPage EneterWebsiteAndContinue()
        {
            SelectRadioOptionByForAttribute("YO-40");
            formCompletionHelper.EnterText(MainWebsiteField, applydataHelpers.Website);
            Continue();
            return new TradingPeriodPage(_context);
        }
    }
}
