using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_FeedbackOnYourWithdrawalNotificationStartPage : EPAO_BasePage
    {
        protected override string PageTitle => "Feedback on your withdrawal notification";

        private readonly ScenarioContext _context;

        public AS_FeedbackOnYourWithdrawalNotificationStartPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_ApplicationOverviewPage ClickContinueButton()
        {
            Continue();
            return new AS_ApplicationOverviewPage(_context);
        }
    }
}
