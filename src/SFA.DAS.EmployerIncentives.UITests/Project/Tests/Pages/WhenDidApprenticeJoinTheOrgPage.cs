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
        private By DateGroup => By.CssSelector(".govuk-date-input");
        private By DayInputField => By.Name("EmploymentStartDateDays");
        private By MonthInputField => By.Name("EmploymentStartDateMonths");
        private By YearInputField => By.Name("EmploymentStartDateYears");
        #endregion

        public WhenDidApprenticeJoinTheOrgPage(ScenarioContext context) : base(context, false)  { }

        public ConfirmApprenticesPage EnterJoiningDateAndContinue()
        {
            var apprentices = pageInteractionHelper.FindElements(DateGroup);

            foreach (var apprentice in apprentices)
            {
                formCompletionHelper.EnterText(apprentice.FindElement(DayInputField), eIDataHelper.JoiningDay);
                formCompletionHelper.EnterText(apprentice.FindElement(MonthInputField), eIDataHelper.JoiningMonth);
                formCompletionHelper.EnterText(apprentice.FindElement(YearInputField), "2021");
            }

            Continue();

            return new ConfirmApprenticesPage(_context);
        }
    }
}
