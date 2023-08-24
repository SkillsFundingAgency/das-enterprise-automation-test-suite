using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class TasksHomePage : HomePage
    {
        private static By TaskList => By.CssSelector("#tasks");
        private static By StartAddingApprenticesNowTaskLink => By.PartialLinkText("Start adding apprentices now");

        private static By ApprenticeChangeToReviewTaskLink(bool multiple) => By.XPath($"//ul/li/span[contains(.,'apprentice change{(multiple ? "s" : string.Empty)} to review')]");
        private static By CohortRequestReadyForApprovalTaskLink(bool multiple) => By.XPath($"//ul/li/span[contains(.,'cohort request{(multiple ? "s" : string.Empty)} ready for approval')]");

        private static By ReviewConnectionRequestTaskLink(bool multiple) => By.XPath($"//ul/li/span[contains(.,'connection request{(multiple ? "s" : string.Empty)} to review')]");

        private static By TransferRequestReceivedTaskLink => By.XPath("//ul/li/span[contains(.,'Transfer request received')]");

        protected override By PageHeader => By.CssSelector(".govuk-tabs");

        protected override string PageTitle => "Tasks";

        public TasksHomePage(ScenarioContext context) : base(context)
        {
                
        }

        public void VerifyStartAddingApprenticesNowTaskLink() => VerifyElement(StartAddingApprenticesNowTaskLink);

        public void AssertTaskCount(string taskType, int expectedNumberOfTasks)
        {
            context.Get<RetryAssertHelper>().RetryOnNUnitException(() =>
            {
                Assert.That(pageInteractionHelper.FindElements(TaskList).Count > 0, "No Task list element found");

                int currentNumberOfTasks = GetTaskCount(taskType);

                Assert.That(currentNumberOfTasks == expectedNumberOfTasks, $"The task type '{taskType}' was expected to have '{expectedNumberOfTasks}' tasks but currently has '{currentNumberOfTasks}' task");
            }, () => pageInteractionHelper.RefreshPage());

        }

        private int GetTaskCount(string taskType)
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

        private static int GetCurrentNumberOfTasks(IWebElement taskLink, bool hasItemsDueCount)
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