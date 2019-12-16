using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    public class YourSavedFavouritesGovUkPage:BasePage
    {
        protected override string PageTitle => "";
        #region Constants
        private const string ExpectedViewSavedFavouritesHeader = "Your saved favourites";

        #endregion

        #region Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Object Elements
       // private readonly By _yourSavedFavouritesHeader =By.XPath("//hi[@class='govuk-heading-xl govuk-!-margin-top-3 govuk-!-margin-bottom-6']/span[1]");
        private readonly By _yourSavedFavouritesHeader =By.XPath("//span[@class='govuk-caption-xl']");
        private readonly By _apprenticeshipWithNumberHeading = By.XPath("//span[@class='fav-count-text']");
        private readonly By _removeAprrenticeshipAndProviderFromFavouriteLink = By.XPath("//a[@class='govuk-link app-task-list__training-provider-content']");
        #endregion


        public YourSavedFavouritesGovUkPage(ScenarioContext context):base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }
        public YourSavedFavouritesGovUkPage VerifyYourSavedFavouritesHeader()
        {
            _pageInteractionHelper.VerifyText(_yourSavedFavouritesHeader,ExpectedViewSavedFavouritesHeader);
            ExtractNumberFromString();
            return new YourSavedFavouritesGovUkPage(_context);
        }

       public void ExtractNumberFromString()
       {   
        String _ApprenticeshipWithNumberString = _pageInteractionHelper.GetText(_apprenticeshipWithNumberHeading);
        string _apprenticeshipNumber = "";
        string _nonnumericString = "";
        char[] CountofCharinString = _ApprenticeshipWithNumberString.ToCharArray();
        foreach (char ch in CountofCharinString)
        {
            if (char.IsDigit(ch))
            {

               _apprenticeshipNumber = _apprenticeshipNumber + ch.ToString();
            }
            else
            {
                _nonnumericString= _nonnumericString + ch.ToString();
            }
        }

        int _numberOfApprenticeships = Convert.ToInt32( _apprenticeshipNumber);

            if (_numberOfApprenticeships < 1)
            {
                throw new Exception("You have are no saved favourites ");

            }
        }

        internal ConfirmRemovalOfApprenticeshipPage RemoveApprenticeshipAndProviderFromFavourites()
        {
            _formCompletionHelper.ClickElement(_removeAprrenticeshipAndProviderFromFavouriteLink);
            return new ConfirmRemovalOfApprenticeshipPage(_context);
        }


    }
}