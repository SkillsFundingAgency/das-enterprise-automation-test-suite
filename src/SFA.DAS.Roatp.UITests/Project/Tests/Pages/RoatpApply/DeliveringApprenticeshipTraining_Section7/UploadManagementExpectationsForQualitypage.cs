using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class UploadManagementExpectationsForQualitypage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your management hierarchy's expectations for quality and high standards in apprenticeship training";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        public UploadManagementExpectationsForQualitypage(ScenarioContext context) : base(context) => VerifyPage();

        public HowExpectationsAreMonitoredPage UploadManagementExpectationsForQuality()
        {
            UploadFile();
            return new HowExpectationsAreMonitoredPage(context);
        }

    }
}