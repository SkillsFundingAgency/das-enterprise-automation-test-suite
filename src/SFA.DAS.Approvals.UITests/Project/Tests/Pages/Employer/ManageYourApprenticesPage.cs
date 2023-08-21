using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ManageYourApprenticesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Manage your apprentices";

        protected override bool TakeFullScreenShot => false;

        private static By SelectFilterDropdown => By.Id("selectedStatus");

        private static By ApplyFilter => By.CssSelector("#main-content .govuk-button");

        private static By DownloadFilteredDataLink => By.PartialLinkText("Download filtered data");

        private readonly ManageYourApprenticePageHelper manageYourApprenticePageHelper;

        public ManageYourApprenticesPage(ScenarioContext context) : base(context) => manageYourApprenticePageHelper = new ManageYourApprenticePageHelper(context);

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

        public ManageYourApprenticesPage Filter(string filterText)
        {
            formCompletionHelper.SelectFromDropDownByText(SelectFilterDropdown, filterText);

            formCompletionHelper.ClickElement(ApplyFilter);

            return new ManageYourApprenticesPage(context);
        }

        internal ApprenticeDetailsPage SelectApprentices(string status)
        {
            SearchForApprentice(apprenticeDataHelper.ApprenticeFirstname);

            tableRowHelper.SelectRowFromTable(apprenticeDataHelper.ApprenticeFullName, status);

            return new ApprenticeDetailsPage(context);
        }

        public bool DownloadFilteredDataLinkIsDisplayed() => pageInteractionHelper.IsElementDisplayed(DownloadFilteredDataLink);

        private bool DoesApprenticeExists(string name) => manageYourApprenticePageHelper.DoesApprenticeExists(name);

    }
}

