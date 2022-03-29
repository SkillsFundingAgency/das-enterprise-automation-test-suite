using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderFileUploadValidationErrorsPage : ProviderBulkUploadCsvFilePage
    {
        protected override By PageHeader => By.ClassName("govuk-heading-l");
        protected override string PageTitle => "There is a problem with your CSV file";

        protected readonly PageInteractionHelper _pageInteractionHelper;        
        private By FileUploadErrorMessage => By.XPath("(//td[@class='govuk-table__cell'])[4]");
        private By ChooseFileButton => By.Id("attachment");
        private By UploadFileButton => By.Id("submit-upload-apprentices");


        public ProviderFileUploadValidationErrorsPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public ProviderFileUploadValidationErrorsPage VerifyErrorMessage(string errorMessage)    
        {
            string featureFileErrorMessage = Regex.Replace(errorMessage, @"\s+", String.Empty);
            string fileUploadErrorMessage = Regex.Replace(_pageInteractionHelper.GetText(FileUploadErrorMessage), @"\s+", String.Empty);
            int index = featureFileErrorMessage.Length < 80 ? featureFileErrorMessage.Length : 80;

            Assert.IsTrue(fileUploadErrorMessage.Contains(featureFileErrorMessage.Substring(0,index)));

            return new ProviderFileUploadValidationErrorsPage(context);
        }

        public ProviderBulkUploadCsvFilePage BackToEditProvidersContactDetailsPage()
        {
            formCompletionHelper.Click(BackLink);
            return new ProviderBulkUploadCsvFilePage(context);
        }

        public void UploadFile()
        {
            formCompletionHelper.EnterText(ChooseFileButton, fileLocation);
            formCompletionHelper.ClickElement(UploadFileButton);
        }
    }
}
