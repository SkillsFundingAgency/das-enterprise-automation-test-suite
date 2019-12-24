using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ConfirmApprenticePage : BasePage
    {
        protected override string PageTitle => "Confirm this is the correct apprentice";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AS_ConfirmApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_DeclarationPage ClickConfirmInConfirmApprenticePage()
        {
            Continue();
            return new AS_DeclarationPage(_context);
        }
    }
}
