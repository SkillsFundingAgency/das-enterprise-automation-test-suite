using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage : ModeratorBasePage
    {
        protected override string PageTitle => "Typical ratio of the staff delivering training to the apprentices";
        private readonly ScenarioContext _context;

        public TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage(ScenarioContext context) : base(context) => _context = context;

        public HowSupportIsAgreedBetweenEmployerApprenticePage SelectPassAndContinueInTypicalRatioOfStaffDeliveringTraining()
        {
            SelectPassAndContinueToSubSection();
            return new HowSupportIsAgreedBetweenEmployerApprenticePage(_context);
        }
        public HowSupportIsAgreedBetweenEmployerApprenticePage SelectFailAndContinueInTypicalRatioOfStaffDeliveringTraining()
        {
            SelectFailAndContinueToSubSection();
            return new HowSupportIsAgreedBetweenEmployerApprenticePage(_context);
        }
    }
}