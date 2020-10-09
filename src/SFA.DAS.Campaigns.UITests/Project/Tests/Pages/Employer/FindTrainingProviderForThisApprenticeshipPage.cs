using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class FindTrainingProviderForThisApprenticeshipPage : EmployerBasePage
    {
        protected override string PageTitle => "Find a training provider for this apprenticeship";

        protected override By PageHeader => By.CssSelector(".fiu-panel__heading");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Postcode => By.CssSelector("#Postcode");

        private By ProviderSearchButton => By.CssSelector("#employer-provider-search");

        public FindTrainingProviderForThisApprenticeshipPage(ScenarioContext context) : base(context) => _context = context;

        public TrainingProviderResultPage SearchProvider()
        {
            formCompletionHelper.EnterText(Postcode, campaignsDataHelper.ProviderPostcode);
            formCompletionHelper.ClickElement(ProviderSearchButton);
            return new TrainingProviderResultPage(_context);
        }

        public FindTrainingProviderForThisApprenticeshipPage RemoveFromFavourite()
        {
            formCompletionHelper.ClickElement(RemoveFavouriteSelector);
            return new FindTrainingProviderForThisApprenticeshipPage(_context);
        }

        public FindTrainingProviderForThisApprenticeshipPage AddToFavourite()
        {
            formCompletionHelper.ClickElement(AddFavouriteSelector);
            return new FindTrainingProviderForThisApprenticeshipPage(_context);
        }
    }
}

