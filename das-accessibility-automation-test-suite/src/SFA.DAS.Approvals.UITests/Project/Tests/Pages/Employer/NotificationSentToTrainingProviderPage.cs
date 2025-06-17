using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class NotificationSentToTrainingProviderPage(ScenarioContext context) : CohortReferenceBasePage(context)
    {
        protected override string PageTitle => "Notification sent to training provider";

        protected override bool TakeFullScreenShot => false;

        protected override By PageHeader => PanelTitle;
        private static By DynamicHomeLink => By.CssSelector(".das-navigation__list-item");

        public DynamicHomePages ClickHomeLink()
        {
            formCompletionHelper.ClickElement(DynamicHomeLink);
            return new DynamicHomePages(context);
        }
    }
}