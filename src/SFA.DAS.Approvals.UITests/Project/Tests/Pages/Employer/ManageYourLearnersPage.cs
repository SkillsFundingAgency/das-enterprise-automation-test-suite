using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ManageYourLearnersPage(ScenarioContext context) : ApprovalsApprenticeBasePage(context)
    {
        protected override string PageTitle => "Manage your learners";

        protected override bool TakeFullScreenShot => false;

        private static By ApplyFilter => By.CssSelector("#main-content .govuk-button");

        private readonly ManageYourApprenticePageHelper manageYourApprenticePageHelper = new(context);

        public ApprenticeDetailsPage SelectViewCurrentApprenticeDetails()
        {
            manageYourApprenticePageHelper.SelectViewLiveApprenticeDetails(apprenticeDataHelper.ApprenticeFullName);

            return new ApprenticeDetailsPage(context);
        }

        public FilteredManageYourLearnersPage SearchForApprentice(string apprenticeName)
        {
            DoesApprenticeExists(apprenticeName);

            return new FilteredManageYourLearnersPage(context);
        }

        public void VerifyApprenticeExists() => DoesApprenticeExists(editedApprenticeDataHelper.ApprenticeEditedFullName);

        public ManageYourLearnersPage Filter(string dropDownSelector, string filterText)
        {
            formCompletionHelper.SelectFromDropDownByText(By.Id(dropDownSelector), filterText);

            formCompletionHelper.ClickElement(ApplyFilter);

            return new ManageYourLearnersPage(context);
        }

        internal ApprenticeDetailsPage SelectApprentices(string status)
        {
            SearchForApprentice(apprenticeDataHelper.ApprenticeFirstname);

            tableRowHelper.SelectRowFromTable(apprenticeDataHelper.ApprenticeFullName, status);

            return new ApprenticeDetailsPage(context);
        }

        internal ManageYourLearnersPage ClickOnDownloadFilteredDataCSVAndWaitForDownload()
        {
            manageYourApprenticePageHelper.ClickOnDownloadFilteredDataCSVAndWaitForDownload();

            return new ManageYourLearnersPage(context);
        }

        public bool DownloadFilteredDataLinkIsDisplayed() => manageYourApprenticePageHelper.DownloadFilteredDataLinkIsDisplayed();

        private bool DoesApprenticeExists(string name) => manageYourApprenticePageHelper.DoesApprenticeExists(name);

        public void DoesDownloadFileExistAndValidateRowCount() => manageYourApprenticePageHelper.DoesDownloadFileExistAndValidateRowCount();
    }
}

