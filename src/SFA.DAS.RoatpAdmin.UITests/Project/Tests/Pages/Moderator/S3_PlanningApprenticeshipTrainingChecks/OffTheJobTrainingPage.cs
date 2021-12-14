using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class OffTheJobTrainingPage : ModeratorBasePage
    {
        protected override string PageTitle => "Methods used to deliver 20% off the job training";
        
        public OffTheJobTrainingPage(ScenarioContext context) : base(context) { }

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