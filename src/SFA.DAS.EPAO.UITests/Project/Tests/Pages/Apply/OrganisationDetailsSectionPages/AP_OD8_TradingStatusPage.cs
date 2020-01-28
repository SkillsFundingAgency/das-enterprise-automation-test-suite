using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD8_TradingStatusPage : EPAO_BasePage
    {
        protected override string PageTitle => "What's your trading status?";
        private readonly ScenarioContext _context;

        #region Locators
        private By YesRadioButton => By.Id("CD-16");
        #endregion

        public AP_OD8_TradingStatusPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD9_CompanyNumberPage SelectPubliLimitedCompanyOptionAndContinueInTradingStatusPage()
        {
            formCompletionHelper.SelectRadioButton(pageInteractionHelper.FindElement(YesRadioButton));
            Continue();
            return new AP_OD9_CompanyNumberPage(_context);
        }
    }
}
