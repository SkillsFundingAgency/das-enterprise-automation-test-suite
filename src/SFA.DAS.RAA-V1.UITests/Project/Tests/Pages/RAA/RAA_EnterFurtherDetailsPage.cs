using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_EnterFurtherDetailsPage : RAA_HeaderSectionBasePage
    {
        protected override By PageHeader => Heading;

        protected override string PageTitle => "Enter further details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        
        private By Iframe => By.CssSelector("iframe");
        private By WorkkingWeek => By.Id("WorkingWeek");
        private By HoursPerWeek => By.Id("Wage_HoursPerWeek");
        private By ApprenticeshipMinimumWage => By.Id("apprenticeship-minimum-wage");
        private By VacancyDuration => By.Id("Duration");
        private By ClosingDay => By.Id("VacancyDatesViewModel_ClosingDate_Day");
        private By ClosingMonth => By.Id("VacancyDatesViewModel_ClosingDate_Month");
        private By ClosingYear => By.Id("VacancyDatesViewModel_ClosingDate_Year");
        private By StartDateDay => By.Id("VacancyDatesViewModel_PossibleStartDate_Day");
        private By StartDateMonth => By.Id("VacancyDatesViewModel_PossibleStartDate_Month");
        private By StartDateYear => By.Id("VacancyDatesViewModel_PossibleStartDate_Year");
        private By SaveAndContinueButton => By.Id("vacancySummaryButton");
        private By Heading => By.Id("heading");

        public RAA_EnterFurtherDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_RequirementsAndProspects ClickSaveAndContinueButton()
        {
            formCompletionHelper.Click(SaveAndContinueButton);
            return new RAA_RequirementsAndProspects(_context);
        }

        public RAA_EnterFurtherDetailsPage EnterWorkingInformation()
        {
            formCompletionHelper.EnterText(WorkkingWeek, dataHelper.WorkkingWeek);
            return this;
        }

        public RAA_EnterFurtherDetailsPage EnterHoursPerWeek(string hours)
        {
            formCompletionHelper.EnterText(HoursPerWeek, hours);
            return this;
        }

        public RAA_EnterFurtherDetailsPage ClickApprenticeshipMinimumWage()
        {
            formCompletionHelper.SelectRadioOptionByText("National Minimum Wage for apprentices");
            return this;
        }

        public RAA_EnterFurtherDetailsPage EnterVacancyDuration(string duration)
        {
            formCompletionHelper.EnterText(VacancyDuration, duration);
            return this;
        }

        public RAA_EnterFurtherDetailsPage EnterVacancyClosingDate()
        {
            DateTime closingDate = dataHelper.VacancyClosing;
            string month = closingDate.Month.ToString();
            string year = closingDate.Year.ToString();
            string day = closingDate.Day.ToString();
            formCompletionHelper.EnterText(ClosingDay, day);
            formCompletionHelper.EnterText(ClosingMonth, month);
            formCompletionHelper.EnterText(ClosingYear, year);
            return this;
        }

        public RAA_EnterFurtherDetailsPage EnterPossibleStartDate()
        {
            DateTime startDate = dataHelper.VacancyStart;
            var month = startDate.Month.ToString();
            var year = startDate.Year.ToString();
            var day = startDate.Day.ToString();
            formCompletionHelper.EnterText(StartDateDay, day);
            formCompletionHelper.EnterText(StartDateMonth, month);
            formCompletionHelper.EnterText(StartDateYear, year);
            return this;
        }

        public RAA_EnterFurtherDetailsPage EnterVacancyDescription()
        {
            formCompletionHelper.SendKeys(Iframe, Keys.Tab + dataHelper.VacancyDescription);
            return this;
        }
    }
}
