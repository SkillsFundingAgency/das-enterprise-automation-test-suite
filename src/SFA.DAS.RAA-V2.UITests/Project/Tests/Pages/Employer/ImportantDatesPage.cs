using OpenQA.Selenium;
using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ImportantDatesPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Important dates";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ClosingDay => By.Id("ClosingDay");
        private By ClosingMonth => By.Id("ClosingMonth");
        private By ClosingYear => By.Id("ClosingYear");
        private By StartDateDay => By.Id("StartDay");
        private By StartDateMonth => By.Id("StartMonth");
        private By StartDateYear => By.Id("StartYear");
        private By IsDisabilityConfident => By.Id("IsDisabilityConfident");


        public ImportantDatesPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public void EnterVacancyClosingDate()
        {
            DateTime closingDate = dataHelper.VacancyClosing;
            string month = closingDate.Month.ToString();
            string year = closingDate.Year.ToString();
            string day = closingDate.Day.ToString();
            formCompletionHelper.EnterText(ClosingDay, day);
            formCompletionHelper.EnterText(ClosingMonth, month);
            formCompletionHelper.EnterText(ClosingYear, year);
        }

        public void EnterPossibleStartDate()
        {
            DateTime startDate = dataHelper.VacancyStart;
            var month = startDate.Month.ToString();
            var year = startDate.Year.ToString();
            var day = startDate.Day.ToString();
            formCompletionHelper.EnterText(StartDateDay, day);
            formCompletionHelper.EnterText(StartDateMonth, month);
            formCompletionHelper.EnterText(StartDateYear, year);
        }

        public DurationPage EnterImportantDates()
        {
            EnterVacancyClosingDate();
            EnterPossibleStartDate();
            Continue();
            return new DurationPage(_context);
        }
    }
}
