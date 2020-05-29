using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class YourEmployeesPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Your employees";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By NoOfEmployees2019 => By.CssSelector("#z0__Answer");
        private By NoOfEmployees2020 => By.CssSelector("#z1__Answer");
        private By NoOfEmployees => By.CssSelector("#z2__Answer");

        public YourEmployeesPage(ScenarioContext context) : base(context) => _context = context;

        public ReportYourProgressPage EnterEmployeesDetails()
        {
            formCompletionHelper.EnterText(NoOfEmployees2019, dataHelper.NoofEmployees2019);
            formCompletionHelper.EnterText(NoOfEmployees2020, dataHelper.NoofEmployees2020);
            formCompletionHelper.EnterText(NoOfEmployees, dataHelper.NoofNewEmployees);
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}