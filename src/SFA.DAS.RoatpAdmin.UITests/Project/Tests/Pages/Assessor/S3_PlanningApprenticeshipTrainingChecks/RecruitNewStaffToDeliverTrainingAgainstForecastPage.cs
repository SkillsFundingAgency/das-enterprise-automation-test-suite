using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class RecruitNewStaffToDeliverTrainingAgainstForecastPage : AssessorBasePage
    {
        protected override string PageTitle => "Recruit new staff to deliver training against forecast";
        private readonly ScenarioContext _context;

        public RecruitNewStaffToDeliverTrainingAgainstForecastPage(ScenarioContext context) : base(context) => _context = context;

        public TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage SelectPassAndContinueInRecruitNewStaffToDeliverTrainingAgainstForecastPage()
        {
            SelectPassAndContinueToSubSection();
            return new TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage(_context);
        }
    }
}