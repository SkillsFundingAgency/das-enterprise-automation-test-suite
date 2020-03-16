using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public abstract class EPAOAssesment_BasePage : EPAO_BasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EPAOAssesment_BasePage(ScenarioContext context) : base(context)
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
