using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class ReadyToDeliverTrainingAgainstForecastPage : AssessorBasePage
    {
        protected override string PageTitle => "Ready to deliver training against forecast";
        
        public ReadyToDeliverTrainingAgainstForecastPage(ScenarioContext context) : base(context) { }

        public RecruitNewStaffToDeliverTrainingAgainstForecastPage SelectPassAndContinueInReadyToDeliverTrainingAgainstForecastPage()
        {
            SelectPassAndContinueToSubSection();
            return new RecruitNewStaffToDeliverTrainingAgainstForecastPage(_context);
        }
    }
}