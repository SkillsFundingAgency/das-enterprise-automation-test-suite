using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{

    public class WhenDidApprenticeJoinTheOrgPage : EIBasePage
    {
        protected override string PageTitle => $"{(pageInteractionHelper.FindElements(DateGroup).Count == 1 ? string.Empty : "When did they")} join {objectContext.GetOrganisationName()}?";

        #region Locators
        private By DateGroup => By.CssSelector(".govuk-date-input");
        private By DayInputField => By.Name("EmploymentStartDateDays");
        private By MonthInputField => By.Name("EmploymentStartDateMonths");
        private By YearInputField => By.Name("EmploymentStartDateYears");
        #endregion

        private enum JoiningDate { Valid, Invalid, ValidAndInvalid }

        public WhenDidApprenticeJoinTheOrgPage(ScenarioContext context) : base(context)  { }

        public ConfirmApprenticesPage EnterValidJoiningDateAndContinue()
        {
            EnterJoiningDateAndContinue(JoiningDate.Valid);

            return new ConfirmApprenticesPage(context);
        }

        public OneOrMoreApprenticeNotEligiblePage EnterInValidJoiningDateAndContinue()
        {
            EnterJoiningDateAndContinue(JoiningDate.Invalid);

            return new OneOrMoreApprenticeNotEligiblePage(context);
        }

        public OneOrMoreApprenticeNotEligiblePage EnterValidAndInValidJoiningDateAndContinue()
        {
            EnterJoiningDateAndContinue(JoiningDate.ValidAndInvalid);

            return new OneOrMoreApprenticeNotEligiblePage(context);
        }

        private void EnterJoiningDateAndContinue(JoiningDate joiningDate)
        {
            var apprentices = pageInteractionHelper.FindElements(DateGroup);

            switch (joiningDate)
            {
                case JoiningDate.Valid:
                    EnterJoiningDate(apprentices, true);
                    break;
                case JoiningDate.Invalid:
                    EnterJoiningDate(apprentices, false);
                    break;
                case JoiningDate.ValidAndInvalid:
                    var count = apprentices.Count / 2;
                    EnterJoiningDate(apprentices, 0, count , true);
                    EnterJoiningDate(apprentices, count, apprentices.Count, false);
                    break;
                default:
                    break;
            }

            Continue();
        }

        public void EnterJoiningDate(List<IWebElement> apprentices, bool validStartDate) => EnterJoiningDate(apprentices, 0, apprentices.Count, validStartDate);

        private void EnterJoiningDate(List<IWebElement> apprentices, int start, int length, bool validStartDate)
        {
            for (int i = start; i < length; i++)
            {
                var joiningDate = eIDataHelper.JoiningDate(validStartDate);
                var apprentice = apprentices[i];
                formCompletionHelper.EnterText(apprentice.FindElement(DayInputField), joiningDate.Day);
                formCompletionHelper.EnterText(apprentice.FindElement(MonthInputField), joiningDate.Month);
                formCompletionHelper.EnterText(apprentice.FindElement(YearInputField), joiningDate.Year);
            }
        }
    }
}
