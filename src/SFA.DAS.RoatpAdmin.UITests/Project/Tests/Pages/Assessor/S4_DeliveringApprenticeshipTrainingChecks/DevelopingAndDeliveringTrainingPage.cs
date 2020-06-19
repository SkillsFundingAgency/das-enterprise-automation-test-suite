using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class DevelopingAndDeliveringTrainingPage : AssessorBasePage
    {
        protected override string PageTitle => "Team responsible for developing and delivering training";
        private readonly ScenarioContext _context;

        public DevelopingAndDeliveringTrainingPage(ScenarioContext context) : base(context) => _context = context;

        public WhoTheTeamWorkedWithPage SelectPassAndContinueInDevelopingAndDeliveringTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new WhoTheTeamWorkedWithPage(_context);
        }
    }
}