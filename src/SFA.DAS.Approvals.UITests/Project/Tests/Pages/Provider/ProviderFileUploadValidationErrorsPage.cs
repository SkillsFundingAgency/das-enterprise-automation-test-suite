using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderFileUploadValidationErrorsPage : ProviderBulkUploadCsvFilePage
    {
        protected override By PageHeader => By.ClassName("govuk-heading-l");
        
        protected override string PageTitle => "There is a problem with your CSV file";

        private By FileUploadErrorMessage => By.XPath("(//td[@class='govuk-table__cell'])[4]");

        public ProviderFileUploadValidationErrorsPage(ScenarioContext context) : base(context) { }
        
        public ProviderFileUploadValidationErrorsPage VerifyErrorMessage(string errorMessage)    
        {
            string featureFileErrorMessage = Regex.Replace(errorMessage, @"\s+", String.Empty);

            string fileUploadErrorMessage = Regex.Replace(pageInteractionHelper.GetText(FileUploadErrorMessage), @"\s+", String.Empty);

            int index = featureFileErrorMessage.Length < 80 ? featureFileErrorMessage.Length : 80;

            Assert.IsTrue(fileUploadErrorMessage.Contains(featureFileErrorMessage.Substring(0,index)));

            return new ProviderFileUploadValidationErrorsPage(context);
        }
    }
}
