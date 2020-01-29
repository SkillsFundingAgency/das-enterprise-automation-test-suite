using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.DiscretionaryExclusionSubSection
{
    public class AP_DDE_9_DirectionAndSanctionsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Direction and sanctions";
        private readonly ScenarioContext _context;

        public AP_DDE_9_DirectionAndSanctionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DDE_10_RepaymentOfPublicMoneyPage SelectNoOptionAndContinueInDirectionAndSanctionsPage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "M_DEL-27_1");
            Continue();
            return new AP_DDE_10_RepaymentOfPublicMoneyPage(_context);
        }
    }
}
