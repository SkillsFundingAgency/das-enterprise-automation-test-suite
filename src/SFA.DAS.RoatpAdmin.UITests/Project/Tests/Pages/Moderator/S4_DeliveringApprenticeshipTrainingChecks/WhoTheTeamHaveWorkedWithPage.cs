using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class WhoTheTeamHaveWorkedWithPage : ModeratorBasePage
    {
        protected override string PageTitle => "Who the team have worked with to develop and deliver training";
        private readonly ScenarioContext _context;

        public WhoTheTeamHaveWorkedWithPage(ScenarioContext context) : base(context) => _context = context;

        public HowTheTeamWorkedWithPage SelectPassAndContinueInWhoTheTeamHaveWorkedWithPage()
        {
            SelectPassAndContinueToSubSection();
            return new HowTheTeamWorkedWithPage(_context);
        }
    }
}