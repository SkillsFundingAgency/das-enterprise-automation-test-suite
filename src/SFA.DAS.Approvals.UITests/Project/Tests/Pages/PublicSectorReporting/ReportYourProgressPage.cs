using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class ReportYourProgressPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Reporting your progress towards the public sector apprenticeship target";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Question Links
        private static string OrganisationName => "Your organisation's name";
        private static string TotalNumberOfEmployees => "Total number of employees";
        private static string Employees => "Number of employees who work in England";
        private static string Apprentices => "Number of apprentices who work in England";
        private static By SchoolEmployees => By.CssSelector("a[href*='SchoolsEmployees']");
        private static By SchoolApprentices => By.CssSelector("a[href*='SchoolsApprentices']");
        private static string Review => "Review and submit answers";
        #endregion

        public ReportYourProgressPage(ScenarioContext context) : base(context) { }

        public YourOrganisationNamePage GoToYourOrganisationNamePage()
        {
            formCompletionHelper.ClickLinkByText(OrganisationName);
            return new YourOrganisationNamePage(context);
        }

        public TotalNumberOfEmployeesPage GoToTotalNumberOfEmployeesPage()
        {
            formCompletionHelper.ClickLinkByText(TotalNumberOfEmployees);
            return new TotalNumberOfEmployeesPage(context);
        }

        public YourEmployeesPage GoToYourEmployeesPage()
        {
            formCompletionHelper.ClickLinkByText(Employees);
            return new YourEmployeesPage(context);
        }
        public YourApprenticesPage GoToYourApprenticesPage()
        {
            formCompletionHelper.ClickLinkByText(Apprentices);
            return new YourApprenticesPage(context);
        }
        public YourSchoolEmployeesPage GoToYourSchoolEmployeesPage()
        {
            formCompletionHelper.Click(SchoolEmployees);
            return new YourSchoolEmployeesPage(context);
        }
        public YourSchoolApprenticesPage GoToYourSchoolApprenticesPage()
        {
            formCompletionHelper.Click(SchoolApprentices);
            return new YourSchoolApprenticesPage(context);
        }
        public ReviewDetailsPage GoToReviewPage()
        {
            formCompletionHelper.ClickLinkByText(Review);
            return new ReviewDetailsPage(context);
        }
    }
}