using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_DeclarationPage : BasePage
    {
        protected override string PageTitle => "Declaration";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AS_DeclarationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public void ClickConfirmInDeclarationPage() => Continue();
    }
}
