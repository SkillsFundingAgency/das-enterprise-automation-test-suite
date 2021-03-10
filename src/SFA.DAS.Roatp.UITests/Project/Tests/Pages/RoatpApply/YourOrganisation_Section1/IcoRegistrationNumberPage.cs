using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class IcoRegistrationNumberPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What is your organisation's Information Commissioner's Office (ICO) registration number?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By IcoNumberField => By.Id("YO-30");

        public IcoRegistrationNumberPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WebsitePage EnterIcoRegistrationNumberAndContinue()
        {
            formCompletionHelper.EnterText(IcoNumberField, applydataHelpers.IocNumber);
            Continue();
            return new WebsitePage(_context);
        }

        public TradingPeriodPage EnterIcoRegistrationNumber_WebsiteAndContinue()
        {
            formCompletionHelper.EnterText(IcoNumberField, applydataHelpers.IocNumber);
            Continue();
            return new TradingPeriodPage(_context);
        }
        public WebsitePage ClickContinueForIcoRegistrationNumber()
        {
            Continue();
            return new WebsitePage(_context);
        }
    }
}
