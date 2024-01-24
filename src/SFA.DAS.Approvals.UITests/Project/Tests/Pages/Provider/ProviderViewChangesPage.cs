using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderViewChangesPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "View changes";
        private static By ReviewNewDetails => By.LinkText("reviewing the new details");
        private static By ReviewNewDetailsToUpdate => By.LinkText("Review the apprentice details to update");
        protected override By ContinueButton => By.CssSelector("#submit-undo-changes, #continue-button");
        private static By ViewChangesOptions => By.CssSelector(".selection-button-radio");

        public ProvideViewApprenticesDetailsPage ClickOnReviewNewDetailsLink()
        {
            formCompletionHelper.Click(ReviewNewDetails);
            return new ProvideViewApprenticesDetailsPage(context);
        }

        public ProviderApproveApprenticeDetailsPage ClickOnReviewNewDetailsToUpdateLink()
        {
            formCompletionHelper.Click(ReviewNewDetailsToUpdate);
            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderAccessDeniedPage ClickContinueNavigateToProviderAccessDeniedPage()
        {
            Continue();
            return new ProviderAccessDeniedPage(context);
        }

        internal ProviderApprenticeDetailsPage ClickLeaveTheseChanges()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ViewChangesOptions, "undo-changes-false");
            Continue();
            return new ProviderApprenticeDetailsPage(context);
        }

        internal ProviderViewChangesPage SelectViewChangesOptions()
        {
            Continue();
            return this;
        }
    }
}
