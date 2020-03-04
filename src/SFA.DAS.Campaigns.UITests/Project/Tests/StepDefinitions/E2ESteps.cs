using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class E2ESteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private readonly ScenarioContext _context;
        private SearchResultsPage _searchResultsPage;
        private SignInPage _signInPage;

        public E2ESteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
        }


        [Given(@"the employer searches for an apprenticeship")]
        public void GivenTheEmployerSearchesForAnApprenticeship()
        {
            _searchResultsPage = 
                _stepsHelper
                .GoToFireItUpHomePage()
                .NavigateToEmployerHubPage()
                .NavigateToFindAnApprenticeshipPage()
                .SearchApprenticeship();
        }

        [When(@"the employer shortlists favourite apprenticeship and provider")]
        public void WhenTheEmployerShortlistsFavouriteApprenticeshipAndProvider()
        {
            _signInPage = 
                _searchResultsPage
                .AddFavouriteApprenticeship()
                .AddProvider()
                .SearchProvider()
                .AddFavouriteProvider()
                .CreateAnAccount()
                .CreateAnAccountOnGovUk();
        }

        [Then(@"the favourites are saved in gov uk account")]
        public void ThenTheFavouritesAreSavedInGovUkAccount()
        {
            _signInPage.Login(_context.GetUser<CampaingnsEmployerUser>());
        }


    }
}
