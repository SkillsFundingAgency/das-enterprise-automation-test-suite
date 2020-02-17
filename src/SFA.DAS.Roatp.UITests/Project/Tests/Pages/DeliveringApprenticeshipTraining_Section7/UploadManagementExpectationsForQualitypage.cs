using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class UploadManagementExpectationsForQualitypage : RoatpBasePage
    {
        protected override string PageTitle => "Upload your management hierarchy's expectations for quality and high standards in apprenticeship training";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public UploadManagementExpectationsForQualitypage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public HowExpectationsAreMonitoredPage UploadManagementExpectationsForQuality()
        {
            UploadFile();
            return new HowExpectationsAreMonitoredPage(_context);
        }

    }
}