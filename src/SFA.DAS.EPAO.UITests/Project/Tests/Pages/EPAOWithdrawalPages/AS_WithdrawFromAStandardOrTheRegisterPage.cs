using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_WithdrawFromAStandardOrTheRegisterPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdraw from a standard or the register";
        private readonly ScenarioContext _context;
        public AS_WithdrawFromAStandardOrTheRegisterPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        /*
        public AS_WhatAreYouWithdrawingFromPage ClickContinueOnWithdrawFromAStandardOrTheRegisterPage()
        {
            Continue();
            var nextPage = pageInteractionHelper.GetText(PageHeader);

            if (nextPage == "Select withdrawal application")
                return new AS_SelectWithdrawalApplicationPage(_context).ClickStartSelectWithdrawalApplication();
            else
                return new AS_YourWithdrawalNotificationsPage(_context).ClickStartNewWithdrawalNotification();
        }
        */

        public AS_YourWithdrawalNotificationsPage ClickContinueOnWithdrawFromAStandardOrTheRegisterPage()
        {
            Continue();
            return new AS_YourWithdrawalNotificationsPage(_context);
        }
    }
}
