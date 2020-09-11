using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class EngagingWithEmployersPage : ModeratorBasePage
    {
        protected override string PageTitle => "Engaging with employers to deliver apprenticeship training to employees";
        private readonly ScenarioContext _context;

        public EngagingWithEmployersPage(ScenarioContext context) : base(context) => _context = context;

        public ManagingRelationshipWithEmployersPage SelectPassAndContinueInEngagingWithEmployersPage()
        {
            SelectPassAndContinueToSubSection();
            return new ManagingRelationshipWithEmployersPage(_context);
        }
    }
}
