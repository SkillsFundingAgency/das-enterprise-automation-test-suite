using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;
using System;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApprenticeSummaryPage : FAABasePage
    {
        protected override string PageTitle => _vacancytitledataHelper.VacancyTitle;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ApplyButton => By.Id("apply-button");

        private By ViewApplicationLink => By.Id("view-application-link");

        private By EmployerName => By.Id("vacancy-subtitle-employer-name");

        private By EmployerNameInAboutTheEmployerSection => By.Id("vacancy-employer-name");

        private By ClosingDate => By.Id("vacancy-closing-date");

        private By StartDate => By.Id("vacancy-start-date");

        private By VacancyWage => By.Id("vacancy-wage");

        public FAA_ApprenticeSummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
            if (!_objectContext.IsRAAV1()) { VerifyEmployerDetails(); }
        }

        public FAA_YourApplicationPage View()
        {
            _formCompletionHelper.Click(ViewApplicationLink);
            return new FAA_YourApplicationPage(_context);
        }

        public FAA_ApplicationFormPage Apply()
        {
            _formCompletionHelper.Click(ApplyButton);
            return new FAA_ApplicationFormPage(_context);
        }

        private void VerifyEmployerDetails()
        {
            var empName = _objectContext.GetEmployerName();
            VerifyPage(EmployerName, empName);
            VerifyPage(EmployerNameInAboutTheEmployerSection, empName);
        }

        public void VerifyNewDates()
        {

            DateTime Date = _faadataHelper.NewVacancyClosing;
            string actualClosingDate = Date.ToString("dd MMM yyyy");

            DateTime PossibleStartDate = _faadataHelper.NewVacancyStart;
            string actualStartDate = PossibleStartDate.ToString("dd MMM yyyy");

            _pageInteractionHelper.VerifyText(ClosingDate, "Closing date: " + actualClosingDate + "");
            _pageInteractionHelper.VerifyText(StartDate,actualStartDate);
        }

        public void VerifyNewWages()
        {
            string displayedWageFAA = _pageInteractionHelper.GetText(VacancyWage);
            string[] wageRange = displayedWageFAA.Split('-');
            string minWage =_regexHelper.GetVacancyCurrentWage(wageRange[0]);
            string maxWage = _regexHelper.GetVacancyCurrentWage(wageRange[1]);
            _pageInteractionHelper.VerifyText(minWage,_faadataHelper.NewCustomMinWagePerWeek);
            _pageInteractionHelper.VerifyText(maxWage,_faadataHelper.NewCustomMaxWagePerWeek);
        }

        public FAA_ApprenticeSummaryPage ConfirmDraftVacancyDeletion()
        {
            _pageInteractionHelper.VerifyText(ApplyButton, "Apply for apprenticeship");
            return this;
        }
    }
}
