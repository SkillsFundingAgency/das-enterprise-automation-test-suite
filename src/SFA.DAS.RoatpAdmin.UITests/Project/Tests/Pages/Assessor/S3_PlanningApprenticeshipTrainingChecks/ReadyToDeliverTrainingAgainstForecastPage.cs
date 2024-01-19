using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class ReadyToDeliverTrainingAgainstForecastPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Ready to deliver training against forecast";

        public RecruitNewStaffToDeliverTrainingAgainstForecastPage SelectPassAndContinueInReadyToDeliverTrainingAgainstForecastPage()
        {
            SelectPassAndContinueToSubSection();
            return new RecruitNewStaffToDeliverTrainingAgainstForecastPage(context);
        }
    }
}