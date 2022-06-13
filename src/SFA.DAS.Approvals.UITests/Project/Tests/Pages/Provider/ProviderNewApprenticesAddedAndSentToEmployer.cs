using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderNewApprenticesAddedAndSentToEmployer : ApprovalsBasePage
    {
        private CommitmentsSqlDataHelper _commitmentsSqlDataHelper;

        protected readonly PageInteractionHelper _pageInteractionHelper;
        protected override string PageTitle => "New apprentices added and sent to employer(s) for approval";
        private readonly ObjectContext _objectContext;

        private By cohortsSaveTableRows => By.CssSelector("tbody tr");
        private By EmployerName => By.CssSelector("td.govuk-table__cell[data-label='EmployerName']");
        private By Cohort => By.CssSelector("td.govuk-table__cell[data-label='CohortReference']");
        private By NumberOfApprentices => By.CssSelector("td.govuk-table__cell[data-label='NumberOfApprenticeships']");

        public ProviderNewApprenticesAddedAndSentToEmployer(ScenarioContext _context) : base(_context)
        {
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
            _pageInteractionHelper = _context.Get<PageInteractionHelper>();
            _objectContext = _context.Get<ObjectContext>();
            VerifyPage();
        }

        public ProviderNewApprenticesAddedAndSentToEmployer VerifyCorrectInformationIsDisplayed(List<FileUploadReviewEmployerDetails> apprenticeList)
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

                pageInteractionHelper.VerifyText(Regex.Replace(flattenedRow.EmployerName, @"\s+", ""), Regex.Replace(pageInteractionHelper.GetText(employerName), @"\s+", ""));
                pageInteractionHelper.VerifyText(flattenedRow.CohortDetails.CohortRefText, pageInteractionHelper.GetText(cohort));
                pageInteractionHelper.VerifyText(flattenedRow.CohortDetails.NumberOfApprentices.ToString(), pageInteractionHelper.GetText(numberOfApprentices));

                objectContext.SetCohortReferenceList(flattenedRow.CohortDetails.CohortRefText);
            }

            return this;
        }


    }
}
