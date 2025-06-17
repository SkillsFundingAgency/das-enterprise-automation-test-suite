using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class ForecastingStartsPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Forecasting starts in the first 12 months of joining the APAR";

        public ReadyToDeliverTrainingAgainstForecastPage SelectPassAndContinueInForecastingStartsPage()
        {
            SelectPassAndContinueToSubSection();
            return new ReadyToDeliverTrainingAgainstForecastPage(context);
        }
    }
}