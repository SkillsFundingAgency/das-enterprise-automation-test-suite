using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class SummaryOfThisProviderPage : EmployerBasePage
    {
        protected override string PageTitle => "Contact details";

        protected override By PageHeader => By.CssSelector(".fiu-panel .govuk-heading-m");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SummaryOfThisProviderPage(ScenarioContext context) : base(context) => _context = context;

        public SummaryOfThisProviderPage RemoveFromFavourite()
        {
            formCompletionHelper.ClickElement(RemoveFavouriteSelector);
            return new SummaryOfThisProviderPage(_context);
        }

        public SummaryOfThisProviderPage AddToFavourite()
        {
            formCompletionHelper.ClickElement(AddFavouriteSelector);
            return new SummaryOfThisProviderPage(_context);
        }

        public EmployerFavouritesPage GoToEmployerFavouritesPage()
        {
            GoToBasket();
            return new EmployerFavouritesPage(_context);
        }
    }
}

