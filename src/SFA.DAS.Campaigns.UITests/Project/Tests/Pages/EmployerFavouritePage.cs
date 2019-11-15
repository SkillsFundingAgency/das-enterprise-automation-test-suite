using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    public class EmployerFavouritePage: BasePage
    {
        protected override string PageTitle => "";
        #region Constants
        private const string ExpectedPageTitle = "YOUR FAVOURITE APPRENTICESHIPS AND TRAINING PROVIDERS";
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Object Elements
        private readonly By _pageTitle = By.XPath("//h1[@class='hero-heading__heading heading-xl']");
        private readonly By _favouriteIcon = By.XPath("//span[@class='favourites-link__text']");
        #endregion

        public EmployerFavouritePage(ScenarioContext context): base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public EmployerFavouritePage ClickOnClickingOnTheFavouriteIcon()
        {
            _formCompletionHelper.ClickElement(_favouriteIcon);
            return new EmployerFavouritePage(_context);
        }

        public EmployerFavouritePage VerifyFavouritePageHeader()
        {
            _pageInteractionHelper.VerifyText(_pageTitle,ExpectedPageTitle);
            return new EmployerFavouritePage(_context);
        }

    }
}