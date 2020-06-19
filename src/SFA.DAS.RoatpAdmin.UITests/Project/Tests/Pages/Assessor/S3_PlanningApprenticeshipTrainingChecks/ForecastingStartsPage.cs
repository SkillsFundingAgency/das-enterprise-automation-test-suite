using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class ForecastingStartsPage : AssessorBasePage
    {
        protected override string PageTitle => "Forecasting starts in the first 12 months of joining the RoATP";
        private readonly ScenarioContext _context;

        public ForecastingStartsPage(ScenarioContext context) : base(context) => _context = context;

        public ReadyToDeliverTrainingAgainstForecastPage SelectPassAndContinueInForecastingStartsPage()
        {
            SelectPassAndContinueToSubSection();
            return new ReadyToDeliverTrainingAgainstForecastPage(_context);
        }
    }
}