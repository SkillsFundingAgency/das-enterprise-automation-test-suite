using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerFavouritesPage : EmployerBasePage
    {
        protected override string PageTitle => "Favourites";
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CreateAnAccountButton => By.CssSelector(".button.hero__panel-button");
        
        private By AddProviderLink => By.CssSelector($".fiu-panel__button[href*='{objectContext.GetCourseId()}']");

        private By BasketEmpty => By.XPath("//a[@href ='/basket/view']");

        private By Delete(string value) => By.CssSelector($".das-basket__item-delete[value='{value}']");

        public EmployerFavouritesPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public CreateAnAccountPage CreateAnAccount()
        {
            formCompletionHelper.ClickElement(CreateAnAccountButton);
            return new CreateAnAccountPage(_context);
        }

        public SummaryOfThisApprenticeshipPage AddProvider()
        {
            formCompletionHelper.ClickElement(AddProviderLink);
            return new SummaryOfThisApprenticeshipPage(_context);
        }

        public EmployerFavouritesPage VerifyEmptyBasket()
        {
            VerifyPage(BasketEmpty, "YOU HAVEN'T ADDED ANY FAVOURITES YET");
            return new EmployerFavouritesPage(_context);
        }

        public EmployerFavouritesPage DeleteFavourites()
        {
            DeleteProviderFavourites();
            DeleteApprenticeshipFavourites();
            return new EmployerFavouritesPage(_context);
        }

        public EmployerFavouritesPage DeleteProviderFavourites()
        {
            formCompletionHelper.ClickElement(Delete(objectContext.GetProviderId()));
            return new EmployerFavouritesPage(_context);
        }

        public EmployerFavouritesPage DeleteApprenticeshipFavourites()
        {
            formCompletionHelper.ClickElement(Delete(objectContext.GetCourseId()));
            return new EmployerFavouritesPage(_context);
        }

        public RemoveConfirmPage DeleteApprenticeshipAndProviderFavourites()
        {
            formCompletionHelper.ClickElement(Delete(objectContext.GetCourseId()));
            return new RemoveConfirmPage(_context);
        }
    }
}

