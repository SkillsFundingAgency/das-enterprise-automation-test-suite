using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderFileUploadValidationErrorsPage : ProviderBulkUploadCsvFilePage
    {
        protected override By PageHeader => By.ClassName("govuk-heading-l");

        protected override string PageTitle => "There is a problem with your CSV file";

        private static By FileUploadErrorMessage => By.XPath("(//td[@class='govuk-table__cell'])[4]");

        public ProviderFileUploadValidationErrorsPage(ScenarioContext context) : base(context) { }

        public string GetErrorMessage() => pageInteractionHelper.GetText(FileUploadErrorMessage)?.RemoveSpace();
    }
}
