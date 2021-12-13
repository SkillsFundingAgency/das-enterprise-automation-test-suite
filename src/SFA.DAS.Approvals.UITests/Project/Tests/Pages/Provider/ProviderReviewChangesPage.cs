using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderReviewChangesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Review changes";

        private By ApproveSelector => By.CssSelector("#ApproveChanges");

        private By RejectSelector => By.CssSelector("#ApproveChanges-no");

        protected override By ContinueButton => By.CssSelector("#continue-button");        

        public ProviderReviewChangesPage(ScenarioContext context) : base(context)  { }

        public ProviderEditedApprenticeDetailsPage SelectApproveChangesAndSubmit()
        {
            SelectOption(ApproveSelector);
            
            return new ProviderEditedApprenticeDetailsPage(context);
        }

        public ProviderApprenticeDetailsPage SelectRejectChangesAndSubmit()
        {
            SelectOption(RejectSelector);

            return new ProviderApprenticeDetailsPage(context);
        }

        public ProviderAccessDeniedPage ClickContinueNavigateToProviderAccessDeniedPage()
        {
            Continue();
            return new ProviderAccessDeniedPage(context);
        }

        public ProviderReviewChangesPage SelectReviewChangesOptions()
        {
            Continue();
            return this;
        }

        private void SelectOption(By by) { formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(by)); Continue(); }
    }
}
