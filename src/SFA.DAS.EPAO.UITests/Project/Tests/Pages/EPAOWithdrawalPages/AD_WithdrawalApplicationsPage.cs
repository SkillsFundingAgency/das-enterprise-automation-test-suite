using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AD_WithdrawalApplicationsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Withdrawal applications";

        private readonly ScenarioContext _context;

        private By NewWithdrawalApplication => By.XPath("//td[contains(text(),'Brewer (ST0580)')]/preceding-sibling::td[1]/a");
        private By NewRegisterWithdrawalApplication => By.XPath("//td[contains(text(),'Withdrawal from register')]/preceding-sibling::td[1]/a");
        private By ApprovedRegisterWithdrawalDetails => By.XPath($"//td[contains(text(),'{ePAOAdminDataHelper.TodaysDate}')]/../td[1]/a[contains(text(), 'Ingram Limited')]/../../td[contains(text(), 'Withdrawal from register')]");

        private By AmmendedRegisterWithdrawalLink => By.XPath($"//td[contains(text(),'{ePAOAdminDataHelper.TodaysDate}')]/../td[contains(text(), 'Feedback received')]/../td[contains(text(), 'Withdrawal from register')]/../td/a");
        private By NewTab => By.Id("tab_new");
        private By InProgressTab => By.Id("tab_in-progress");
        private By FeedbackTab => By.Id("tab_feedback");
        private By ApprovedTab => By.Id("tab_approved");


        public AD_WithdrawalApplicationsPage(ScenarioContext context) : base(context) => _context = context;
    
        public AD_WithdrawalApplicationOverviewPage GoToStandardWithdrawlApplicationOverivewPage()
        {
            formCompletionHelper.ClickElement(NewWithdrawalApplication);
            return new AD_WithdrawalApplicationOverviewPage(_context);
        }

        public AD_WithdrawalApplicationsPage StoreCurrentTabValues()
        {
            _context["NewApplicationsCountBeforeApproval"] = ePAOAdminDataHelper.ExtractNumberFromTab(pageInteractionHelper.GetText(NewTab));
            _context["InProgressApplicationsCountBeforeApproval"] = ePAOAdminDataHelper.ExtractNumberFromTab(pageInteractionHelper.GetText(InProgressTab));
            _context["FeedbackApplicationsCountBeforeApproval"] = ePAOAdminDataHelper.ExtractNumberFromTab(pageInteractionHelper.GetText(FeedbackTab));
            _context["ApprovedApplicationsCountBeforeApproval"] = ePAOAdminDataHelper.ExtractNumberFromTab(pageInteractionHelper.GetText(ApprovedTab));

            return this;
        }

        public AD_WithdrawalApplicationOverviewPage GoToRegisterWithdrawlApplicationOverviewPage()
        {
            formCompletionHelper.ClickElement(NewRegisterWithdrawalApplication);
            return new AD_WithdrawalApplicationOverviewPage(_context);
        }

        public AD_WithdrawalApplicationOverviewPage GoToAmmendedWithdrawalApplicationOverviewPage()
        {
            formCompletionHelper.ClickElement(AmmendedRegisterWithdrawalLink);
            return new AD_WithdrawalApplicationOverviewPage(_context);
        }

        public AD_WithdrawalApplicationsPage VerifyAnApplicationHasMovedFromNewTab()
        {
            Assert.AreEqual(int.Parse(_context["NewApplicationsCountBeforeApproval"].ToString()) - 1, ePAOAdminDataHelper.ExtractNumberFromTab(pageInteractionHelper.GetText(NewTab)));
            return this;
        }

        public AD_WithdrawalApplicationsPage VerifyAnApplicationAddedToFeedbackTab()
        {
            Assert.AreEqual(int.Parse(_context["FeedbackApplicationsCountBeforeApproval"].ToString()) + 1, ePAOAdminDataHelper.ExtractNumberFromTab(pageInteractionHelper.GetText(FeedbackTab)));
            return this;
        }

        public AD_WithdrawalApplicationsPage VerifyAnApplicationAddedToApprovedTab()
        {
            Assert.AreEqual(int.Parse(_context["ApprovedApplicationsCountBeforeApproval"].ToString()) + 1, ePAOAdminDataHelper.ExtractNumberFromTab(pageInteractionHelper.GetText(ApprovedTab)));
            return this;
        }

        public void VerifyApprovedTabContainsRegisterWithdrawal()
        {
            Assert.IsNotNull(pageInteractionHelper.FindElements(ApprovedRegisterWithdrawalDetails));
        }
    }
}
