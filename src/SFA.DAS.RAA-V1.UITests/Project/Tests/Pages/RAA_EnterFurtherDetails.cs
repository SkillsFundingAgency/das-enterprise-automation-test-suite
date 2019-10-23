using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages
{
    public class RAA_EnterFurtherDetails : BasePage
    {
        protected override By PageHeader => Heading;

        protected override string PageTitle => "Enter further details";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1DataHelper _dataHelper;
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

        public RAA_EnterFurtherDetails(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<RAAV1DataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public RAA_RequirementsAndProspects ClickSaveAndContinueButton()
        {
            _formCompletionHelper.Click(SaveAndContinueButton);
            return new RAA_RequirementsAndProspects(_context);
        }

        public RAA_EnterFurtherDetails EnterWorkingInformation()
        {
            _formCompletionHelper.EnterText(WorkkingWeek, _dataHelper.WorkkingWeek);
            return this;
        }

        public RAA_EnterFurtherDetails EnterHoursPerWeek(string hours)
        {
            _formCompletionHelper.EnterText(HoursPerWeek, hours);
            return this;
        }

        public RAA_EnterFurtherDetails ClickApprenticeshipMinimumWage()
        {
            _formCompletionHelper.SelectRadioOptionByText("National Minimum Wage for apprentices");
            return this;
        }

        public RAA_EnterFurtherDetails EnterVacancyDuration(string duration)
        {
            _formCompletionHelper.EnterText(VacancyDuration, duration);
            return this;
        }

        public RAA_EnterFurtherDetails EnterVacancyClosingDate()
        {
            DateTime closingDate = _dataHelper.VacancyClosing;
            string month = closingDate.Month.ToString();
            string year = closingDate.Year.ToString();
            string day = closingDate.Day.ToString();
            _formCompletionHelper.EnterText(ClosingDay, day);
            _formCompletionHelper.EnterText(ClosingMonth, month);
            _formCompletionHelper.EnterText(ClosingYear, year);
            return this;
        }

        public RAA_EnterFurtherDetails EnterPossibleStartDate()
        {
            DateTime startDate = _dataHelper.VacancyStart;
            var month = startDate.Month.ToString();
            var year = startDate.Year.ToString();
            var day = startDate.Day.ToString();
            _formCompletionHelper.EnterText(StartDateDay, day);
            _formCompletionHelper.EnterText(StartDateMonth, month);
            _formCompletionHelper.EnterText(StartDateYear, year);
            return this;
        }

        public RAA_EnterFurtherDetails EnterVacancyDescription()
        {
            _formCompletionHelper.EnterText(Iframe, _dataHelper.VacancyDescription);
            return this;
        }
    }
}
