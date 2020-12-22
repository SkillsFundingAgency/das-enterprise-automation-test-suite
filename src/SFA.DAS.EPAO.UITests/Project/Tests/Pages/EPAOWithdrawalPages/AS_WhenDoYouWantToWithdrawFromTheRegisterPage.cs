using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_WhenDoYouWantToWithdrawFromTheRegisterPage : EPAO_BasePage
    {
        protected override string PageTitle => "When do you want to withdraw from the register?";
        private readonly ScenarioContext _context;
        #region Locators
        private By DayText => By.XPath("//label[contains(text(), 'Day')]/following-sibling::input");
        private By MonthText => By.XPath("//label[contains(text(), 'Month')]/following-sibling::input");
        private By YearText => By.XPath("//label[contains(text(), 'Year')]/following-sibling::input");
        #endregion
        public AS_WhenDoYouWantToWithdrawFromTheRegisterPage(ScenarioContext context) : base(context)
        {
            _context = context;
            //VerifyPage();
        }
        public AS_WithdrawalNotificationQuestionsPage EnterDateToWithdraw()
        {
            formCompletionHelper.EnterText(DayText, "01");
            formCompletionHelper.EnterText(MonthText, "05");
            formCompletionHelper.EnterText(YearText, "2021");
            Continue();
            return new AS_WithdrawalNotificationQuestionsPage(_context);
        }
    }
}