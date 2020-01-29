using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.MandatoryExclusionSubSection
{
    public class AP_DDE_1_FinancialConvictionsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Financial convictions";
        private readonly ScenarioContext _context;

        public AP_DDE_1_FinancialConvictionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DME_3_CounterTerrorismPage SelectNoOptionAndContinueInFinancialConvictionsPage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "M_DEL-10_1");
            Continue();
            return new AP_DME_3_CounterTerrorismPage(_context);
        }
    }
}
