using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.ReadinessToEngageChecks
{
    public class OverallResponsibilityForManagingRelationshipsWithEmployersPage : AssessorBasePage
    {
        protected override string PageTitle => "Overall responsibility for managing relationships with employers";
        private readonly ScenarioContext _context;

        public OverallResponsibilityForManagingRelationshipsWithEmployersPage(ScenarioContext context) : base(context) => _context = context;

        public PromoteApprenticeshipsToEmployersPage SelectPassAndContinueInOverallResponsibilityForManagingRelationshipsWithEmployersPage()
        {
            SelectPassAndContinueToSubSection();
            return new PromoteApprenticeshipsToEmployersPage(_context);
        }
    }
}