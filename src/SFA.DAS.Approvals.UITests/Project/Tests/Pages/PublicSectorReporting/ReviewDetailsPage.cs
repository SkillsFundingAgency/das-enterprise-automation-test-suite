using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ReviewDetailsPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Review details";

        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        protected override By ContinueButton => By.CssSelector("#report-summary-continue");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ReviewDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfirmationPage GoToConfirmationPage()
        {
            Continue();
            return new ConfirmationPage(_context);
        }
    }
}