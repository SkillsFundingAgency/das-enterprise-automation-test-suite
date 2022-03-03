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
            int rowCount = rows.Count;

            foreach (var cohort in apprenticeList[counter].CohortDetails)
            {
                if (counter < rowCount)
                {
                    foreach (var row in rows) 
                    {
                        var expectedEmployerName = apprenticeList[counter].EmployerName;
                        var expectedCohortRef = cohort.CohortRefText;
                        var expectedNoOfApprentices = cohort.NumberOfApprentices.ToString();

                        var actualEmployerName = row.FindElement(EmployerName).Text;
                        var actualCohortRef = row.FindElement(Cohort).Text;
                        var actualNoOfApprentices = row.FindElement(NumberOfApprentices).Text;

                        Assert.AreEqual(expectedEmployerName, actualEmployerName, "Validate correct employer name is displayed");
                        Assert.AreEqual(expectedCohortRef, actualCohortRef, "Validate correct cohort reference is displayed");
                        Assert.AreEqual(expectedNoOfApprentices, actualNoOfApprentices, "Validate correct no. of apprentices are displayed against cohort");

                        counter++;
                    }
                }
                else
                {
                    counter++;
                }

              
            }

            return this;
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
