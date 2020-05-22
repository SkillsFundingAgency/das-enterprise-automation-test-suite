using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class YourEmployeesPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Your employees";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public YourEmployeesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReportYourProgressPage EnterEmployeesDetails()
        {
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Number of employees who were working in England on 31 March 2019", dataHelper.NoofEmployees2019);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Number of employees who were working in England on 31 March 2020", dataHelper.NoofEmployees2020);
            formCompletionHelper.EnterTextByLabel(LabelCssSelector, "Number of new employees who started working for you in England between 1 April 2019 to 31 March 2020", dataHelper.NoofNewEmployees);
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}