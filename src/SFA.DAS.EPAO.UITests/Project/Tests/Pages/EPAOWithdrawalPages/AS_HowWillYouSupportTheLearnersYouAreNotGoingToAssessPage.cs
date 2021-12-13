using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_HowWillYouSupportTheLearnersYouAreNotGoingToAssessPage : EPAO_BasePage
    {
        protected override string PageTitle => "How will you support the learners you are not going to assess?";
        protected override By PageHeader => By.XPath("//*[@class='govuk-label govuk-label--xl']");

        #region Locators
        private By HowWillYouSupportLearnersTextArea => By.Id("WR-03");

        private By PageTitleLocator => By.XPath($"//label[contains(text(), '{PageTitle}')]");
        #endregion

        public AS_HowWillYouSupportTheLearnersYouAreNotGoingToAssessPage(ScenarioContext context) : base(context) => VerifyPage();

        public AS_HowWillYouCommunicateMarketExitToCustomersPage EnterAnswerForHowWillYouSupportLearnerYouAreNotGoingToAssess()
        {
            VerifyPage(PageTitleLocator, PageTitle);

            formCompletionHelper.Click(HowWillYouSupportLearnersTextArea);
            formCompletionHelper.EnterText(HowWillYouSupportLearnersTextArea, "Learners will be supported");
            Continue();
            return new AS_HowWillYouCommunicateMarketExitToCustomersPage(context);
        }

        public AS_WithdrawalRequestOverviewPage UpdateAnswerForHowWillYouSupportLearnersYouAreNotGoingToAssess()
        {
            formCompletionHelper.Click(HowWillYouSupportLearnersTextArea);
            formCompletionHelper.EnterText(HowWillYouSupportLearnersTextArea, "Learners will be supported by another training provider");
            Continue();
            return new AS_WithdrawalRequestOverviewPage(context);
        }
    }
}
