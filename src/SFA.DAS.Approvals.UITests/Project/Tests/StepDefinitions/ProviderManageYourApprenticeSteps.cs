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
        private readonly ProviderStepsHelper _providerStepsHelper;

        public ProviderSelectsFilterAndPaginationOnManageYourApprenticePageSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(context);
        }

        [Given(@"A Provider has navigated to Manage your apprentice page")]
        public void GivenAProviderHasNavigatedToManageYourApprenticePage() => _providerStepsHelper.GoToProviderHomePage().GoToProviderManageYourApprenticePage();

        [When(@"the provider filters by '(.*)'")]
        public void WhenTheProviderFiltersBy(string filterselection) => new ProviderManageYourApprenticesPage(_context).FilterPagination(filterselection);

        [Then(@"the provider is presented with first page with no filters applied")]
        public void ThenTheProviderIsPresentedWithFirstPagewithNoFiltersApplied() => Assert.IsTrue(_providerStepsHelper.VerifyDownloadAllLinkIsDisplayed(), "Download all data");
    }
}
