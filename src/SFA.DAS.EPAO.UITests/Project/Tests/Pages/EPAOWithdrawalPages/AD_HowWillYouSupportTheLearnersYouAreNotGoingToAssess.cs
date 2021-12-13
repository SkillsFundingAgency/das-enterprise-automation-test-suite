using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AD_HowWillYouSupportTheLearnersYouAreNotGoingToAssess : EPAO_BasePage
    {
        protected override string PageTitle => "How will you support the learners you are not going to assess?";

        private By AddFeedbackButton => By.CssSelector("button.govuk-button");
        private By FeedbackMessageTextArea => By.Id("FeedbackMessage");

        public AD_HowWillYouSupportTheLearnersYouAreNotGoingToAssess(ScenarioContext context) : base(context) => VerifyPage();

        public AD_WithdrawalRequestQuestionsPage AddFeedbackMessage()
        {
            formCompletionHelper.Click(FeedbackMessageTextArea);
            formCompletionHelper.EnterText(FeedbackMessageTextArea, ePAOAdminDataHelper.GetRandomAlphabeticString(200));
            formCompletionHelper.Click(AddFeedbackButton);
            return new AD_WithdrawalRequestQuestionsPage(_context);
        }
    }
}
