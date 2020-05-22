using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class PublicSectorReportingHomePage : InterimPublicSectorReportingHomePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By RadioLabels => By.CssSelector("label");

        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        public PublicSectorReportingHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            VerifyPage();
        }

        public AnnualApprenticeshipReturnPage CreateNewReport()
        {
            SelectRadioOptionByText("Create a new report");
            return new AnnualApprenticeshipReturnPage(_context);
        }

        public SubmittedReportspage ViewSubmittedReport()
        {
            SelectRadioOptionByText("View a submitted report");
            return new SubmittedReportspage(_context);
        }

        internal FinancePage GoToFinancePage() => new FinancePage(_context, true);
    }
}