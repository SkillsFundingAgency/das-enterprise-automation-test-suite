using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ConfirmAddressPage : EPAO_BasePage
    {
        protected override string PageTitle => "Confirm the address where we are sending the certificate";
        
        public AS_ConfirmAddressPage(ScenarioContext context) : base(context) => VerifyPage();

        public AS_RecipientNamePage ClickContinueInConfirmEmployerAddressPage()
        {
            Continue();
            return new AS_RecipientNamePage(context);
        }
    }
}