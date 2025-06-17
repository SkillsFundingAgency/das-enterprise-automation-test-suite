using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class RecruitNewStaffToDeliverTrainingAgainstForecastPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Recruit new staff to deliver training against forecast";

        public TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage SelectPassAndContinueInRecruitNewStaffToDeliverTrainingAgainstForecastPage()
        {
            SelectPassAndContinueToSubSection();
            return new TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage(context);
        }
    }
}