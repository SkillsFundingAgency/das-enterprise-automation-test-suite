using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;
using System;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApprenticeSummaryPage : FAABasePage
    {
        protected override string PageTitle => vacancyTitleDataHelper.VacancyTitle;

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
            if (!objectContext.IsRAAV1()) { VerifyEmployerDetails(); }
        }

        public FAA_YourApplicationPage View()
        {
            formCompletionHelper.Click(ViewApplicationLink);
            return new FAA_YourApplicationPage(_context);
        }

        public FAA_ApplicationFormPage Apply()
        {
            formCompletionHelper.Click(ApplyButton);
            return new FAA_ApplicationFormPage(_context);
        }

        private void VerifyEmployerDetails()
        {
            var empName = objectContext.GetEmployerName();
            VerifyPage(EmployerName, empName);
            VerifyPage(EmployerNameInAboutTheEmployerSection, empName);
        }

        public void VerifyNewDates()
        {

            DateTime Date = faaDataHelper.NewVacancyClosing;
            string actualClosingDate = Date.ToString("dd MMM yyyy");

            DateTime PossibleStartDate = faaDataHelper.NewVacancyStart;
            string actualStartDate = PossibleStartDate.ToString("dd MMM yyyy");

            pageInteractionHelper.VerifyText(ClosingDate, "Closing date: " + actualClosingDate + "");
            pageInteractionHelper.VerifyText(StartDate,actualStartDate);
        }

        public void VerifyNewWages()
        {
            string displayedWageFAA = pageInteractionHelper.GetText(VacancyWage);
            string[] wageRange = displayedWageFAA.Split('-');
            string minWage =regexHelper.GetVacancyCurrentWage(wageRange[0]);
            string maxWage = regexHelper.GetVacancyCurrentWage(wageRange[1]);
            pageInteractionHelper.VerifyText(minWage,faaDataHelper.NewCustomMinWagePerWeek);
            pageInteractionHelper.VerifyText(maxWage,faaDataHelper.NewCustomMaxWagePerWeek);
        }

        public FAA_ApprenticeSummaryPage ConfirmDraftVacancyDeletion()
        {
            pageInteractionHelper.VerifyText(ApplyButton, "Apply for apprenticeship");
            return this;
        }
    }
}
