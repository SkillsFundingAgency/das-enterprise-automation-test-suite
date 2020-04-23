using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_AssessmentContentPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Assessment content";

        private readonly ScenarioContext _context;

        public AS_AssessmentContentPage(ScenarioContext context) : base(context) => _context = context;

        public AS_ConfirmationOfAssessmentPage EnterAssessmentContent()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_ConfirmationOfAssessmentPage(_context);
        }

    }
}
