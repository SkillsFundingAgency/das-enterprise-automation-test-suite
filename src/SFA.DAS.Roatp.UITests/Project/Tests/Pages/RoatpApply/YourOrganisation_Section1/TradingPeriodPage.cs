using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class TradingPeriodPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How long has your organisation been actively trading?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By TradingRadioInputs => By.CssSelector(".govuk-radios__input");

        public TradingPeriodPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectMaximumTradingPeriodAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElements(TradingRadioInputs).LastOrDefault());
            Continue();
            return new ApplicationOverviewPage(_context);
        }

        public RailFranchiseOperatorPage SelectMinimumTradingPeriodAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElements(TradingRadioInputs).FirstOrDefault());
            Continue();
            return new RailFranchiseOperatorPage(_context);
        }
    }
}
