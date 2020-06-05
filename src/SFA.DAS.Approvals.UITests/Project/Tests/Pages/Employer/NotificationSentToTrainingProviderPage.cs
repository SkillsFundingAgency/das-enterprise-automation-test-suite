using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class NotificationSentToTrainingProviderPage : CohortReferenceBasePage
    {
        protected override string PageTitle => "Notification sent to training provider";

        protected override By PageHeader => By.CssSelector(".govuk-panel__title");
        private By DynamicHomeLink => By.CssSelector(".das-navigation__list-item");
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public NotificationSentToTrainingProviderPage(ScenarioContext context) : base(context) => _context = context;
        
        public DynamicHomePages ClickHomeLink()
        {
           formCompletionHelper.ClickElement(DynamicHomeLink);
           return new DynamicHomePages(_context);
        }
    }
}