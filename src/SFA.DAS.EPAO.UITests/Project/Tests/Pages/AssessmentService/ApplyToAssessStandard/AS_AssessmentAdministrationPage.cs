using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_AssessmentAdministrationPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Assessment administration";

        private readonly ScenarioContext _context;

        public AS_AssessmentAdministrationPage(ScenarioContext context) : base(context) => _context = context;
        
        public AS_AssessmentProductsAndToolsPage EnterAssessmentAdministration()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_AssessmentProductsAndToolsPage(_context);
        }
    }
}
