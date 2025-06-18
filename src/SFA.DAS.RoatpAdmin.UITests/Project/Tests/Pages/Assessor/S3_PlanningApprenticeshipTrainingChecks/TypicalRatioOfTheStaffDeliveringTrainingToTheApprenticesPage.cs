using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Typical ratio of the staff delivering training to the apprentices";

        public HowSupportIsAgreedBetweenEmployerApprenticePage SelectPassAndContinueInTypicalRatioOfStaffDeliveringTraining()
        {
            SelectPassAndContinueToSubSection();
            return new HowSupportIsAgreedBetweenEmployerApprenticePage(context);
        }
    }
}