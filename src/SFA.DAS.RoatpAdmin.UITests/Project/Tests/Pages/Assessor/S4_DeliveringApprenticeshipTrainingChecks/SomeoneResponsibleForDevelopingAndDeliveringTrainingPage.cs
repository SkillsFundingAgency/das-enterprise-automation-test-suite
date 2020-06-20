using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class SomeoneResponsibleForDevelopingAndDeliveringTrainingPage : AssessorBasePage
    {
        protected override string PageTitle => "Someone responsible for developing and delivering training";
        private readonly ScenarioContext _context;

        public SomeoneResponsibleForDevelopingAndDeliveringTrainingPage(ScenarioContext context) : base(context) => _context = context;

        public WhoHasThisPersonHasWorkedWithToDevelopAndDeliverTrainingPage SelectPassAndContinueInSomeoneResponsibleForDevelopingAndDeliveringTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new WhoHasThisPersonHasWorkedWithToDevelopAndDeliverTrainingPage(_context);
        }
    }
}