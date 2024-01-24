using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ApplicationCancelledPage : EIBasePage
    {
        protected override string PageTitle => "applications cancelled";

        private static string ExpectedPageTitle => "One application cancelled";

        private List<string> ExpectedPageTitles => new() { PageTitle, ExpectedPageTitle };

        protected static By ViewApplicationsSelector => By.CssSelector("#main-content .govuk-button");

        public ApplicationCancelledPage(ScenarioContext context) : base(context, false) => VerifyPage(() => pageInteractionHelper.FindElement(PageHeader), ExpectedPageTitles);

        public ViewApplicationsPage ViewApplications()
        {
            formCompletionHelper.ClickElement(ViewApplicationsSelector);

            return new ViewApplicationsPage(context);
        }
    }
}