using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using OpenQA.Selenium;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class NotificationSentToTrainingProviderPage : CohortReferenceBasePage
    {
        protected override string PageTitle => "Notification sent to training provider";

        protected override By PageHeader => By.CssSelector(".govuk-panel__title");

        public NotificationSentToTrainingProviderPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}