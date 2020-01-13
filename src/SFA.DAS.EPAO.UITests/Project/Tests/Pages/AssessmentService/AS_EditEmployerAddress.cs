using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_EditEmployerAddress : BasePage
    {
        protected override string PageTitle => "Edit the employer's address";
        private readonly ScenarioContext _context;

        public AS_EditEmployerAddress(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_CheckAndSubmitAssessmentPage ClickBackLink()
        {
            NavigateBack();
            return new AS_CheckAndSubmitAssessmentPage(_context);
        }
    }
}
