using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class RejectingTheApprenticeshipApplicationsPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Rejecting the apprenticeship application(s)";

        public RejectingTheApprenticeshipApplicationsPage(ScenarioContext context) : base(context) { }

        private static By ContinueSelector => By.CssSelector("#reject_application");
        private static By RejectSelector => By.CssSelector("#reject-application-reject");
        private static By CancelSelector => By.CssSelector("#reject-application-cancel");

        public TransferPledgePage BulkReject()
        {
            formCompletionHelper.SelectRadioOptionByLocator(RejectSelector);
            formCompletionHelper.Click(ContinueSelector);
            return new TransferPledgePage(context);
        }

        public TransferPledgePage CancelBulkReject()
        {
            formCompletionHelper.SelectRadioOptionByLocator(CancelSelector);
            formCompletionHelper.Click(ContinueSelector);
            return new TransferPledgePage(context);
        }
    }
}
