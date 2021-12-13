using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class RecruitNewStaffToDeliverTrainingAgainstForecastPage : AssessorBasePage
    {
        protected override string PageTitle => "Recruit new staff to deliver training against forecast";
        
        public RecruitNewStaffToDeliverTrainingAgainstForecastPage(ScenarioContext context) : base(context) { }

        public TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage SelectPassAndContinueInRecruitNewStaffToDeliverTrainingAgainstForecastPage()
        {
            SelectPassAndContinueToSubSection();
            return new TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage(_context);
        }
    }
}