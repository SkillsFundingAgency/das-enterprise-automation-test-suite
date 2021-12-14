using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_AssessmentProductsAndToolsPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Assessment products and tools";

        public AS_AssessmentProductsAndToolsPage(ScenarioContext context) : base(context) { }

        public AS_AssessmentContentPage EnterAssessmentProduct()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_AssessmentContentPage(context);
        }

    }
}
