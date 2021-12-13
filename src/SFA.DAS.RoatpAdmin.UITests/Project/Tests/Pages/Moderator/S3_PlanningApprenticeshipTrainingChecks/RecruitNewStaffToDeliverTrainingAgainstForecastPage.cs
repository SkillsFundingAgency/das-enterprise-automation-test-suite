using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class RecruitNewStaffToDeliverTrainingAgainstForecastPage : ModeratorBasePage
    {
        protected override string PageTitle => "Recruit new staff to deliver training against forecast";
        
        public RecruitNewStaffToDeliverTrainingAgainstForecastPage(ScenarioContext context) : base(context) { }

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