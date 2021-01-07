using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_HowWillYouSupportTheLearnersYouAreNotGoingToAssessPage : EPAO_BasePage
    {
        protected override string PageTitle => "How will you support the learners you are not going to assess?";
        private readonly ScenarioContext _context;
        private readonly bool _feedback;

        #region Locators
        private By HowWillYouSupportLearnersTextArea => By.Id("WR-03");

        private By PageTitleLocator => By.XPath($"//label[contains(text(), '{PageTitle}')]");
        #endregion

        public AS_HowWillYouSupportTheLearnersYouAreNotGoingToAssessPage(ScenarioContext context, bool feedback = false) : base(context)
        {
            _context = context;
            _feedback = feedback;
        }

        public AS_HowWillYouCommunicateMarketExitToCustomersPage EnterAnswerForHowWillYouSupportLearnerYouAreNotGoingToAssess()
        {
            VerifyPage(PageTitleLocator, PageTitle);

            formCompletionHelper.Click(HowWillYouSupportLearnersTextArea);
            formCompletionHelper.EnterText(HowWillYouSupportLearnersTextArea, "Learners will be supported");
            Continue();
            return new AS_HowWillYouCommunicateMarketExitToCustomersPage(_context);
        }

        public AS_ApplicationOverviewPage UpdateAnswerForHowWillYouSupportLearnersYouAreNotGoingToAssess()
        {
            formCompletionHelper.Click(HowWillYouSupportLearnersTextArea);
            formCompletionHelper.EnterText(HowWillYouSupportLearnersTextArea, "Learners will be supported by another training provider");
            Continue();
            return new AS_ApplicationOverviewPage(_context);
        }

        public AS_HowWillYouSupportTheLearnersYouAreNotGoingToAssessPage VerifyFeedbackIsDisplayed()
        {
            return this;
        }
    }
}
