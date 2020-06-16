using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.ReadinessToEngageChecks
{
    public class ManagingRelationshipWithEmployersPage : AssessorBasePage
    {
        protected override string PageTitle => "Managing relationship with employers";
        private readonly ScenarioContext _context;

        public ManagingRelationshipWithEmployersPage(ScenarioContext context) : base(context) => _context = context;

        public OverallResponsibilityForManagingRelationshipsWithEmployersPage SelectPassAndContinueInManagingRelationshipWithEmployersPage()
        {
            SelectPassAndContinueToSubSection();
            return new OverallResponsibilityForManagingRelationshipsWithEmployersPage(_context);
        }
    }
}