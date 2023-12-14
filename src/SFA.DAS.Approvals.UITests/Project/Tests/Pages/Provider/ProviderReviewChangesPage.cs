using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderReviewChangesPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Review changes";

        private static By ApproveSelector => By.CssSelector("#ApproveChanges");

        private static By RejectSelector => By.CssSelector("#ApproveChanges-no");

        private static By ErrorMsg => By.CssSelector(".govuk-error-summary");

        private static By IsValidCourseErrorMsg => By.CssSelector("#error-message-IsValidCourseCode");

        protected override By ContinueButton => By.CssSelector("#continue-button");

        public void VerifyLimitingStandardRestriction()
        {
            MultipleVerifyPage(
            [
                () => VerifyPage(ErrorMsg, "There is a problem"),
                () => VerifyPage(ErrorMsg, "This training course has not been declared"),
                () => VerifyPage(IsValidCourseErrorMsg, "This training course has not been declared")
            ]);
        }

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
