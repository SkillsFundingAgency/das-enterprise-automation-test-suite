using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.ApplicationAccuracySubSection
{
    public class AP_DAA_2_AccurateRepresentationPage : EPAO_BasePage
    {
        protected override string PageTitle => "Accurate and true representation";
        private readonly ScenarioContext _context;

        public AP_DAA_2_AccurateRepresentationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DAA_3_AgreementOnTheRegisterPage SelectYesOptionAndContinueInAccurateRepresentationPage()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "A_DEL-29");
            Continue();
            return new AP_DAA_3_AgreementOnTheRegisterPage(_context);
        }
    }
}
