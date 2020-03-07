using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class GovUkEmployerHomePage : HomePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ViewSavedFav => By.CssSelector(".das-favourites-link__text");

        public GovUkEmployerHomePage(ScenarioContext context) : base(context) => _context = context;

        public GovUkYourSavedFavouritesPage ViewSavedFavourites()
        {
            formCompletionHelper.ClickElement(ViewSavedFav);
            return new GovUkYourSavedFavouritesPage(_context);
        }
    }
}
