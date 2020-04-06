using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard
{
    public class AS_EngagementWithTrailblazersAndEmployersPage : AS_EPAOApplyStandardBasePage
    {
        protected override string PageTitle => "Engagement with trailblazers and employers";

        private readonly ScenarioContext _context;

        public AS_EngagementWithTrailblazersAndEmployersPage(ScenarioContext context) : base(context) => _context = context;

        public AS_MembershipProfessionalPage EnterEngagement()
        {
            formCompletionHelper.EnterText(TextArea, standardDataHelper.GenerateRandomAlphanumericString(80));
            Continue();
            return new AS_MembershipProfessionalPage(_context);
        }
    }
}
