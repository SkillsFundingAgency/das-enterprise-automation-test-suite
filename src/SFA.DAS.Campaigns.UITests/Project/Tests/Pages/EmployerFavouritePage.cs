using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    public class EmployerFavouritePage: BasePage
    {
        protected override string PageTitle => "";
        #region Constants
        private const string ExpectedPageTitle = "YOUR FAVOURITE APPRENTICESHIPS AND TRAINING PROVIDERS";
        private const int FavouriteCount = 2;
        private const int _countAfterBinningOne = 1;
        private const int ExpectedProviderCount=3;
        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Object Elements
        private readonly By _pageTitle = By.XPath("//h1[@class='hero-heading__heading heading-xl']");
        private readonly By _favouriteIcon = By.XPath("//span[@class='favourites-link__text']");
        private readonly By _favouriteCount = By.XPath("//span[@class='favourites-link__count']");
        private readonly By _firstApprenticeshipBin =By.XPath("//button[@class='das-basket__item-delete']");
        private readonly By _providerlink=By.XPath("//a[@class='das-basket__provider-add']");
        private readonly By _providerCount =By.XPath("//ul[@class='list-numbers']/li[2]/span[2]");
        private readonly By _createAccountButton = By.XPath("//a[@class='button hero__panel-button']");
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

        public EmployerFavouritePage VerifyApprenticeshipFavouriteCount()
        {
            var favouriteCountString= _pageInteractionHelper.GetText(_favouriteCount);
            int favouriteCount = int.Parse(favouriteCountString);
            VerifyCount(FavouriteCount,favouriteCount);
            return new EmployerFavouritePage(_context);
        }

        public EmployerFavouritePage VerifyFavouritePageHeader()
        {
            _pageInteractionHelper.VerifyText(_pageTitle,ExpectedPageTitle);
            return new EmployerFavouritePage(_context);
        }

        public EmployerFavouritePage RemoveAnApprenticeshipFromTheShortlist()
        {
            _formCompletionHelper.ClickElement(_firstApprenticeshipBin);
            var favouriteCountString= _pageInteractionHelper.GetText(_favouriteCount);
            int favouriteCount = int.Parse(favouriteCountString);
            VerifyCount(_countAfterBinningOne,favouriteCount);
            return new EmployerFavouritePage(_context);
        }

        public  SummeryOfThisApprenticeshipPage AddAProviderToAnApprenticeship()
        {
            _formCompletionHelper.ClickElement(_providerlink);
            return new  SummeryOfThisApprenticeshipPage(_context);
        }

        public EmployerFavouritePage VerifyProviderFavouriteCount()
        {
            var providerCountString= _pageInteractionHelper.GetText(_providerCount);
            int actualProviderFavouriteCount = int.Parse(providerCountString);
            VerifyCount(ExpectedProviderCount,actualProviderFavouriteCount);
            return new EmployerFavouritePage(_context);
        }


        internal void VerifyCount(int count1, int count2)
        {
            if(count1!= count2)
            {
                throw new Exception ("The count favourite count is Incorrect: " 
                    + "\n Expected: " + count1
                + "\n Found: " + count2);
            }
        }

        public SaveTheTrainingProviderPage ClickOnTheCreateAccountButton()
        {
            _formCompletionHelper.ClickElement(_createAccountButton);
           return new SaveTheTrainingProviderPage(_context);
        }
    }
}