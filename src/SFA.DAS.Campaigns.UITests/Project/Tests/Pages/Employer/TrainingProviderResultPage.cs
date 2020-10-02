using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class TrainingProviderResultPage : EmployerBasePage
    {
        protected override string PageTitle => "Find a training provider";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Provider => By.CssSelector($".das-search-result a[href*='ukprn={objectContext.GetProviderId()}&apprenticeshipId={objectContext.GetCourseId()}&LocationId={objectContext.GetProviderLocationId()}']");

        public TrainingProviderResultPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

            public EmployerFavouritesPage AddFavouriteProvider()
        {
            AddFavourite();
            GoToBasket();
            return new EmployerFavouritesPage(_context);
        }

        public SummaryOfThisProviderPage SearchProvider()
        {
            AddFavourite();
            formCompletionHelper.ClickElement(Provider);
            return new SummaryOfThisProviderPage(_context);
        }

        private void AddFavourite() => AddFavourite((a) =>
        {
            campaignsDataHelper.ProviderId.Add(a);
            var x = a.Split(",");
            objectContext.SetProviderId(x[0]);
            objectContext.SetProviderLocationId(x[1]);
        }, (e) => campaignsDataHelper.GetRandomElementFromListOfElements(e));
    }
}

