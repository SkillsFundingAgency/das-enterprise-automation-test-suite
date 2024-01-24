using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class OffTheJobTrainingPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Methods used to deliver 20% off the job training";

        public OffTheJobTrainingRelevantToApprenticeshipBeingDeliveredPage SelectPassAndContinueInOffTheJobTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new OffTheJobTrainingRelevantToApprenticeshipBeingDeliveredPage(context);
        }

        public OffTheJobTrainingRelevantToApprenticeshipBeingDeliveredPage SelectFailAndContinueInOffTheJobTrainingPage()
        {
            SelectFailAndContinueToSubSection();
            return new OffTheJobTrainingRelevantToApprenticeshipBeingDeliveredPage(context);
        }
    }
}