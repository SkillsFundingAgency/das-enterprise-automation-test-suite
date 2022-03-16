using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderFileUploadValidationErrorsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "There is a problem with your CSV file";
        protected readonly PageInteractionHelper _pageInteractionHelper;        
        private By FileUploadErrorMessage => By.XPath("(//td[@class='govuk-table__cell'])[4]");

        public ProviderFileUploadValidationErrorsPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public ProviderBulkUploadCsvFilePage VerifyErrorMessage(string errorMessage)    
        {
            //Method 1
            //string featureFileErrorMessage = Regex.Replace(errorMessage, @"\s+", String.Empty);
            //string fileUploadErrorMessage = Regex.Replace(_pageInteractionHelper.GetText(FileUploadErrorMessage), @"\s+", String.Empty);         

            //Method 2
            string featureFileErrorMessage = errorMessage.Replace("\n", "").Replace("\r", "");
            string fileUploadErrorMessage = _pageInteractionHelper.GetText(FileUploadErrorMessage).Replace("\n", "").Replace("\r", "");         

            Assert.AreEqual(featureFileErrorMessage, fileUploadErrorMessage);

            formCompletionHelper.Click(BackLink);
            return new ProviderBulkUploadCsvFilePage(context);
        }

        public ProviderBulkUploadCsvFilePage BackToEditProvidersContactDetailsPage()
        {
            formCompletionHelper.Click(BackLink);
            return new ProviderBulkUploadCsvFilePage(context);
        }
    }
}
