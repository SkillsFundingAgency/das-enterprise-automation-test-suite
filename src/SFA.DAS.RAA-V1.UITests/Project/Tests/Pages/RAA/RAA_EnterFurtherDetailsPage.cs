using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_EnterFurtherDetailsPage : RAA_ChangeVacancyDatesBasePage
    {
        protected override By PageHeader => Heading;

        protected override string PageTitle => "Enter further details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        
        private By Iframe => By.CssSelector("iframe");
        private By WorkingWeek => By.Id("WorkingWeek");
        private By HoursPerWeek => By.Id("Wage_HoursPerWeek");
        private By VacancyDuration => By.Id("Duration");
        private By SaveAndContinueButton => By.Id("vacancySummaryButton");
        private By Heading => By.Id("heading");

        public RAA_EnterFurtherDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_RequirementsAndProspectsPage SaveAndContinue()
        {
            formCompletionHelper.Click(SaveAndContinueButton);
            return new RAA_RequirementsAndProspectsPage(_context);
        }

        public RAA_EnterFurtherDetailsPage EnterWorkingInformation()
        {
            formCompletionHelper.EnterText(WorkingWeek, dataHelper.WorkkingWeek);
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

        public new RAA_EnterFurtherDetailsPage EnterVacancyClosingDate()
        {
            base.EnterVacancyClosingDate();
            return this;
        }

        public new RAA_EnterFurtherDetailsPage EnterPossibleStartDate()
        {
            base.EnterPossibleStartDate();
            return this;
        }

        public RAA_EnterFurtherDetailsPage EnterVacancyDescription()
        {
            formCompletionHelper.SendKeys(Iframe, Keys.Tab + dataHelper.VacancyDescription);
            return this;
        }
    }
}
