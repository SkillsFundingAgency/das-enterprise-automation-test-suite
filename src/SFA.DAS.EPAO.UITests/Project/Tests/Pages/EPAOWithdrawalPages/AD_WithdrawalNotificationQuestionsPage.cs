using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AD_WithdrawalNotificationQuestionsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdrawal notification questions";

        private By SaveButton => By.CssSelector("button.govuk-button");

        private readonly ScenarioContext _context;

        public AD_WithdrawalNotificationQuestionsPage(ScenarioContext context) : base(context) => _context = context;

        public AD_StandardWithdrawalApplicationOverviewPage MarkCompleteAndGoToStandardWithdrawalApplicationOverviewPage()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            formCompletionHelper.Click(SaveButton);

            return new AD_StandardWithdrawalApplicationOverviewPage(_context);
        }
    }
}
