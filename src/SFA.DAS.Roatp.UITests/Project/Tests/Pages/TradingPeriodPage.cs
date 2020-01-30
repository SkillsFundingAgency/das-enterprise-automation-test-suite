using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class TradingPeriodPage : RoatpBasePage
    {
        protected override string PageTitle => "How long has your organisation been trading for?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TradingPeriodPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectMaximumTradingPeriodAndContinue()
        {
            SelectRadioOptionByForAttribute("YO-50_3");
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
