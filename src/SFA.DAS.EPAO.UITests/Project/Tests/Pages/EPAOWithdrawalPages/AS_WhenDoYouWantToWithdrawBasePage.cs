using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public abstract class AS_WhenDoYouWantToWithdrawBasePage : EPAO_BasePage
    {
        
        #region Locators
        private By DayText => By.XPath("//label[contains(text(), 'Day')]/following-sibling::input");
        private By MonthText => By.XPath("//label[contains(text(), 'Month')]/following-sibling::input");
        private By YearText => By.XPath("//label[contains(text(), 'Year')]/following-sibling::input");
        #endregion

        public AS_WhenDoYouWantToWithdrawBasePage(ScenarioContext context) : base(context) => VerifyPage();

        public AS_WithdrawalRequestQuestionsPage EnterDateToWithdraw()
        {
            var date = DateTime.Now.AddMonths(7).AddDays(2);

            formCompletionHelper.EnterText(DayText, date.ToString("dd"));
            formCompletionHelper.EnterText(MonthText, date.ToString("MM"));
            formCompletionHelper.EnterText(YearText, date.ToString("yyyy"));
            Continue();
            return new AS_WithdrawalRequestQuestionsPage(_context);
        }
    }
}