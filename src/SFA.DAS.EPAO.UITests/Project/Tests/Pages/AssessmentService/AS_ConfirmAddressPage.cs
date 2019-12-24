using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ConfirmAddressPage : BasePage
    {
        protected override string PageTitle => "Confirm the address where we are sending the certificate";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

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
