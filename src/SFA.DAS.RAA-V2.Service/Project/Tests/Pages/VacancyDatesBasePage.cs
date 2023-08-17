using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class VacancyDatesBasePage : Raav2BasePage
    {
        public VacancyDatesBasePage(ScenarioContext context) : base(context) { }

        protected static By ClosingDay => By.Id("ClosingDay");
        protected static By ClosingMonth => By.Id("ClosingMonth");
        protected static By ClosingYear => By.Id("ClosingYear");
        protected static By StartDateDay => By.Id("StartDay");
        protected static By StartDateMonth => By.Id("StartMonth");
        protected static By StartDateYear => By.Id("StartYear");
        protected static By IsDisabilityConfident => By.Id("IsDisabilityConfident");

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
