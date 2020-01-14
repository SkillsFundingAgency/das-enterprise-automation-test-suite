using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public abstract class AS_BasePage : BasePage
    {
        private readonly ScenarioContext _context;

        public AS_BasePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public AS_CheckAndSubmitAssessmentPage ClickBackLink()
        {
            NavigateBack();
            return new AS_CheckAndSubmitAssessmentPage(_context);
        }
    }
}
