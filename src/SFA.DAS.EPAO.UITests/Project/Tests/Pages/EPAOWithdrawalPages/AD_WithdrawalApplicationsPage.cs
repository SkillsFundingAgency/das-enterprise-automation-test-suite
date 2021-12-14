using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AD_WithdrawalApplicationsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdrawal applications";

        private readonly string NewTableSelector = "#new-organisation-applications > table:first-of-type";
        private readonly string FeedbackTableSelector = "#feedback-organisation-applications > table:first-of-type";
        private readonly string ApprovedTableSelector = "#approved-organisation-applications > table:first-of-type";

        private By NewTab => By.Id("tab_new");
        private By InProgressTab => By.Id("tab_in-progress");
        private By FeedbackTab => By.Id("tab_feedback");
        private By ApprovedTab => By.Id("tab_approved");

        public AD_WithdrawalApplicationsPage(ScenarioContext context) : base(context) => VerifyPage();

        public AD_WithdrawalRequestOverviewPage GoToStandardWithdrawlApplicationOverivewPage()
        {
            formCompletionHelper.ClickElement(NewTab);
            tableRowHelper.SelectRowFromTable("Ingram Limited", "Brewer");
            return new AD_WithdrawalRequestOverviewPage(context);
        }

        public AD_WithdrawalApplicationsPage StoreCurrentTabValues()
        {
            context["NewApplicationsCountBeforeApproval"] = pageInteractionHelper.GetDataCountOfAnElement(NewTab);
            context["InProgressApplicationsCountBeforeApproval"] = pageInteractionHelper.GetDataCountOfAnElement(InProgressTab);
            context["FeedbackApplicationsCountBeforeApproval"] = pageInteractionHelper.GetDataCountOfAnElement(FeedbackTab);
            context["ApprovedApplicationsCountBeforeApproval"] = pageInteractionHelper.GetDataCountOfAnElement(ApprovedTab);

            return this;
        }

        public AD_WithdrawalRequestOverviewPage GoToRegisterWithdrawlApplicationOverviewPage()
        {
            formCompletionHelper.ClickElement(NewTab);
            tableRowHelper.SelectRowFromTable("Ingram Limited", "Withdrawal from register", NewTableSelector);
            return new AD_WithdrawalRequestOverviewPage(context);
        }

        public AD_WithdrawalRequestOverviewPage GoToAmmendedWithdrawalApplicationOverviewPage()
        {
            formCompletionHelper.ClickElement(FeedbackTab);
            tableRowHelper.SelectRowFromTable("Ingram Limited", "Feedback received", FeedbackTableSelector);
            return new AD_WithdrawalRequestOverviewPage(context);
        }

        public AD_WithdrawalApplicationsPage VerifyAnApplicationHasMovedFromNewTab()
        {
            Assert.AreEqual(int.Parse(context["NewApplicationsCountBeforeApproval"].ToString()) - 1, pageInteractionHelper.GetDataCountOfAnElement(NewTab));
            return this;
        }

        public AD_WithdrawalApplicationsPage VerifyAnApplicationAddedToFeedbackTab()
        {
            Assert.AreEqual(int.Parse(context["FeedbackApplicationsCountBeforeApproval"].ToString()) + 1, pageInteractionHelper.GetDataCountOfAnElement(FeedbackTab));
            return this;
        }

        public AD_WithdrawalApplicationsPage VerifyAnApplicationAddedToApprovedTab()
        {
            Assert.AreEqual(int.Parse(context["ApprovedApplicationsCountBeforeApproval"].ToString()) + 1, pageInteractionHelper.GetDataCountOfAnElement(ApprovedTab));
            return this;
        }

        public void VerifyApprovedTabContainsRegisterWithdrawal()
        {
            var approvedTableLinkElement = tableRowHelper.FindElementInTable("Ingram Limited", "Withdrawal from register", ApprovedTableSelector);
            Assert.IsNotNull(approvedTableLinkElement);
        }
    }
}
