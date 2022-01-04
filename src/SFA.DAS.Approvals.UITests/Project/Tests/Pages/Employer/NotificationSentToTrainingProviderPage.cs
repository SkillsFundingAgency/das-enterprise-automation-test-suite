using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class NotificationSentToTrainingProviderPage : CohortReferenceBasePage
    {
        protected override string PageTitle => "Notification sent to training provider";

        protected override bool TakeFullScreenShot => false;

        protected override By PageHeader => By.CssSelector(".govuk-panel__title");
        private By DynamicHomeLink => By.CssSelector(".das-navigation__list-item");
        
        public NotificationSentToTrainingProviderPage(ScenarioContext context) : base(context)  { }
        
        public DynamicHomePages ClickHomeLink()
        {
           formCompletionHelper.ClickElement(DynamicHomeLink);
           return new DynamicHomePages(context);
        }
    }
}