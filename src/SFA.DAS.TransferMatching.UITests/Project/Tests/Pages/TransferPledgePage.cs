using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class TransferPledgePage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => $"Transfer pledge {GetPledgeId()}";

        protected override string AccessibilityPageTitle => "Transfer pledge page";

        private static By DownloadSelector => By.CssSelector("#main-content > div > div:nth-child(1) > div.govuk-grid-column-one-third > p > a");
        private static By ClosePLedgeSelector => By.Id("close-pledge-button");
        private static By RejectContinueSelector => By.CssSelector("#applications-action");
        private static By CheckBoxSelector => By.ClassName("govuk-checkboxes__input");
        private static By PledgedFundsSelector => By.CssSelector("#main-content > div.govuk-width-container > div:nth-child(2) > div:nth-child(1) > div > p.govuk-heading-l.app-data__figure\r\n");
        private static By EstimatedRemainingFundsSelector => By.CssSelector("#main-content > div.govuk-width-container > div:nth-child(2) > div:nth-child(2) > div > p.govuk-heading-l.app-data__figure");
        private static By ApplicationStatusSelector => By.CssSelector("#ApplicationsToReject > fieldset > table > tbody > tr > td:nth-child(6) > strong");

        private static By PledgedFunds => By.LinkText("Pledged funds");
        private static By RemainingFunds => By.LinkText("Remaining funds");
        private static By EstimatedCost => By.LinkText("Estimated yearly cost");
        private static By Applicant => By.LinkText("Applicant");
        private static By TypicalDuration => By.LinkText("Typical duration");
        private static By Criteria => By.LinkText("Criteria");
        private static By Status => By.LinkText("Status");

        public TransferPledgePage VerifyPledgeAmount()
        {
            pageInteractionHelper.IsElementDisplayed(PledgedFunds);
            pageInteractionHelper.IsElementDisplayed(RemainingFunds);
            return new TransferPledgePage(context);
        }

        public TransferPledgePage VerifyCostingModel()
        {
            var estimatedcost = tMDataHelper.GetEstimatedCostOfTrainingForApplicationDetail().CurrencyStringToInt();
            var pledgedFunds = pageInteractionHelper.GetText(PledgedFundsSelector).CurrencyStringToInt();
            var remainingFunds = pageInteractionHelper.GetText(EstimatedRemainingFundsSelector).CurrencyStringToInt();

            Assert.That(estimatedcost, Is.EqualTo(pledgedFunds - remainingFunds));

            return new TransferPledgePage(context);
        }
        public ClosePledgePage ClosePledge()
        {
            formCompletionHelper.Click(ClosePLedgeSelector);
            return new ClosePledgePage(context);
        }

        public TransferPledgePage DownloadExcel()
        {
            formCompletionHelper.Click(DownloadSelector);
            return new TransferPledgePage(context);
        }

        public TransferPledgePage ConfirmApplicationStatus(string expected)
        {
            Assert.That(pageInteractionHelper.GetText(ApplicationStatusSelector), Is.EqualTo(expected), "Expected Application Status not found");

            return new TransferPledgePage(context);
        }

        public ApproveAppliationPage GoToApproveAppliationPage()
        {
            formCompletionHelper.ClickLinkByText(objectContext.GetOrganisationName());
            return new ApproveAppliationPage(context);
        }

        public TransferPledgePage SortByApplicant()
        {
            formCompletionHelper.ClickElement(Applicant);
            formCompletionHelper.ClickElement(EstimatedCost);
            formCompletionHelper.ClickElement(TypicalDuration);
            formCompletionHelper.ClickElement(Criteria);
            formCompletionHelper.ClickElement(Status);
            return new TransferPledgePage(context);
        }

        public RejectingTheApprenticeshipApplicationsPage SelectBulkReject()
        {
            formCompletionHelper.SelectCheckbox(CheckBoxSelector);
            formCompletionHelper.Click(RejectContinueSelector);
            return new RejectingTheApprenticeshipApplicationsPage(context);
        }
    }
}