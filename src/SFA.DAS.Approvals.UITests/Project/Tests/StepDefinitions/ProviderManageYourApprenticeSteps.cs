using TechTalk.SpecFlow;
using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderSelectsFilterAndPaginationOnManageYourApprenticePageSteps
    {
        private readonly ProviderStepsHelper _providerStepsHelper;
        
        public ProviderSelectsFilterAndPaginationOnManageYourApprenticePageSteps(ScenarioContext context) => _providerStepsHelper = new ProviderStepsHelper(context); 

        [Given(@"A Provider has navigated to Manage your apprentice page")]
        public void GivenAProviderHasNavigatedToManageYourApprenticePage() => _providerStepsHelper.GoToProviderHomePage().GoToProviderManageYourApprenticePage();
        
        [When(@"the provider filters by '(.*)'")]
        public void WhenTheProviderFiltersBy(string filterselection) => _providerStepsHelper.FilterAndPaginate(filterselection);
        
        [Then(@"the provider is presented with first page with no filters applied")]
        public void ThenTheProviderIsPresentedWithFirstPagewithNoFiltersApplied() => Assert.IsTrue(_providerStepsHelper.VerifyDownloadAllLinkIsDisplayed(), "Download all data");
    }
}
