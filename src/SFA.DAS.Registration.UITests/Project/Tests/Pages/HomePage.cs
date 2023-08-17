using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HomePage : InterimHomeBasePage
    {
        #region Locators
        protected static By StartNowButton => By.LinkText("Start now");
        protected static By YourFundingReservationsLink => By.LinkText("Your funding reservations");
        protected static By YourTransfersLink => By.LinkText("Your transfers");
        private static By SucessSummary => By.CssSelector(".das-notification");
        private static By AcceptYourAgreementLink => By.LinkText("Accept your agreement");
        private static By ContinueTo => By.LinkText("Continue");
        private static By SetUpAnApprenticeshipSectionHeader => By.Id("set-up-an-apprenticeship");
        protected static By FinancesSectionHeading => By.XPath("//h2[text()='Finances']");
        protected static By YourFinancesLink => By.LinkText("Your finances");

        private static By TaskList => By.XPath("//div[@id='tasks']");
        private static By StartAddingApprenticesNowTaskLink => By.PartialLinkText("Start adding apprentices now");

        private static By ApprenticeChangeToReviewTaskLink(bool multiple) => By.XPath($"//ul/li/span[contains(.,'apprentice change{(multiple ? "s" : string.Empty)} to review')]");
        private static By CohortRequestReadyForApprovalTaskLink(bool multiple) => By.XPath($"//ul/li/span[contains(.,'cohort request{(multiple ? "s" : string.Empty)} ready for approval')]");

        private static By ReviewConnectionRequestTaskLink(bool multiple) => By.XPath($"//ul/li/span[contains(.,'connection request{(multiple ? "s" : string.Empty)} to review')]");

        private static By TransferRequestReceivedTaskLink => By.XPath("//ul/li/span[contains(.,'Transfer request received')]");
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

        public void VerifyTaskCount(string taskType, int expectedNumberOfTasks)
        {
            int currentNumberOfTasks = GetTaskCount(taskType);

            if (currentNumberOfTasks != expectedNumberOfTasks)
                throw new Exception($"The task type {taskType} was expected to have {expectedNumberOfTasks} tasks but currently has {currentNumberOfTasks} task");
        }

        public int GetTaskCount(string taskType)
        {
            var taskList = pageInteractionHelper.FindElement(TaskList);
            switch (taskType)
            {
                case "ApprenticeChangeToReview":
                    return GetCurrentNumberOfTasks(pageInteractionHelper.FindElements(taskList, ApprenticeChangeToReviewTaskLink(false), true).FirstOrDefault() ??
                        pageInteractionHelper.FindElements(taskList, ApprenticeChangeToReviewTaskLink(true), true).FirstOrDefault(), true); ;

                case "CohortRequestReadyForApproval":
                    return GetCurrentNumberOfTasks(pageInteractionHelper.FindElements(taskList, CohortRequestReadyForApprovalTaskLink(false), true).FirstOrDefault() ??
                        pageInteractionHelper.FindElements(taskList, CohortRequestReadyForApprovalTaskLink(true), true).FirstOrDefault(), true); ;

                case "ReviewConnectionRequest":
                    return GetCurrentNumberOfTasks(pageInteractionHelper.FindElements(taskList, ReviewConnectionRequestTaskLink(false), true).FirstOrDefault() ??
                        pageInteractionHelper.FindElements(taskList, ReviewConnectionRequestTaskLink(true), true).FirstOrDefault(), true);

                case "TransferRequestReceived":
                    return GetCurrentNumberOfTasks(pageInteractionHelper.FindElements(taskList, TransferRequestReceivedTaskLink, true).FirstOrDefault(), false);
            }

            return 0;
        }

        private int GetCurrentNumberOfTasks(IWebElement taskLink, bool hasItemsDueCount)
        {
            if (taskLink != null && hasItemsDueCount)
            {
                var match = Regex.Match(taskLink.Text, "^(\\d+).*\r?$", RegexOptions.Multiline);
                return match.Success && match.Groups.Count > 0 ? int.Parse(match.Groups[1].Value) : 0;
            }
            else if (taskLink != null)
            {
                return 1;
            }

            return 0;
        }
    }
}