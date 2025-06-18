using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class ForecastingStartsPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Forecasting starts in the first 12 months of joining the APAR";

        public ReadyToDeliverTrainingAgainstForecastPage SelectPassAndContinueInForecastingStartsPage()
        {
            SelectPassAndContinueToSubSection();
            return new ReadyToDeliverTrainingAgainstForecastPage(context);
        }

        public ReadyToDeliverTrainingAgainstForecastPage SelectFailAndContinueInForecastingStartsPage()
        {
            SelectFailAndContinueToSubSection();
            return new ReadyToDeliverTrainingAgainstForecastPage(context);
        }
    }
}