using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class WorkingWithSubcontractorsPage : ModeratorBasePage
    {
        protected override string PageTitle => "Using subcontractors in the first 12 months of joining the RoATP";
        private readonly ScenarioContext _context;

        public WorkingWithSubcontractorsPage(ScenarioContext context) : base(context) => _context = context;

        public DueDiligenceOnSubcontractorsPage SelectPassAndContinueInWorkingWithSubcontractorsPage()
        {
            SelectPassAndContinueToSubSection();
            return new DueDiligenceOnSubcontractorsPage(_context);
        }
    }
}