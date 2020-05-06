using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public abstract class AS_GradeDateBasePage : EPAOAssesment_BasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");
        private readonly ScenarioContext _context;

        #region Locators
        private By DayTextBox => By.Id("Day");
        private By MonthTextBox => By.Id("Month");
        private By YearTextBox => By.Id("Year");
        private By DateError => By.Id("Day-error");
        #endregion

        public AS_GradeDateBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        /*PASS and FAIL scenarios return two different pages, so do NOT return any page for this method*/
        public void EnterAchievementGradeDateAndContinue()
        {
            EnterDateFieldsAndContinue();
        }

        public AS_UkprnPage EnterApprenticshipStartDateAndContinue()
        {
            EnterDateFieldsAndContinue();
            return new AS_UkprnPage(_context);
        }

        public AS_SearchEmployerAddressPage EnterAchievementGradeDateForPrivatelyFundedApprenticeAndContinue()
        {
            EnterDateFieldsAndContinue();
            return new AS_SearchEmployerAddressPage(_context);
        }

        public void EnterAchievementGradeDateForPrivatelyFundedApprenticeAndContinue(int year)
        {
            EnterDateFieldsAndContinue(true);
            formCompletionHelper.EnterText(YearTextBox, year);
            Continue();
        }

        public string GetDateErrorText() => pageInteractionHelper.GetText(DateError);

        private void EnterDateFieldsAndContinue(bool invalidDateScenario = false)
        {
            formCompletionHelper.EnterText(DayTextBox, dataHelper.CurrentDay);
            formCompletionHelper.EnterText(MonthTextBox, dataHelper.CurrentMonth);
            if (invalidDateScenario) return;
            formCompletionHelper.EnterText(YearTextBox, dataHelper.CurrentYear);
            Continue();
        }
    }
}
