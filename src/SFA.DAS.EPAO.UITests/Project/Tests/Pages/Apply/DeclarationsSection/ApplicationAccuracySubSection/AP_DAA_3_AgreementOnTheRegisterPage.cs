using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.ApplicationAccuracySubSection
{
    public class AP_DAA_3_AgreementOnTheRegisterPage : EPAO_BasePage
    {
        protected override string PageTitle => "Agreement to appear on the register";
        private readonly ScenarioContext _context;

        public AP_DAA_3_AgreementOnTheRegisterPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DeclarationsBasePage SelectYesOptionAndContinueInAgreementOnTheRegisterPage()
        {
            SelectRadioOptionByForAttribute("A_DEL-30");
            Continue();
            return new AP_DeclarationsBasePage(_context);
        }
    }
}
