using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.ConfigurationBuilder;
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
        private EmployerFavouritesPage _empFavpage;
        private GovUkYourSavedFavouritesPage _govukFavpage;
        private SummaryOfThisApprenticeshipPage _appsummaryPage;
        private SummaryOfThisProviderPage _providersummaryPage;
        private SignInPage _signInPage;
        private readonly CampaignsDataHelper _campaignsDataHelper;
        private readonly TabHelper _tabHelper;
        private readonly CampaignsConfig _campaignsConfig;
        private readonly ObjectContext _objectContext;

        public E2ESteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
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
                .GoToSearchResultsPage();
        }

        [When(@"the employer favourites multiple apprenticeship")]
        public void WhenTheEmployerFavouritesMultipleApprenticeship()
        {
            _searchResultsPage = _searchResultsPage.SearchApprenticeship("Business and Administration");
            _searchResultsPage = _searchResultsPage.SearchApprenticeship("IT");
            _searchResultsPage = _searchResultsPage.SearchApprenticeship("Construction");
            _empFavpage = _searchResultsPage.GoToEmployerFavouritesPage();
            _empFavpage.VerifyCount(3);
        }

        [Then(@"the favourites count is (.*)")]
        public void ThenTheFavouritesCountIs(int count) => _empFavpage.VerifyCount(count);

        [When(@"the employer favourites multiple provider")]
        public void WhenTheEmployerFavouritesMultipleProvider()
        {
            foreach (var item in _campaignsDataHelper.CourseId)
            {
                _objectContext.SetCourseId(item);
                _empFavpage = _empFavpage.AddProvider().SearchProvider().AddFavouriteProvider();
            }
        }

        [When(@"the employer favourites an apprenticeship")]
        public void WhenTheEmployerFavouritesAnApprenticeship()
        {
            _appsummaryPage = _searchResultsPage.SearchApprenticeship("Software").GoToSummaryOfThisApprenticeshipPage();
            _appsummaryPage.VerifyCount(1);
            _appsummaryPage = _appsummaryPage.RemoveFromFavourite();
            _appsummaryPage.VerifyCount(0);
            _appsummaryPage = _appsummaryPage.AddToFavourite();
            _appsummaryPage.VerifyCount(1);
        }

        [When(@"the employer favourites a provider")]
        public void WhenTheEmployerFavouritesAProvider()
        {
            _providersummaryPage = _appsummaryPage.SearchProvider().SearchProvider();
            _providersummaryPage.VerifyCount(2);
            _providersummaryPage = _providersummaryPage.RemoveFromFavourite();
            _providersummaryPage.VerifyCount(1);
            _providersummaryPage = _providersummaryPage.AddToFavourite();
            _providersummaryPage.VerifyCount(2);
        }

        [Then(@"the employer can delete the favourites")]
        public void ThenTheEmployerCanDeleteTheFavourites() => _providersummaryPage.GoToEmployerFavouritesPage().DeleteFavourites();

        [When(@"the employer deletes all favourites apprenticeships")]
        public void WhenTheEmployerDeletesAllFavouritesApprenticeships()
        {
            foreach (var item in _campaignsDataHelper.CourseId)
            {
                _objectContext.SetCourseId(item);
                _empFavpage = _empFavpage.DeleteApprenticeshipFavourites();
            }
        }

        [Then(@"the basket is empty")]
        public void ThenTheBasketIsEmpty() => new EmployerFavouritesPage(_context).VerifyEmptyBasket();

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

            _govukFavpage = new GovUkEmployerHomePage(_context).ViewSavedFavourites();
        }

        [When(@"the employer deletes the favourites")]
        public void WhenTheEmployerDeletesTheFavourites()
        {
            foreach (var item in _campaignsDataHelper.CourseId)
                _govukFavpage = _govukFavpage.RemoveFromFavourites(item).SelectYesAndContinue();
        }

        [Then(@"there are no items in the favourites")]
        public void ThenThereAreNoItemsInTheFavourites() => _tabHelper.OpenInNewTab(_campaignsConfig.CA_BaseUrl, _campaignsConfig.BasketView);

    }
}