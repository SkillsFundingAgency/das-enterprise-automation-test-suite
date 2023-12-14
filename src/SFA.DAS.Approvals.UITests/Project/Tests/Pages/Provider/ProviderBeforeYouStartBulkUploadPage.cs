using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderBeforeYouStartBulkUploadPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By ContinueButton => By.Id("change-the-employer-button");

        protected override string PageTitle => "Using file upload";

        public ProviderBulkUploadCsvFilePage ContinueToUploadCsvFilePage()
        {
            Continue();
            return new ProviderBulkUploadCsvFilePage(context);
        }
    }
}