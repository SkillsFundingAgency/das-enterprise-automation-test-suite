using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_ManageAnyPotentialConflictPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "How will you manage any potential conflict of interest, particular to other functions your organisation may have?";

        private readonly ScenarioContext _context;

        public AS_ManageAnyPotentialConflictPage(ScenarioContext context) : base(context) => _context = context;

        public AS_WhereWillYouDeliverEndPointAssessmentsPage EnterManageAnyPotentialConflict()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_WhereWillYouDeliverEndPointAssessmentsPage(_context);
        }

    }
}
