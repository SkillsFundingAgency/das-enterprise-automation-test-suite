using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage : AssessorBasePage
    {
        protected override string PageTitle => "Typical ratio of the staff delivering training to the apprentices";
        private readonly ScenarioContext _context;

        public TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage(ScenarioContext context) : base(context) => _context = context;

        public HowSupportIsAgreedBetweenEmployerApprenticePage SelectPassAndContinueInTypicalRatioOfStaffDeliveringTraining()
        {
            SelectPassAndContinueToSubSection();
            return new HowSupportIsAgreedBetweenEmployerApprenticePage(_context);
        }
    }
}