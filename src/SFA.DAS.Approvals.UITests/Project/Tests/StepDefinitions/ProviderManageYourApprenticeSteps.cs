using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderSelectsFilterAndPaginationOnManageYourApprenticePageSteps(ScenarioContext context)
    {
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper = new(context);
        private ProviderManageYourApprenticesPage _providerManageYourApprenticesPage;

        [Given(@"A Provider has navigated to Manage your apprentice page")]
        public void GivenAProviderHasNavigatedToManageYourApprenticePage()
        {
            _providerManageYourApprenticesPage = _providerCommonStepsHelper.GoToProviderHomePage().GoToProviderManageYourApprenticePage();
        }

        [When(@"the provider filters by '(.*)'")]
        public void WhenTheProviderFiltersBy(string filterselection) => new ProviderManageYourApprenticesPage(context).FilterPagination(filterselection);

        [Then(@"the provider is presented with first page with no filters applied")]
        [Then(@"the user can download csv file")]
        public void ThenTheProviderIsPresentedWithFirstPagewithNoFiltersApplied() => Assert.IsTrue(new ProviderManageYourApprenticesPage(context).DownloadAllDataLinkIsDisplayed(), "Download all data");

        [Then("Provider is able to download the results in a csv file")]
        public void ThenProviderCanDownloadResultsInCSVFile()
        {
            _providerManageYourApprenticesPage.Filter("selectedStatus", "Live");
            _providerManageYourApprenticesPage.Filter("selectedApprenticeConfirmation", "Confirmed");
            _providerManageYourApprenticesPage.ClickOnDownloadFilteredDataCSVAndWaitForDownload();
        }

        [Then("Provider can confirm number of rows in Apprentices csv file")]
        public void ThenProviderConfirmsNumberOfRowsInApprenticeCSV()
        {
            _providerManageYourApprenticesPage.DoesDownloadFileExistAndValidateRowCount();
        }
    }
}
