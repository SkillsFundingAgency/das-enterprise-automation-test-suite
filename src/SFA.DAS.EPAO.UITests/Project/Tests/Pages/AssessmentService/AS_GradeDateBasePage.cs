using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.EPAO.UITests.Project.Helpers;
using System;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public abstract class AS_GradeDateBasePage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly EPAODataHelper _ePAODataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        #region Locators
        private By DayTextBox => By.Id("Day");
        private By MonthTextBox => By.Id("Month");
        private By YearTextBox => By.Id("Year");
        #endregion

        public AS_GradeDateBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _ePAODataHelper = context.Get<EPAODataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
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
            _formCompletionHelper.EnterText(YearTextBox, year);
            Continue();
        }

        public bool VerifyDateErrorText(string errorText) => _pageInteractionHelper.IsElementDisplayed(By.LinkText(errorText));

        private void EnterDateFieldsAndContinue(bool invalidDateScenario = false)
        {
            _formCompletionHelper.EnterText(DayTextBox, _ePAODataHelper.GetCurrentDay);
            _formCompletionHelper.EnterText(MonthTextBox, _ePAODataHelper.GetCurrentMonth);
            if (invalidDateScenario) return;
            _formCompletionHelper.EnterText(YearTextBox, _ePAODataHelper.GetCurrentYear);
            Continue();
        }
    }
}
