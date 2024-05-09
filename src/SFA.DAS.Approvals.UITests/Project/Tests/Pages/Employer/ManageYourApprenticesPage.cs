using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ManageYourApprenticesPage(ScenarioContext context) : ApprovalsApprenticeBasePage(context)
    {
        protected override string PageTitle => "Manage your apprentices";

        protected override bool TakeFullScreenShot => false;

        private static By ApplyFilter => By.CssSelector("#main-content .govuk-button");

        private static By DownloadFilteredDataLink => By.PartialLinkText("Download filtered data");

        private readonly ManageYourApprenticePageHelper manageYourApprenticePageHelper = new(context);

        public ApprenticeDetailsPage SelectViewCurrentApprenticeDetails()
        {
            manageYourApprenticePageHelper.SelectViewLiveApprenticeDetails(apprenticeDataHelper.ApprenticeFullName);

            return new ApprenticeDetailsPage(context);
        }

        public FilteredManageYourApprenticesPage SearchForApprentice(string apprenticeName)
        {
            DoesApprenticeExists(apprenticeName);

            return new FilteredManageYourApprenticesPage(context);
        }

        public void VerifyApprenticeExists() => DoesApprenticeExists(editedApprenticeDataHelper.ApprenticeEditedFullName);

        public ManageYourApprenticesPage Filter(string dropDownSelector, string filterText)
        {
            formCompletionHelper.SelectFromDropDownByText(By.Id(dropDownSelector), filterText);

            formCompletionHelper.ClickElement(ApplyFilter);

            return new ManageYourApprenticesPage(context);
        }

        internal ApprenticeDetailsPage SelectApprentices(string status)
        {
            SearchForApprentice(apprenticeDataHelper.ApprenticeFirstname);

            tableRowHelper.SelectRowFromTable(apprenticeDataHelper.ApprenticeFullName, status);

            return new ApprenticeDetailsPage(context);
        }

        internal ManageYourApprenticesPage ClickOnDownloadFilteredDataCSVAndWaitForDownload()
        {
            formCompletionHelper.ClickElement(DownloadFilteredDataLink);
            return new ManageYourApprenticesPage(context);
        }

        public bool DownloadFilteredDataLinkIsDisplayed() => pageInteractionHelper.IsElementDisplayed(DownloadFilteredDataLink);

        private bool DoesApprenticeExists(string name) => manageYourApprenticePageHelper.DoesApprenticeExists(name);

        public void DoesDownloadFileExistAndValidateRowCount()
        {

            var downloadedFileName = FrameworkHelpers.FileHelper.GetDownloadedFileName("Manageyourapprentices", "csv");
            Assert.IsNotEmpty(downloadedFileName);

            var filteredApprenticesOnPage = tableRowHelper.GetTableRows();
            filteredApprenticesOnPage = filteredApprenticesOnPage.Where(row =>
            {
                if (DateTime.TryParse(row["Planned end date"], out DateTime plannedEndDate))
                {
                    return plannedEndDate >= DateTime.Now.AddYears(-1);
                }
                return false;
            }).ToList();

            Assert.IsTrue(FrameworkHelpers.FileHelper.CountCsvFileRows(downloadedFileName) - 2 == filteredApprenticesOnPage.Count);
        }

    }
}

