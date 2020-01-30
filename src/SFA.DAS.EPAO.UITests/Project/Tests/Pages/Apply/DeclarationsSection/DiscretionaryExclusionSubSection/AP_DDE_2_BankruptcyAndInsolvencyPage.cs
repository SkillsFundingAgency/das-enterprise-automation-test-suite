using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection
{
    public class AP_DDE_2_BankruptcyAndInsolvencyPage : EPAO_BasePage
    {
        protected override string PageTitle => "Bankruptcy and insolvency";
        private readonly ScenarioContext _context;

        public AP_DDE_2_BankruptcyAndInsolvencyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DDE_3_CessationOfTradingPage SelectNoOptionAndContinueInBankruptcyAndInsolvencyPage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "D_DEL-14_1");
            Continue();
            return new AP_DDE_3_CessationOfTradingPage(_context);
        }
    }
}
