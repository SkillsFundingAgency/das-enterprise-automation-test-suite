using System;
using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class WhenDidApprenticeJoinTheOrgPage : EIBasePage
    {
        //Title of the page is not being checked on this page since looping through multiple Apprentice names won't be feasible
        protected override string PageTitle => $"When did <fname> <lname> join {ObjectContextExtension.GetOrganisationName(objectContext)}?";

        #region Locators
        private readonly ScenarioContext _context;

        private By DateGroup => By.CssSelector(".govuk-date-input");
        private By DayInputField => By.Name("EmploymentStartDateDays");
        private By MonthInputField => By.Name("EmploymentStartDateMonths");
        private By YearInputField => By.Name("EmploymentStartDateYears");
        #endregion

        public WhenDidApprenticeJoinTheOrgPage(ScenarioContext context) : base(context, false) => _context = context;

        public ConfirmApprenticesPage EnterJoiningDateAndContinue(DateTime? employmentStartDate)
        {
            if (employmentStartDate == null)
            {
                employmentStartDate = new DateTime(2021, Convert.ToInt32(eIDataHelper.JoiningMonth), Convert.ToInt32(eIDataHelper.JoiningDay));
            }

            var apprentices = pageInteractionHelper.FindElements(DateGroup);

            foreach (var apprentice in apprentices)
            {
                formCompletionHelper.EnterText(apprentice.FindElement(DayInputField), employmentStartDate.Value.Day);
                formCompletionHelper.EnterText(apprentice.FindElement(MonthInputField), employmentStartDate.Value.Month);
                formCompletionHelper.EnterText(apprentice.FindElement(YearInputField), employmentStartDate.Value.Year);
            }

            Continue();

            return new ConfirmApprenticesPage(_context);
        }

        public WhenDidApprenticeJoinTheOrgPage EnterJoiningDate(int apprenticeshipIndex, DateTime employmentStartDate)
        {
            var apprentices = pageInteractionHelper.FindElements(DateGroup);
            formCompletionHelper.EnterText(apprentices[apprenticeshipIndex].FindElement(DayInputField), employmentStartDate.Day);
            formCompletionHelper.EnterText(apprentices[apprenticeshipIndex].FindElement(MonthInputField), employmentStartDate.Month);
            formCompletionHelper.EnterText(apprentices[apprenticeshipIndex].FindElement(YearInputField), employmentStartDate.Year);
            return this;
        }

        public new void Continue()
        {
            base.Continue();
        }
    }
}
