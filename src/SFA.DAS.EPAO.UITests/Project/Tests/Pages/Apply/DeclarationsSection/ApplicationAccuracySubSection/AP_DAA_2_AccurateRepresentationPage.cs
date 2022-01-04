using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.ApplicationAccuracySubSection
{
    public class AP_DAA_2_AccurateRepresentationPage : EPAO_BasePage
    {
        protected override string PageTitle => "Accurate and true representation";
        
        public AP_DAA_2_AccurateRepresentationPage(ScenarioContext context) : base(context) => VerifyPage();

        public AP_DAA_3_AgreementOnTheRegisterPage SelectYesOptionAndContinueInAccurateRepresentationPage()
        {
            SelectRadioOptionByForAttribute("A_DEL-29");
            Continue();
            return new AP_DAA_3_AgreementOnTheRegisterPage(context);
        }
    }
}
