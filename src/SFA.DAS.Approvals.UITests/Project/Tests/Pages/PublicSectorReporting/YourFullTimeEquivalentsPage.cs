using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class YourFullTimeEquivalentsPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Your full-time equivalents";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By NoOfFullTime => By.CssSelector("#z0__Answer");

        public YourFullTimeEquivalentsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReportYourProgressPage EnterFullTimeEmployeesDetails()
        {
            formCompletionHelper.EnterText(NoOfFullTime, dataHelper.NoofFullTimeEmployees);
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}