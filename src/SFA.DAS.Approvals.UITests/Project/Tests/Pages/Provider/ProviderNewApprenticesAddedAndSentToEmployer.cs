using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderNewApprenticesAddedAndSentToEmployer : ApprovalsBasePage
    {
        protected readonly PageInteractionHelper _pageInteractionHelper;
        protected override string PageTitle => "New apprentices added and sent to employer(s) for approval";

        private By cohortsSaveTableRows => By.CssSelector("tbody tr");
        private By EmployerName => By.CssSelector("td.govuk-table__cell[data-label='EmployerName']");
        private By Cohort => By.CssSelector("td.govuk-table__cell[data-label='CohortReference']");
        private By NumberOfApprentices => By.CssSelector("td.govuk-table__cell[data-label='NumberOfApprenticeships']");

        public ProviderNewApprenticesAddedAndSentToEmployer(ScenarioContext _context) : base(_context)
        {
            _pageInteractionHelper = _context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public ProviderNewApprenticesAddedAndSentToEmployer VerifyCorrectInformationIsDisplayed(List<FileUploadReviewEmployerDetails> apprenticeList)
        {
            int counter = 0;
            var rows = pageInteractionHelper.FindElements(cohortsSaveTableRows);

            var flatennedList = apprenticeList
                .SelectMany(
                 x => x.CohortDetails,
                 (z, y) => new { z.EmployerName, z.AgreementId, z.CohortRef, y.NumberOfApprentices, CohortDetails = y })
                .ToList();

            foreach (var row in rows)
            {
                var actualEmployerName = row.FindElement(EmployerName).Text;
                var actualCohortRef = row.FindElement(Cohort).Text;
                var actualNoOfApprentices = row.FindElement(NumberOfApprentices).Text;

                var cohortDetails = flatennedList[counter].CohortDetails;
                var expectedEmployerName = flatennedList[counter].EmployerName;
                var expectedCohortRef = (cohortDetails.CohortRef == null || cohortDetails.CohortRef == "") ? actualCohortRef : cohortDetails.CohortRef;
                var expectedNoOfApprentices = cohortDetails.NumberOfApprentices.ToString();

                Assert.AreEqual(expectedEmployerName, actualEmployerName, "Validate correct employer name is displayed");
                Assert.AreEqual(expectedCohortRef, actualCohortRef, "Validate correct cohort reference is displayed");
                Assert.AreEqual(expectedNoOfApprentices, actualNoOfApprentices, "Validate correct no. of apprentices are displayed against cohort");

                counter++;
            }

            return this;
        }


    }
}
