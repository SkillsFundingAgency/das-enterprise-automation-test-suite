using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class ReadyToDeliverTrainingAgainstForecastPage : AssessorBasePage
    {
        protected override string PageTitle => "Ready to deliver training against forecast";
        private readonly ScenarioContext _context;

        public ReadyToDeliverTrainingAgainstForecastPage(ScenarioContext context) : base(context) => _context = context;

        public RecruitNewStaffToDeliverTrainingAgainstForecastPage SelectPassAndContinueInReadyToDeliverTrainingAgainstForecastPage()
        {
            SelectPassAndContinueToSubSection();
            return new RecruitNewStaffToDeliverTrainingAgainstForecastPage(_context);
        }
    }
}