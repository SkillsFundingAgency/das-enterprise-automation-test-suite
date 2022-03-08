using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderNewApprenticeDetailsSavedSuccessfully : ApprovalsBasePage
    {
        protected readonly PageInteractionHelper _pageInteractionHelper;
        protected override string PageTitle => "New apprentice details saved successfully";
        private By cohortsSaveTable => By.CssSelector(".govuk-table__body");
        private By cohortsSaveTableRows => By.CssSelector("tbody tr");
        private By EmployerName => By.CssSelector("td.govuk-table__cell[data-label='EmployerName']");
        private By Cohort => By.CssSelector("td.govuk-table__cell[data-label='CohortReference']");
        private By NumberOfApprentices => By.CssSelector("td.govuk-table__cell[data-label='NumberOfApprenticeships']");

        public ProviderNewApprenticeDetailsSavedSuccessfully(ScenarioContext _context) : base(_context)
        {
            _pageInteractionHelper = _context.Get<PageInteractionHelper>();
            VerifyPage();

        }

        public ProviderNewApprenticeDetailsSavedSuccessfully VerifyCorrectInformationIsDisplayed(List<FileUploadReviewEmployerDetails> apprenticeList)
        {
            int counter = 0;
            var rows = pageInteractionHelper.FindElements(cohortsSaveTableRows);

            var flatennedList = apprenticeList
                .SelectMany(
                 x => x.CohortDetails, 
                 (z, y) => new { z.EmployerName, z.AgreementId, z.CohortRef, y.NumberOfApprentices, CohortDetails = y})
                .ToList();

            foreach (var row in rows)
            {
                var expectedEmployerName = flatennedList[counter].EmployerName;
                var cohortDetails = flatennedList[counter].CohortDetails;
                var actualEmployerName = row.FindElement(EmployerName).Text;              

                Assert.AreEqual(expectedEmployerName, actualEmployerName, "Validate correct employer name is displayed");
                ValidateRow(cohortDetails, row);

                counter++;
            }

            return this;
        }

        private void ValidateRow(FileUploadReviewCohortDetail cohortDetails, IWebElement row)
        {

                var expectedCohortRef = cohortDetails.CohortRef;
                var expectedNoOfApprentices = cohortDetails.NumberOfApprentices.ToString();

                var actualCohortRef = row.FindElement(Cohort).Text;
                var actualNoOfApprentices = row.FindElement(NumberOfApprentices).Text;

                Assert.AreEqual(expectedCohortRef, actualCohortRef, "Validate correct cohort reference is displayed");
                Assert.AreEqual(expectedNoOfApprentices, actualNoOfApprentices, "Validate correct no. of apprentices are displayed against cohort");

        }

        

    }

    #region Helper Classes

    public class FileUploadCohortsSaved
    {
        public string Employer { get; set; }
        public string Cohort { get; set; }
        public string NumberOfApprentices { get; set; }
    }

    # endregion
}
