using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public abstract class EPAOAssesment_BasePage : EPAO_BasePage
    {
        public EPAOAssesment_BasePage(ScenarioContext context) : base(context) { }

        public AS_CheckAndSubmitAssessmentPage ClickBackLink()
        {
            NavigateBack();
            return new AS_CheckAndSubmitAssessmentPage(_context);
        }
    }
}
