using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
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
            formCompletionHelper.EnterText(Duration, dataHelper.Duration);
            formCompletionHelper.EnterText(WorkingWeekDescription, dataHelper.WorkkingWeek);
            formCompletionHelper.EnterText(WeeklyHours, dataHelper.WeeklyHours);
            Continue();
            return new WageTypePage(_context);
        }
    }
}
