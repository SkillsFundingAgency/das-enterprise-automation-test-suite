using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderNewApprenticeDetailsSavedSuccessfully : ApprovalsBasePage
    {
        private CommitmentsSqlDataHelper _commitmentsSqlDataHelper;

        protected override string PageTitle => "New apprentice details saved successfully";
        private By cohortsSaveTableRows => By.CssSelector("tbody tr");
        private By EmployerName => By.CssSelector("td.govuk-table__cell[data-label='EmployerName']");
        private By Cohort => By.CssSelector("td.govuk-table__cell[data-label='CohortReference']");
        private By NumberOfApprentices => By.CssSelector("td.govuk-table__cell[data-label='NumberOfApprenticeships']");

        public ProviderNewApprenticeDetailsSavedSuccessfully(ScenarioContext context) : base(context) {
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
        }

        public ProviderNewApprenticeDetailsSavedSuccessfully VerifyCorrectInformationIsDisplayed(List<FileUploadReviewEmployerDetails> apprenticeList)
        {
            var rows = pageInteractionHelper.FindElements(cohortsSaveTableRows);

            var apprentices = objectContext.GetBulkuploadApprentices();
            var groups = apprentices.GroupBy(x => new { x.AgreementId, x.CohortRef })
                .Where(y => string.IsNullOrWhiteSpace(y.Key.CohortRef))
                .Select(z =>
                {
                    var cohortRef = _commitmentsSqlDataHelper.GetNewcohortReferenceWithNoContinuation(z.First().ULN, context.ScenarioInfo.Title);
                    return new { cohortRef, z.Key.AgreementId };
                }).ToList();


            var flatennedList = apprenticeList
                .SelectMany(
                 x => x.CohortDetails,
                 (z, y) => new { z.EmployerName, z.AgreementId, CohortDetails = y })
                .ToList();



            foreach (var flattenedRow in flatennedList)
            {
                if (string.IsNullOrWhiteSpace(flattenedRow.CohortDetails.CohortRef))
                {
                     var foundGroupd = groups.First(x => x.AgreementId == flattenedRow.AgreementId);
                    flattenedRow.CohortDetails.CohortRef = foundGroupd.cohortRef;
                }

                var headerTextXpathQuery = $"//td[contains(text(),'{flattenedRow.CohortDetails.CohortRef}')]";
                var header = pageInteractionHelper.FindElement(By.XPath(headerTextXpathQuery));
                var parent = header.FindElement(By.XPath(".."));
                var employerName = parent.FindElement(EmployerName);
                var cohort = parent.FindElement(Cohort);
                var numberOfApprentices = parent.FindElement(NumberOfApprentices);
                
                pageInteractionHelper.VerifyText(flattenedRow.EmployerName.RemoveSpace(), pageInteractionHelper.GetText(employerName).RemoveSpace());
                pageInteractionHelper.VerifyText(flattenedRow.CohortDetails.CohortRefText, pageInteractionHelper.GetText(cohort));
                pageInteractionHelper.VerifyText(flattenedRow.CohortDetails.NumberOfApprentices.ToString(), pageInteractionHelper.GetText(numberOfApprentices));

                objectContext.SetCohortReferenceList(flattenedRow.CohortDetails.CohortRefText);
            }

            return this;
        }
    }
}
