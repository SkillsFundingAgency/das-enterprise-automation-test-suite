using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AD_CompleteReview : EPAO_BasePage
    {
        protected override string PageTitle => "Complete review";

        private readonly ScenarioContext _context;
        private By ApproveApplicationButton => By.CssSelector("button.govuk-button");
        private By AskForMoreInformationButton => By.CssSelector("button.govuk-button");
        public AD_CompleteReview(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AD_YouhaveApprovedThisWithdrawalNotification ClickApproveApplication()
        {
            formCompletionHelper.Click(ApproveApplicationButton);
            return new AD_YouhaveApprovedThisWithdrawalNotification(_context);
        }

        public AD_FeedbackSent ClickAddFeedback()
        {
            formCompletionHelper.Click(AskForMoreInformationButton);
            return new AD_FeedbackSent(_context);
        }
    }
}
