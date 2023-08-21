using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderManageYourApprenticesPage : Navigate
    {
        protected override string PageTitle => "Manage your apprentices";

        protected override string Linktext => "Manage your apprentices";

        protected override bool TakeFullScreenShot => false;


        protected readonly ApprenticeDataHelper apprenticeDataHelper;

        public ProviderManageYourApprenticesPage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {            
            apprenticeDataHelper = context.GetValue<ApprenticeDataHelper>();

            manageYourApprenticePageHelper = new ManageYourApprenticePageHelper(context);

            VerifyPage();
        }

        private static By SelectFilterDropdown => By.Id("selectedStatus");
        private static By ApplyFilter => By.XPath("//button[contains(text(),'Apply filters')]");
        private static By ClearSearchAndFilters => By.PartialLinkText("Clear search");
        private static By DownloadAllDataLink => By.PartialLinkText("Download all data");
        private static By NextPageLink => By.PartialLinkText("Next");
        private static By SimplifiedPaymentsPilotFilter => By.Id("selectedPilotStatus");

        private readonly ManageYourApprenticePageHelper manageYourApprenticePageHelper;


        private bool DoesApprenticeExists(string name) => manageYourApprenticePageHelper.DoesApprenticeExists(name);

        public FilteredManageYourApprenticesPage SearchForApprentice(string apprenticeName)
        {
            DoesApprenticeExists(apprenticeName);

            return new FilteredManageYourApprenticesPage(context);
        }

        public ProviderApprenticeDetailsPage SelectViewCurrentApprenticeDetails()
        {
            manageYourApprenticePageHelper.SelectViewLiveApprenticeDetails(apprenticeDataHelper.ApprenticeFullName);

            return new ProviderApprenticeDetailsPage(context);
        }

        public ProviderManageYourApprenticesPage FilterPagination(string filterText)
        {
            formCompletionHelper.SelectFromDropDownByText(SelectFilterDropdown, filterText);

            formCompletionHelper.ClickElement(ApplyFilter);

            formCompletionHelper.ClickElement(NextPageLink);

            formCompletionHelper.ClickElement(ClearSearchAndFilters);

            return this;
        }

        public bool DownloadAllDataLinkIsDisplayed() => pageInteractionHelper.IsElementDisplayed(DownloadAllDataLink);

        public bool IsPaymentsPilotLearnerDisplayed(SimplifiedPaymentsPilot status)
        {
            ApplySimplifiedPaymentsPilotFilter(status);

            formCompletionHelper.ClickElement(ApplyFilter);

            return DoesApprenticeExists(apprenticeDataHelper.ApprenticeFullName);
        }

        private void ApplySimplifiedPaymentsPilotFilter(SimplifiedPaymentsPilot status) => formCompletionHelper.SelectFromDropDownByValue(SimplifiedPaymentsPilotFilter, status.ToString());

        public enum SimplifiedPaymentsPilot
        {
            All, 
            True,
            False
        }
    }
}
