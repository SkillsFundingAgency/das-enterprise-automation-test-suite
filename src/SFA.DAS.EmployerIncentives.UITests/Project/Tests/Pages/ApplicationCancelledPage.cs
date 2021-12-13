using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ApplicationCancelledPage : EIBasePage
    {
        protected override string PageTitle => "applications cancelled";

        protected By ViewApplicationsSelector => By.CssSelector("#main-content .govuk-button");

        public ApplicationCancelledPage(ScenarioContext context) : base(context)  { }

        public ViewApplicationsPage ViewApplications()
        {
            formCompletionHelper.ClickElement(ViewApplicationsSelector);

            return new ViewApplicationsPage(_context);
        }
    }
}