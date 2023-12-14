using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class ApplicationsDetailsPage : TransferMatchingBasePage
    {
        protected override string PageTitle => $"({GetPledgeId()}) application details";

        protected override string AccessibilityPageTitle => "Pledge application details page";
        protected override By ContinueButton => By.CssSelector("#fund-transfer-accept");

        private static By InformationSelector => By.CssSelector("#TruthfulInformation");

        private static By ComplyWithRulesSelector => By.CssSelector("#ComplyWithRules");

        private static By WithdrawalConfirmedSelector => By.CssSelector("input#IsDeclineConfirmed");

        private static By WithdrawFundingSelector => By.CssSelector("input#IsWithdrawalConfirmed");

        private static By ContinueSelector => By.CssSelector("#main-content > div > div.govuk-grid-column-two-thirds > form > div.govuk-button-group > button");

        private static By ErrorTitle => By.CssSelector("#main-content .govuk-error-summary");

        public ApplicationsDetailsPage(ScenarioContext context, string applicationStatus) : base(context, false)
        {
            VerifyApplicationStatus(applicationStatus);

            if (applicationStatus == "FUNDS AVAILABLE") VerifyPage(PageHeader, $"{GetPledgeId()}");
            else VerifyPage();
        }

        public ApplicationsDetailsPage SetPledgeApplication()
        {
            var applicationid = GetUrl().Split("/").ToList().LastOrDefault();

            objectContext.SetPledgeApplication(GetPledgeId(), applicationid);

            return this;
        }

        public AcceptedTransferPage VerifyAgreeToTermsIsMandatoryAndAcceptFunding()
        {
            SelectRadioOptionByText("Yes, accept the funding");

            Continue();

            VerifyTermsError();

            AcceptInformationTerms();

            Continue();

            VerifyTermsError();

            AcceptInformationTerms();

            AcceptComplyWithRulesTerms();

            Continue();

            VerifyTermsError();

            AcceptInformationTerms();

            Continue();

            return new AcceptedTransferPage(context);
        }

        public SuccessfullyWithdrawnPage WithdrawFunding()
        {
            SelectRadioOptionByText("No, decline the funding and withdraw the application");
            Continue();
            VerifyConfirmError();
            ConfirmWithdrawal();
            Continue();

            return new SuccessfullyWithdrawnPage(context);
        }

        public SuccessfullyWithdrawnYourApplicationPage WithdrawBeforeApproval()
        {
            SelectRadioOptionByText("Yes, withdraw the application");
            CompleteWithdraw();
            formCompletionHelper.Click(ContinueSelector);

            return new SuccessfullyWithdrawnYourApplicationPage(context);
        }

        private void VerifyTermsError() => VerifyElement(ErrorTitle, "You must agree to the terms and conditions before accepting funding for this application");

        private void VerifyConfirmError() => VerifyElement(ErrorTitle, "You must confirm that you want to decline the funding and withdraw the application");


        private void AcceptInformationTerms() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(InformationSelector));

        private void AcceptComplyWithRulesTerms() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ComplyWithRulesSelector));

        private void ConfirmWithdrawal() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(WithdrawalConfirmedSelector));

        private void CompleteWithdraw() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(WithdrawFundingSelector));
    }
}
