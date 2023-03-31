namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AD_WithdrawalApplicationsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdrawal applications";

        private readonly string NewTableSelector = "#new-organisation-applications > table:first-of-type";
        private readonly string FeedbackTableSelector = "#feedback-organisation-applications > table:first-of-type";
        private readonly string ApprovedTableSelector = "#approved-organisation-applications > table:first-of-type";

        private static By NewTab => By.Id("tab_new");
        private static By InProgressTab => By.Id("tab_in-progress");
        private static By FeedbackTab => By.Id("tab_feedback");
        private static By ApprovedTab => By.Id("tab_approved");

        private static string WithrawalOrgName => "Ingram Limited";

        public AD_WithdrawalApplicationsPage(ScenarioContext context) : base(context) => VerifyPage();

        public AD_WithdrawalRequestOverviewPage GoToStandardWithdrawlApplicationOverivewPage()
        {
            formCompletionHelper.ClickElement(NewTab);
            tableRowHelper.SelectRowFromTable(WithrawalOrgName, "Brewer");
            return new AD_WithdrawalRequestOverviewPage(context);
        }

        public AD_WithdrawalRequestOverviewPage GoToRegisterWithdrawlApplicationOverviewPage()
        {
            formCompletionHelper.ClickElement(NewTab);
            tableRowHelper.SelectRowFromTable(WithrawalOrgName, "Withdrawal from register", NewTableSelector);
            return new(context);
        }

        public AD_WithdrawalRequestOverviewPage GoToAmmendedWithdrawalApplicationOverviewPage()
        {
            formCompletionHelper.ClickElement(FeedbackTab);
            tableRowHelper.SelectRowFromTable(WithrawalOrgName, "Feedback received", FeedbackTableSelector);
            return new(context);
        }

        public void VerifyAnApplicationAddedToFeedbackTab() => DoesNotThrow(FeedbackTableSelector);

        public void VerifyApprovedTabContainsRegisterWithdrawal() => DoesNotThrow(ApprovedTableSelector);

        private void DoesNotThrow(string table)
        {        
            Assert.DoesNotThrow(() => tableRowHelper.FindElementInTable(WithrawalOrgName, new List<string> { "Withdrawal from register", $"{DateTime.Now:dd MMMM yyyy}" }, table));
        }
    }
}
