using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class OffTheJobTrainingPage : AssessorBasePage
    {
        protected override string PageTitle => "Methods used to deliver 20% off the job training";

        public OffTheJobTrainingPage(ScenarioContext context) : base(context) { }

        public OffTheJobTrainingRelevantToApprenticeshipBeingDeliveredPage SelectPassAndContinueInOffTheJobTrainingPage()
        {
            SelectPassAndContinueToSubSection();
            return new OffTheJobTrainingRelevantToApprenticeshipBeingDeliveredPage(context);
        }
    }
}