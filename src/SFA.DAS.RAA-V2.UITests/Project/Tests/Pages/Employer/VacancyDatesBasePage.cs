using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public abstract class VacancyDatesBasePage : RAAV2CSSBasePage
    {
        public VacancyDatesBasePage(ScenarioContext context) : base(context) { }

        protected By ClosingDay => By.Id("ClosingDay");
        protected By ClosingMonth => By.Id("ClosingMonth");
        protected By ClosingYear => By.Id("ClosingYear");
        protected By StartDateDay => By.Id("StartDay");
        protected By StartDateMonth => By.Id("StartMonth");
        protected By StartDateYear => By.Id("StartYear");
        protected By IsDisabilityConfident => By.Id("IsDisabilityConfident");

        protected void ClosingDate(DateTime date) => EditDates(date, ClosingDay, ClosingMonth, ClosingYear);

        protected void StartDate(DateTime date) => EditDates(date, StartDateDay, StartDateMonth, StartDateYear);

        private void EditDates(DateTime date, By dayselector, By monthselector, By yearselector)
        {
            string day = date.Day.ToString();
            string month = date.Month.ToString();
            string year = date.Year.ToString();

            formCompletionHelper.EnterText(dayselector, day);
            formCompletionHelper.EnterText(monthselector, month);
            formCompletionHelper.EnterText(yearselector, year);
        }
    }
}
