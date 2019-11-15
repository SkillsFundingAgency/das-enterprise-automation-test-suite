using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    internal class ApprenticeshipSearchResultPage:BasePage
    {
        protected override string PageTitle => "";
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RandomDataGenerator _randomDataGenerator;
        #endregion

        #region Constants
        private const string ExpectedHelpShapeTheirCareerHeader = "REGSITER MY INTEREST";
        private const string ExpectedApprenticeshipSummaryHeader = "Summary of this apprenticeship";
        private const string ProviderPostCode = "CV1 4HS";
        #endregion

        #region Page Objects Elements
        // Hd to use xpath because duplicate id were present on page
        private readonly By _helpShapeTheirCareerHeader = By.ClassName("heading-xl");
        private readonly By _actualSummaryHeader = By.ClassName("heading-l");
        private readonly By _apprenticeship =By.XPath("(//a[@class='link das-search-result__heading-link'])[4]");
        private readonly By _postcode =By.Id("Postcode");
        private readonly By _providerSearchButton=By.Id("employer-provider-search");
        
        private readonly By _favouriteIconWithApprenticeships = By.XPath("//span[@class='favourites-link__text']");
        #endregion
        public ApprenticeshipSearchResultPage(ScenarioContext context): base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _randomDataGenerator = context.Get<RandomDataGenerator>();

         }

        public SummeryOfThisApprenticeshipPage SelectTheApprenticeshipFromSearchResult()
        {
            _formCompletionHelper.ClickElement(_apprenticeship);
            return new SummeryOfThisApprenticeshipPage(_context);
        }

        public void ClickOnTheFavouriteIconWithApprenticeship()
        {
            _formCompletionHelper.ClickElement(_favouriteIconWithApprenticeships);
        }
    }
}