using OpenQA.Selenium;
using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
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
            VerifyPage();
        }

        public WageTypePage EnterDuration(string duration, string weeklyHours)
        {
            _formCompletionHelper.EnterText(Duration, duration);
            _formCompletionHelper.EnterText(WorkingWeekDescription, _dataHelper.WorkkingWeek);
            _formCompletionHelper.EnterText(WeeklyHours, weeklyHours);
            _formCompletionHelper.Click(Continue);
            return new WageTypePage(_context);
        }
    }
}
