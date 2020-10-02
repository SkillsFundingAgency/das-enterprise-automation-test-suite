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

        private By GetStarted => By.CssSelector("a[href*='employers/create-apprenticeship-service-account']");
        
        private By AddProviderLink => By.CssSelector($".fiu-panel__button[href*='{objectContext.GetCourseId()}']");

        private By NoFavourites => By.CssSelector("section .govuk-heading-m");

        private By Delete(string value) => By.CssSelector($".fiu-favourite-bar__link[value='{value}']");

        public EmployerFavouritesPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public CreateAnAccountPage CreateAnAccount()
        {
            formCompletionHelper.ClickElement(GetStarted);
            return new CreateAnAccountPage(_context);
        }

        public FindTrainingProviderForThisApprenticeshipPage AddProvider()
        {
            formCompletionHelper.ClickElement(AddProviderLink);
            return new FindTrainingProviderForThisApprenticeshipPage(_context);
        }

        public EmployerFavouritesPage VerifyEmptyBasket()
        {
            VerifyPage(NoFavourites, "You haven't added any favourites yet");
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

