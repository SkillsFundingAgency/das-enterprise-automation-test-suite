using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HomePage : InterimHomeBasePage
    {
        #region Locators
        protected By StartNowButton => By.LinkText("Start now");
        protected By YourFundingReservationsLink => By.LinkText("Your funding reservations");
        protected By YourTransfersLink => By.LinkText("Your transfers");
        private By PublicAccountIdLocator => By.CssSelector(".das-definition-list__definition");
        private By SucessSummary => By.CssSelector(".das-notification");
        private By AcceptYourAgreementLink => By.LinkText("Accept your agreement");
        private By ContinueTo => By.LinkText("Continue");
        private By SetUpAnApprenticeshipSectionHeader => By.Id("set-up-an-apprenticeship");
        protected By FinancesSectionHeading => By.XPath("//h2[text()='Finances']");
        protected By YourFinancesLink => By.LinkText("Your finances");

        private By TaskList => By.XPath("//div[@id='tasks']");
        private By StartAddingApprenticesNowTaskLink => By.PartialLinkText("Start adding apprentices now");
        private By ConnectionRequestToReviewTaskLink => By.XPath($"//ul/li/span[contains(.,'connection request to review')]");
        private By ConnectionRequestsToReviewTaskLink => By.XPath($"//ul/li/span[contains(.,'connection requests to review')]");
        private By ConnectionRequestsCountToReviewTaskLink(int count) => By.XPath($"//div[@id='tasks']/ul/li/span[contains(.,'{count} connection request{(count > 1 ? "s" : string.Empty)} to review')]");
        private By TransferRequestReceivedTaskLink => By.XPath("//ul/li/span[contains(.,'Transfer request received')]");
        #endregion

        public HomePage(ScenarioContext context, bool navigate) : base(context, navigate) => AcceptCookies();

        public HomePage(ScenarioContext context) : this(context, false) { }

        public HomePage VerifySucessSummary(string message)
        {
            pageInteractionHelper.VerifyText(SucessSummary, message);
            return this;
        }

        public HomePage VerifyAccountName(string name)
        {
            pageInteractionHelper.VerifyText(PageHeader, name);
            return this;
        }

        public AboutYourAgreementPage ClickAcceptYourAgreementLinkInHomePagePanel()
        {
            formCompletionHelper.Click(AcceptYourAgreementLink);
            return new AboutYourAgreementPage(context);
        }

        public void ContinueToCreateAdvert() => formCompletionHelper.ClickElement(ContinueTo);

        public void VerifySetupAnApprenticeshipSection()
        {
            VerifyElement(SetUpAnApprenticeshipSectionHeader);
            VerifyElement(StartNowButton);
        }

        public void VerifyStartAddingApprenticesNowTaskLink() => VerifyElement(StartAddingApprenticesNowTaskLink);

        public void VerifyTransferConnectionRequestsToReviewTaskLink(int count) => VerifyElement(ConnectionRequestsCountToReviewTaskLink(count));

        public void VerifyNoTransferConnectionRequestsToReviewTaskLinks()
        {
            var taskList = pageInteractionHelper.FindElement(TaskList);
            Assert.Zero(pageInteractionHelper.FindElements(taskList, ConnectionRequestToReviewTaskLink).Count);
            Assert.Zero(pageInteractionHelper.FindElements(taskList, ConnectionRequestsToReviewTaskLink).Count);
        }

        public void VerifyTransferRequestReceivedTaskLink() => VerifyElement(TransferRequestReceivedTaskLink);

        public void VerifyNoTransferRequestReceviedTaskLink()
        {
            var taskList = pageInteractionHelper.FindElement(TaskList);
            Assert.Zero(pageInteractionHelper.FindElements(taskList, TransferRequestReceivedTaskLink).Count);
        }
    }
}