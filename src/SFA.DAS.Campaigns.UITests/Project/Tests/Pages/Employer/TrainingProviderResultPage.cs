using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class TrainingProviderResultPage : EmployerBasePage
    {
        protected override string PageTitle => "TRAINING PROVIDER RESULTS";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TrainingProviderResultPage(ScenarioContext context) : base(context) => _context = context;

        public EmployerFavouritesPage AddFavouriteProvider()
        {
            AddFavourite((a) => campaignsDataHelper.ProviderId.Add(a));
            GoToBasket();
            return new EmployerFavouritesPage(_context);
        }
    }
}

