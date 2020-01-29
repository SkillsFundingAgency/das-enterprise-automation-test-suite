using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD8_TradingStatusPage : EPAO_BasePage
    {
        protected override string PageTitle => "What's your trading status?";
        private readonly ScenarioContext _context;

        public AP_OD8_TradingStatusPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD9_CompanyNumberPage SelectPubliLimitedCompanyOptionAndContinueInTradingStatusPage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "CD-16");
            Continue();
            return new AP_OD9_CompanyNumberPage(_context);
        }
    }
}
