using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
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
        private YourSavedFavouritesPage _favpage;
        private SignInPage _signInPage;
        private readonly CampaignsDataHelper _campaignsDataHelper;
        private readonly TabHelper _tabHelper;
        private readonly CampaignsConfig _campaignsConfig;

        public E2ESteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
            _campaignsDataHelper = context.Get<CampaignsDataHelper>();
            _tabHelper = context.Get<TabHelper>();
            _campaignsConfig = context.GetCampaignsConfig<CampaignsConfig>();
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

            _favpage = new EmployerGovUkHomePage(_context).ViewSavedFavourites();
        }

        [When(@"the employer deletes the favourites")]
        public void WhenTheEmployerDeletesTheFavourites()
        {
            foreach (var item in _campaignsDataHelper.CourseId)
            {
                _favpage = _favpage.RemoveFromFavourites(item).SelectYesAndContinue();
            }
        }

        [Then(@"there are no items in the favourites")]
        public void ThenThereAreNoItemsInTheFavourites()
        {
            var uri = new Uri(new Uri(_campaignsConfig.CA_BaseUrl), "/Basket/View").AbsoluteUri;

            _tabHelper.OpenInNewTab(uri);

            new EmployerFavouritesPage(_context).VerifyEmptyBasket();
        }
    }
}
