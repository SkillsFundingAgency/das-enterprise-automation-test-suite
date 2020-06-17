using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.DeliveringApprenticeshipTrainingChecks
{
    public class HowTheTeamWorkedWithPage : AssessorBasePage
    {
        protected override string PageTitle => "How the team worked with other organisations to develop and deliver training";
        private readonly ScenarioContext _context;

        public HowTheTeamWorkedWithPage(ScenarioContext context) : base(context) => _context = context;

        public OverallManagerForTheTeamPage SelectPassAndContinueInHowTheTeamWorkedWithPage()
        {
            SelectPassAndContinueToSubSection();
            return new OverallManagerForTheTeamPage(_context);
        }
    }
}