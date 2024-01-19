using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApprenticeSummaryPage : FAABasePage
    {
        protected override string PageTitle => vacancyTitleDataHelper.VacancyTitle;

        protected override string AccessibilityPageTitle => "FAA vacancy title page";

        private static By ApplyButton => By.Id("apply-button");

        private static By ViewApplicationLink => By.Id("view-application-link");

        private static By EmployerName => By.Id("vacancy-subtitle-employer-name");

        private static By EmployerNameInAboutTheEmployerSection => By.Id("vacancy-employer-name");

        private static By ClosingDate => By.Id("vacancy-closing-date");

        private static By StartDate => By.Id("vacancy-start-date");

        private static By VacancyWage => By.Id("vacancy-wage");

        public FAA_ApprenticeSummaryPage(ScenarioContext context) : base(context)
        {
            if (!objectContext.IsRAAV1()) { VerifyEmployerDetails(); }
        }

        public FAA_YourApplicationPage View()
        {
            formCompletionHelper.Click(ViewApplicationLink);
            return new FAA_YourApplicationPage(context);
        }

        public FAA_ApplicationFormPage Apply()
        {
            formCompletionHelper.Click(ApplyButton);
            return new FAA_ApplicationFormPage(context);
        }

        private void VerifyEmployerDetails()
        {
            var empName = objectContext.GetEmployerNameAsShownInTheAdvert();
            VerifyElement(EmployerName, empName);
            VerifyElement(EmployerNameInAboutTheEmployerSection, empName);
        }

        public void VerifyNewDates()
        {

            DateTime Date = faaDataHelper.NewVacancyClosing;
            string actualClosingDate = Date.ToString("dd MMM yyyy");

            DateTime PossibleStartDate = faaDataHelper.NewVacancyStart;
            string actualStartDate = PossibleStartDate.ToString("dd MMM yyyy");

            pageInteractionHelper.VerifyText(ClosingDate, "Closing date: " + actualClosingDate + "");
            pageInteractionHelper.VerifyText(StartDate, actualStartDate);
        }

        public void VerifyNewWages()
        {
            string displayedWageFAA = pageInteractionHelper.GetText(VacancyWage);
            string[] wageRange = displayedWageFAA.Split('-');
            string minWage = RegexHelper.GetVacancyCurrentWage(wageRange[0]);
            string maxWage = RegexHelper.GetVacancyCurrentWage(wageRange[1]);
            pageInteractionHelper.VerifyText(minWage, faaDataHelper.NewCustomMinWagePerWeek);
            pageInteractionHelper.VerifyText(maxWage, faaDataHelper.NewCustomMaxWagePerWeek);
        }

        public FAA_ApprenticeSummaryPage ConfirmDraftVacancyDeletion()
        {
            pageInteractionHelper.VerifyText(ApplyButton, "Apply for apprenticeship");
            return this;
        }
    }
}
