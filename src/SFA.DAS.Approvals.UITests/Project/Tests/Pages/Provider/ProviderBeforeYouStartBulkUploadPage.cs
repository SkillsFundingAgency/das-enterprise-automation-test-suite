using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderBeforeYouStartBulkUploadPage : ApprovalsBasePage
    {
        protected override By ContinueButton => By.Id("change-the-employer-button");

        protected override string PageTitle => "Using file upload";

        public ProviderBeforeYouStartBulkUploadPage(ScenarioContext context) : base(context) { }

        public ProviderBulkUploadCsvFilePage ContinueToUploadCsvFilePage()
        {
            Continue();
            return new ProviderBulkUploadCsvFilePage(context);
        }
    }
}