using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public abstract class RAA_ChangeVacancyDatesBasePage : RAA_HeaderSectionBasePage
    {
        private By ClosingDay => By.Id("VacancyDatesViewModel_ClosingDate_Day");
        private By ClosingMonth => By.Id("VacancyDatesViewModel_ClosingDate_Month");
        private By ClosingYear => By.Id("VacancyDatesViewModel_ClosingDate_Year");
        private By StartDateDay => By.Id("VacancyDatesViewModel_PossibleStartDate_Day");
        private By StartDateMonth => By.Id("VacancyDatesViewModel_PossibleStartDate_Month");
        private By StartDateYear => By.Id("VacancyDatesViewModel_PossibleStartDate_Year");

        public RAA_ChangeVacancyDatesBasePage(ScenarioContext context) : base(context) { }

        public void EnterVacancyClosingDate()
        {
            DateTime closingDate = rAAV1DataHelper.NewVacancyClosing;
            string month = closingDate.Month.ToString();
            string year = closingDate.Year.ToString();
            string day = closingDate.Day.ToString();
            formCompletionHelper.EnterText(ClosingDay, day);
            formCompletionHelper.EnterText(ClosingMonth, month);
            formCompletionHelper.EnterText(ClosingYear, year);
        }

        public void EnterPossibleStartDate()
        {
            DateTime startDate = rAAV1DataHelper.NewVacancyStart;
            var month = startDate.Month.ToString();
            var year = startDate.Year.ToString();
            var day = startDate.Day.ToString();
            formCompletionHelper.EnterText(StartDateDay, day);
            formCompletionHelper.EnterText(StartDateMonth, month);
            formCompletionHelper.EnterText(StartDateYear, year);
        }
    }
}
