using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AD_WithdrawalNotificationQuestionsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdrawal notification questions";

        private By SaveButton => By.CssSelector("button.govuk-button");
        private By AddFeedbackHowWillYouSupportLearnersLink => By.XPath("//dd/h3[contains(text(),\"How will you support the learners you are not going to assess?\")]/../following-sibling::dd/p/a");
        
        private readonly ScenarioContext _context;

        public AD_WithdrawalNotificationQuestionsPage(ScenarioContext context) : base(context) => _context = context;

        public AD_WithdrawalApplicationOverviewPage MarkCompleteAndGoToStandardWithdrawalApplicationOverviewPage()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            formCompletionHelper.Click(SaveButton);

            return new AD_WithdrawalApplicationOverviewPage(_context);
        }

        public AD_HowWillYouSupportTheLearnersYouAreNotGoingToAssess ClickAddFeedbackToHowWillYouSupportLearnersQuestion()
        {
            formCompletionHelper.Click(AddFeedbackHowWillYouSupportLearnersLink);
            return new AD_HowWillYouSupportTheLearnersYouAreNotGoingToAssess(_context);
        }
    }
}
