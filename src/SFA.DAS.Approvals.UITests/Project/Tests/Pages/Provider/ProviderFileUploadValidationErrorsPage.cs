using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderFileUploadValidationErrorsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "There is a problem with your CSV file";
        protected readonly PageInteractionHelper _pageInteractionHelper;
        private By TableCells => By.ClassName("govuk-table__row");


        public ProviderFileUploadValidationErrorsPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public ProviderBulkUploadCsvFilePage VerifyErrorMessage(string errorMessage)
        {
            var fileUploadErrorMessage = _pageInteractionHelper.GetText(By.XPath("(//td[@class='govuk-table__cell'])[4]"));
            if (!errorMessage.Equals(fileUploadErrorMessage))
            {
                throw new Exception($"Expected message '{fileUploadErrorMessage}' but the message from feature file : '{errorMessage}' is not correct");
            }
           
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
