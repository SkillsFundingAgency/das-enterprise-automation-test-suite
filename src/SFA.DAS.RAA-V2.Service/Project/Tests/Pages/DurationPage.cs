using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class DurationPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Duration and working hours";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Duration => By.Id("Duration");

        private By WorkingWeekDescription => By.Id("WorkingWeekDescription");

        private By WeeklyHours => By.Id("WeeklyHours");

        public DurationPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public WageTypePage EnterDuration()
        {
            pageInteractionHelper.WaitforURLToChange("/duration/");
            formCompletionHelper.EnterText(Duration, rAAV2DataHelper.Duration);
            formCompletionHelper.EnterText(WorkingWeekDescription, rAAV2DataHelper.WorkkingWeek);
            formCompletionHelper.EnterText(WeeklyHours, rAAV2DataHelper.WeeklyHours);
            Continue();
            pageInteractionHelper.WaitforURLToChange("wage");
            return new WageTypePage(_context);
        }
    }
}
