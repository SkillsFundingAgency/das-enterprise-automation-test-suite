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
        
        private By WorkingWeek => By.Id("WorkingWeek");
        private By HoursPerWeek => By.Id("Wage_HoursPerWeek");
        private By VacancyDuration => By.Id("Duration");
        private By SaveAndContinueButton => By.Id("vacancySummaryButton");
        private By Heading => By.Id("heading");
        private By FixedWageAmount => By.Id("Wage_Amount");
        private By WageAmountLowerBound => By.Id("Wage_AmountLowerBound");
        private By WageAmountUpperBound => By.Id("Wage_AmountUpperBound");
        private By WageUnit => By.Id("Wage_Unit");

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
            formCompletionHelper.EnterText(WorkingWeek, rAAV1DataHelper.WorkkingWeek);
            return this;
        }

        public RAA_EnterFurtherDetailsPage EnterHoursPerWeek(string hours)
        {
            formCompletionHelper.EnterText(HoursPerWeek, hours);
            return this;
        }

        public RAA_EnterFurtherDetailsPage Wage(string wagetype)
        {
            switch (wagetype)
            {
                case "National Minimum Wage":
                    formCompletionHelper.SelectRadioOptionByText("National Minimum Wage");
                    break;
                case "Fixed Wage":
                    FixedWage();
                    break;
                case "Wage Range":
                    WageRange();
                    break;
                default:
                    formCompletionHelper.SelectRadioOptionByText("National Minimum Wage for apprentices");
                    break;
            }
            return this;
        }

        public RAA_EnterFurtherDetailsPage ApprenticeshipMinimumWage()
        {
            formCompletionHelper.SelectRadioOptionByText("National Minimum Wage for apprentices");
            return this;
        }

        public RAA_EnterFurtherDetailsPage NationalMinimumWage()
        {
            formCompletionHelper.SelectRadioOptionByText("National Minimum Wage");
            return this;            
        }

        public RAA_EnterFurtherDetailsPage FixedWage()
        {
            formCompletionHelper.SelectRadioOptionByText("Custom wage");
            formCompletionHelper.SelectRadioOptionByText("Fixed wage");
            formCompletionHelper.EnterText(FixedWageAmount, rAAV1DataHelper.FixedWagePerWeek);
            formCompletionHelper.SelectFromDropDownByValue(WageUnit, "Weekly");
            return this;
        }

        public RAA_EnterFurtherDetailsPage WageRange()
        {
            formCompletionHelper.SelectRadioOptionByText("Custom wage");
            formCompletionHelper.SelectRadioOptionByText("Wage range");
            formCompletionHelper.EnterText(WageAmountLowerBound, rAAV1DataHelper.CustomMinWagePerWeek);
            formCompletionHelper.EnterText(WageAmountUpperBound, rAAV1DataHelper.CustomMaxWagePerWeek);
            formCompletionHelper.SelectFromDropDownByValue(WageUnit, "Weekly");
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
            formCompletionHelper.SendKeys(frameHelper.Iframe, Keys.Tab + rAAV1DataHelper.VacancyDescription);
            return this;
        }
    }
}
