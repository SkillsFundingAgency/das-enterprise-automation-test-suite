using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class RecruitNewStaffToDeliverTrainingAgainstForecastPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Recruit new staff to deliver training against forecast";

        public TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage SelectPassAndContinueInRecruitNewStaffToDeliverTrainingAgainstForecastPage()
        {
            SelectPassAndContinueToSubSection();
            return new TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage(context);
        }

        public TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage SelectFailAndContinueInRecruitNewStaffToDeliverTrainingAgainstForecastPage()
        {
            SelectFailAndContinueToSubSection();
            return new TypicalRatioOfTheStaffDeliveringTrainingToTheApprenticesPage(context);
        }
    }
}