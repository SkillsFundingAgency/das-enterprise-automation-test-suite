using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ManageYourLearnersPage : ApprovalsApprenticeBasePage
    {
        private readonly ManageYourApprenticePageHelper manageYourApprenticePageHelper;

        public ManageYourLearnersPage(ScenarioContext context) : base(context)
        {
            manageYourApprenticePageHelper = new ManageYourApprenticePageHelper(context);
        }
        protected override string PageTitle => "Manage your";

        protected override bool TakeFullScreenShot => false;

        private static By ApplyFilter => By.CssSelector("#main-content .govuk-button");

        

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

