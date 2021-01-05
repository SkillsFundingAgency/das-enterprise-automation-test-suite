using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AD_WithdrawalApplicationsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdrawal applications";

        private readonly ScenarioContext _context;

        private By ApprovedRegisterWithdrawalDetails => By.XPath($"//td[contains(text(),'{ePAOAdminDataHelper.TodaysDate}')]/../td[1]/a[contains(text(), 'Ingram Limited')]/../../td[contains(text(), 'Withdrawal from register')]");
        private By NewTab => By.Id("tab_new");
        private By InProgressTab => By.Id("tab_in-progress");
        private By FeedbackTab => By.Id("tab_feedback");
        private By ApprovedTab => By.Id("tab_approved");


        public AD_WithdrawalApplicationsPage(ScenarioContext context) : base(context) => _context = context;

        public AD_WithdrawalApplicationOverviewPage GoToStandardWithdrawlApplicationOverivewPage()
        {
            formCompletionHelper.ClickElement(NewTab);
            tableRowHelper.SelectRowFromTable("Brewer (ST0580)", "Withdrawal from register");
            return new AD_WithdrawalApplicationOverviewPage(_context);
        }

        public AD_WithdrawalApplicationsPage StoreCurrentTabValues()
        {
            _context["NewApplicationsCountBeforeApproval"] = pageInteractionHelper.GetDataCountOfAnElement(NewTab);
            _context["InProgressApplicationsCountBeforeApproval"] = pageInteractionHelper.GetDataCountOfAnElement(InProgressTab);
            _context["FeedbackApplicationsCountBeforeApproval"] = pageInteractionHelper.GetDataCountOfAnElement(FeedbackTab);
            _context["ApprovedApplicationsCountBeforeApproval"] = pageInteractionHelper.GetDataCountOfAnElement(ApprovedTab);

            return this;
        }

        public AD_WithdrawalApplicationOverviewPage GoToRegisterWithdrawlApplicationOverviewPage()
        {
            formCompletionHelper.ClickElement(NewTab);
            tableRowHelper.SelectRowFromTable("Ingram Limited", "Withdrawal from register");
            return new AD_WithdrawalApplicationOverviewPage(_context);
        }

        public AD_WithdrawalApplicationOverviewPage GoToAmmendedWithdrawalApplicationOverviewPage()
        {
            formCompletionHelper.ClickElement(FeedbackTab);
            tableRowHelper.SelectRowFromTable("Ingram Limited", "Feedback received");
            return new AD_WithdrawalApplicationOverviewPage(_context);
        }

        public AD_WithdrawalApplicationsPage VerifyAnApplicationHasMovedFromNewTab()
        {
            Assert.AreEqual(int.Parse(_context["NewApplicationsCountBeforeApproval"].ToString()) - 1, pageInteractionHelper.GetDataCountOfAnElement(NewTab));
            return this;
        }

        public AD_WithdrawalApplicationsPage VerifyAnApplicationAddedToFeedbackTab()
        {
            Assert.AreEqual(int.Parse(_context["FeedbackApplicationsCountBeforeApproval"].ToString()) + 1, pageInteractionHelper.GetDataCountOfAnElement(FeedbackTab));
            return this;
        }

        public AD_WithdrawalApplicationsPage VerifyAnApplicationAddedToApprovedTab()
        {
            Assert.AreEqual(int.Parse(_context["ApprovedApplicationsCountBeforeApproval"].ToString()) + 1, pageInteractionHelper.GetDataCountOfAnElement(ApprovedTab));
            return this;
        }

        public void VerifyApprovedTabContainsRegisterWithdrawal()
        {
            formCompletionHelper.ClickElement(ApprovedTab);
            Assert.IsNotNull(pageInteractionHelper.FindElements(ApprovedRegisterWithdrawalDetails));
        }
    }
}
