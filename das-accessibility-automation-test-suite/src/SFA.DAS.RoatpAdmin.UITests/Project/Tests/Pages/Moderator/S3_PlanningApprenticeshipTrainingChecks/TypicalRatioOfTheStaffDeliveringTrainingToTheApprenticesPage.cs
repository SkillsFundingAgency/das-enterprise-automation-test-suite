using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Typical ratio of the staff delivering training to the apprentices";

        public HowSupportIsAgreedBetweenEmployerApprenticePage SelectPassAndContinueInTypicalRatioOfStaffDeliveringTraining()
        {
            SelectPassAndContinueToSubSection();
            return new HowSupportIsAgreedBetweenEmployerApprenticePage(context);
        }
        public HowSupportIsAgreedBetweenEmployerApprenticePage SelectFailAndContinueInTypicalRatioOfStaffDeliveringTraining()
        {
            SelectFailAndContinueToSubSection();
            return new HowSupportIsAgreedBetweenEmployerApprenticePage(context);
        }
    }
}