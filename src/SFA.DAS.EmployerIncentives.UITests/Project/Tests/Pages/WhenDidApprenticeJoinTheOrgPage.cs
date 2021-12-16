using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class OneOrMoreApprenticeNotEligiblePage : EIBasePage
    {
        protected override string PageTitle => "One or more apprentices are not eligible for the payment";

        private By CancelApplication => By.LinkText("Cancel application");

        public OneOrMoreApprenticeNotEligiblePage(ScenarioContext context) : base(context)  { }

        public EIHubPage CancelTheApplication()
        {
            formCompletionHelper.ClickElement(CancelApplication);

            return new EIHubPage(context);
        }
    }

    public class WhenDidApprenticeJoinTheOrgPage : EIBasePage
    {
        //Title of the page is not being checked on this page since looping through multiple Apprentice names won't be feasible
        //protected override string PageTitle => $"When did <fname> <lname> join {ObjectContextExtension.GetOrganisationName(objectContext)}?";

        protected override string PageTitle => $"When did";

        #region Locators
        private By DateGroup => By.CssSelector(".govuk-date-input");
        private By DayInputField => By.Name("EmploymentStartDateDays");
        private By MonthInputField => By.Name("EmploymentStartDateMonths");
        private By YearInputField => By.Name("EmploymentStartDateYears");
        #endregion

        public WhenDidApprenticeJoinTheOrgPage(ScenarioContext context) : base(context)  { }

        public ConfirmApprenticesPage EnterValidJoiningDateAndContinue()
        {
            EnterJoiningDateAndContinue(true);

            return new ConfirmApprenticesPage(context);
        }

        public OneOrMoreApprenticeNotEligiblePage EnterInValidJoiningDateAndContinue()
        {
            EnterJoiningDateAndContinue(false);

            return new OneOrMoreApprenticeNotEligiblePage(context);
        }

        private void EnterJoiningDateAndContinue(bool validstartDate)
        {
            var apprentices = pageInteractionHelper.FindElements(DateGroup);

            foreach (var apprentice in apprentices)
            {
                var joiningDate = eIDataHelper.JoiningDate(validstartDate);
                formCompletionHelper.EnterText(apprentice.FindElement(DayInputField), joiningDate.Day);
                formCompletionHelper.EnterText(apprentice.FindElement(MonthInputField), joiningDate.Month);
                formCompletionHelper.EnterText(apprentice.FindElement(YearInputField), joiningDate.Year);
            }

            Continue();
        }
    }
}
