using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.DeliveringApprenticeshipTrainingChecks
{
    public class WhoTheTeamWorkedWithPage : AssessorBasePage
    {
        protected override string PageTitle => "Who the team worked with to develop and deliver training";
        private readonly ScenarioContext _context;

        public WhoTheTeamWorkedWithPage(ScenarioContext context) : base(context) => _context = context;

        public HowTheTeamWorkedWithPage SelectPassAndContinueInWhoTheTeamWorkedWithPage()
        {
            SelectPassAndContinueToSubSection();
            return new HowTheTeamWorkedWithPage(_context);
        }
    }
}