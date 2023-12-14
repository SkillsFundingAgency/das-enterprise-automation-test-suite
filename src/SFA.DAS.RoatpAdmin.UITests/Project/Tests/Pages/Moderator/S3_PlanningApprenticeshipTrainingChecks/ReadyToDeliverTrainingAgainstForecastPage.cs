using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class ReadyToDeliverTrainingAgainstForecastPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Ready to deliver training against forecast";

        public RecruitNewStaffToDeliverTrainingAgainstForecastPage SelectPassAndContinueInReadyToDeliverTrainingAgainstForecastPage()
        {
            SelectPassAndContinueToSubSection();
            return new RecruitNewStaffToDeliverTrainingAgainstForecastPage(context);
        }

        public RecruitNewStaffToDeliverTrainingAgainstForecastPage SelectFailAndContinueInReadyToDeliverTrainingAgainstForecastPage()
        {
            SelectFailAndContinueToSubSection();
            return new RecruitNewStaffToDeliverTrainingAgainstForecastPage(context);
        }
    }
}