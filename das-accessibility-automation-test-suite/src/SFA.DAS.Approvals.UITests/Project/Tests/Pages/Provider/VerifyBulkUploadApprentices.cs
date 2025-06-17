using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.BulkUpload;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public interface IVerifyBulkUploadApprentices
    {
        public void VerifyCorrectInformationIsDisplayed(List<FileUploadReviewEmployerDetails> apprenticeList);
    }

    public sealed class VerifyBulkUploadApprentices(ScenarioContext context) : InitialiseBasePage(context), IVerifyBulkUploadApprentices
    {
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper = context.Get<CommitmentsSqlDataHelper>();

        private static By CohortsSaveTableRows => By.CssSelector("tbody tr");
        private static By EmployerName => By.CssSelector("td.govuk-table__cell[data-label='EmployerName']");
        private static By Cohort => By.CssSelector("td.govuk-table__cell[data-label='CohortReference']");
        private static By NumberOfApprentices => By.CssSelector("td.govuk-table__cell[data-label='NumberOfApprenticeships']");

        public void VerifyCorrectInformationIsDisplayed(List<FileUploadReviewEmployerDetails> apprenticeList)
        {
            var rows = pageInteractionHelper.FindElements(CohortsSaveTableRows);

            var apprentices = objectContext.GetBulkuploadApprentices();
            var groups = apprentices.GroupBy(x => new { x.AgreementId, x.CohortRef })
                .Where(y => string.IsNullOrWhiteSpace(y.Key.CohortRef))
                .Select(z =>
                {
                    var cohortRef = _commitmentsSqlDataHelper.GetNewcohortReferenceWithNoContinuation(z.First().ULN);
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

                pageInteractionHelper.VerifyText(flattenedRow.EmployerName.RemoveSpace(), UI.FrameworkHelpers.PageInteractionHelper.GetText(employerName).RemoveSpace());
                pageInteractionHelper.VerifyText(flattenedRow.CohortDetails.CohortRefText, UI.FrameworkHelpers.PageInteractionHelper.GetText(cohort));
                pageInteractionHelper.VerifyText(flattenedRow.CohortDetails.NumberOfApprentices.ToString(), UI.FrameworkHelpers.PageInteractionHelper.GetText(numberOfApprentices));

                objectContext.SetCohortReferenceList(flattenedRow.CohortDetails.CohortRefText);
            }
        }
    }
}
