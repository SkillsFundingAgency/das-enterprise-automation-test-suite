using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class SomeoneResponsibleForDevelopingAndDeliveringTrainingPage : ModeratorBasePage
    {
        protected override string PageTitle => "Someone responsible for developing and delivering training";
        private readonly ScenarioContext _context;

        public SomeoneResponsibleForDevelopingAndDeliveringTrainingPage(ScenarioContext context) : base(context) => _context = context;

        public WhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage SelectPassAndContinueInSomeoneResponsibleForDevelopingAndDeliveringTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new WhoThePersonHasWorkedWithToDevelopAndDeliverTrainingPage(_context);
        }
    }
}