using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class DurationPage : Raav2BasePage
    {
        protected override string PageTitle => IsTraineeship ? "Duration and weekly hours" : "Duration and working hours";

        private static By Duration => By.Id("Duration");

        private static By WorkingWeekDescription => By.Id("WorkingWeekDescription");

        private static By WeeklyHours => By.Id("WeeklyHours");

        public DurationPage(ScenarioContext context) : base(context) { }

        public WageTypePage EnterDuration()
        {
            pageInteractionHelper.WaitforURLToChange("/duration/");
            EnterDurationAndWorkingWeek(RAAV2DataHelper.Duration);
            formCompletionHelper.EnterText(WeeklyHours, RAAV2DataHelper.WeeklyHours);
            Continue();
            pageInteractionHelper.WaitforURLToChange("wage");
            return new WageTypePage(context);
        }

        public SubmitNoOfPositionsPage EnterTraineeshipDuration()
        {
            pageInteractionHelper.WaitforURLToChange("/duration/");
            EnterDurationAndWorkingWeek(RAAV2DataHelper.TraineeshipDuration);
            Continue();
            pageInteractionHelper.WaitforURLToChange("number-of-positions");
            return new SubmitNoOfPositionsPage(context);
        }

        private void EnterDurationAndWorkingWeek(string duration)
        {
            formCompletionHelper.EnterText(Duration, duration);
            formCompletionHelper.EnterText(WorkingWeekDescription, rAAV2DataHelper.WorkkingWeek);
        }
    }
}
