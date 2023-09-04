using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderSelectsFilterAndPaginationOnManageYourApprenticePageSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;

        public ProviderSelectsFilterAndPaginationOnManageYourApprenticePageSteps(ScenarioContext context)
        {
            _context = context;
            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);
        }

        [Given(@"A Provider has navigated to Manage your apprentice page")]
        public void GivenAProviderHasNavigatedToManageYourApprenticePage() => _providerCommonStepsHelper.GoToProviderHomePage().GoToProviderManageYourApprenticePage();

        [When(@"the provider filters by '(.*)'")]
        public void WhenTheProviderFiltersBy(string filterselection) => new ProviderManageYourApprenticesPage(_context).FilterPagination(filterselection);

        [Then(@"the provider is presented with first page with no filters applied")]
        [Then(@"the user can download csv file")]
        public void ThenTheProviderIsPresentedWithFirstPagewithNoFiltersApplied() => Assert.IsTrue(new ProviderManageYourApprenticesPage(_context).DownloadAllDataLinkIsDisplayed(), "Download all data");

    }
}
