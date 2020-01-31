using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.MandatoryExclusionSubSection
{
    public class AP_DME_1_CriminalConvictionsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Criminal convictions";
        private readonly ScenarioContext _context;

        public AP_DME_1_CriminalConvictionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DME_2_FinancialConvictionsPage SelectNoOptionAndContinueInCriminalConvictionsPage()
        {
            SelectRadioOptionByForAttribute("M_DEL-09_1");
            Continue();
            return new AP_DME_2_FinancialConvictionsPage(_context);
        }
    }
}
