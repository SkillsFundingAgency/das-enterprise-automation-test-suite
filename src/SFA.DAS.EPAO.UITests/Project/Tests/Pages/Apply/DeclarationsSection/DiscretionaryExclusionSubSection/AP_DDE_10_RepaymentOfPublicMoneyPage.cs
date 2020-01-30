using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection
{
    public class AP_DDE_10_RepaymentOfPublicMoneyPage : EPAO_BasePage
    {
        protected override string PageTitle => "Repayment of public money";
        private readonly ScenarioContext _context;

        public AP_DDE_10_RepaymentOfPublicMoneyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DDE_11_PublicbodyFundsAndContractsPage SelectNoOptionAndContinueInRepaymentOfPublicMoneyPage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "A_DEL-28_1");
            Continue();
            return new AP_DDE_11_PublicbodyFundsAndContractsPage(_context);
        }
    }
}
