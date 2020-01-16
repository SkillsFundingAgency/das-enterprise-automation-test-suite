using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    public class ManageApprenticeshipHomePage:BasePage
    {
        protected override string PageTitle => "";
        #region Constants
        private const string ExpectedPageTitle = "Sign In";

        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Object Elements
        private readonly By _viewSavedFavouritesLink =By.XPath("//a[@class='das-favourites-link govuk-body']/span[2]");
        private readonly By _viewSavedFavouritesHeader =By.XPath("//hi[@class='govuk-heading-xl govuk-!-margin-top-3 govuk-!-margin-bottom-6']/span[1]");
        #endregion


        public ManageApprenticeshipHomePage(ScenarioContext context):base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public YourSavedFavouritesGovUkPage ClickOnViewSavedFavouroitesLink()
        {
            _formCompletionHelper.ClickElement(_viewSavedFavouritesLink);
            return new YourSavedFavouritesGovUkPage(_context);
        }
    }
}