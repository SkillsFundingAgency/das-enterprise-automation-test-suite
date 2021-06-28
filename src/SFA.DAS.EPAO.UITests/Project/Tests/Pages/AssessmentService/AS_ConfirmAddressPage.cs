using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ConfirmAddressPage : EPAO_BasePage
    {
        protected override string PageTitle => "Confirm the address where we are sending the certificate";
        private readonly ScenarioContext _context;

        public AS_ConfirmAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_RecipientNamePage ClickContinueInConfirmEmployerAddressPage()
        {
            Continue();
            return new AS_RecipientNamePage(_context);
        }
    }
}