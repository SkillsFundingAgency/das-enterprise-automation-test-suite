using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeDetailsApprovedPage : CohortReferenceBasePage
    {
        protected override string PageTitle => "Apprentice details approved";

        protected override By PageHeader => PanelTitle;

        private static By ClickDynamicHomeLink => By.CssSelector(".das-navigation__list-item");

        public ApprenticeDetailsApprovedPage(ScenarioContext context) : base(context) { }

        public DynamicHomePages ClickHome()
        {
            formCompletionHelper.ClickElement(ClickDynamicHomeLink);
            return new DynamicHomePages(context);
        }
    }
}