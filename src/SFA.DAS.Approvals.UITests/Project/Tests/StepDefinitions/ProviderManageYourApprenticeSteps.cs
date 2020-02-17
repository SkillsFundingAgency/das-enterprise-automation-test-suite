using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;

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
        public void GivenAProviderHasNavigatedToManageYourApprenticePage()
        {
            _providerStepsHelper.GoToProviderHomePage()
                            .GoToProviderManageYourApprenticePage();
        }
        
        [When(@"the provider filters by '(.*)'")]
        public void WhenTheProviderFiltersBy(string filterselection)
        {
            _providerStepsHelper.FilterAndPaginate(filterselection);
        }
        
        [Then(@"the provider is presented with first page with no filters applied")]
        public void ThenTheProviderIsPresentedWithFirstPagewithNoFiltersApplied()
        {           
            var linkDisplayed = _providerStepsHelper.VerifyDownloadAllLinkIsDisplayed();

            Assert.IsTrue(linkDisplayed, "Download all data");

            Assert.IsTrue(linkDisplayed, "Download all data");
        }
    }
}
