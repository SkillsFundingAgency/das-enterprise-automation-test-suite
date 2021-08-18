using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_WhenDoYouWantToWithdrawFromTheStandardPage : EPAO_BasePage
    {
        protected override string PageTitle => "When do you want to withdraw from assessing the standard?";
        private readonly ScenarioContext _context;
        
        #region Locators
        private By DayText => By.XPath("//input[@id='WR-10']");
        private By MonthText => By.XPath("//input[@id='WR-10_Month']");
        private By YearText => By.XPath("//input[@id='WR-10_Year']");
        #endregion

        public AS_WhenDoYouWantToWithdrawFromTheStandardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_WithdrawalRequestQuestionsPage EnterDateToWithdraw()
        {
            formCompletionHelper.EnterText(DayText, "19");
            formCompletionHelper.EnterText(MonthText, "02");
            formCompletionHelper.EnterText(YearText, "2024");
            Continue();
            return new AS_WithdrawalRequestQuestionsPage(_context);
        }
    }
}