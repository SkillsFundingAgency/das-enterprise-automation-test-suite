using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class HomePageFinancesSection : HomePage
    {
        private readonly ScenarioContext _context;

        #region Locators
        private By FinancesSectionHeading => By.XPath("//h2[text()='Finances']");
        private By EmployerIncentivesLink => By.PartialLinkText("Apply for the hire a new apprentice payment");
        #endregion

        public HomePageFinancesSection(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage(FinancesSectionHeading);
        }

        public HomePageFinancesSection VerifyYourFinancesSectionLinksForANonLevyUser()
        {
            pageInteractionHelper.VerifyPage(YourFundingReservationsLink);
            pageInteractionHelper.VerifyPage(YourFinancesLink);
            return this;
        }

        public HomePageFinancesSection VerifyYourFinancesSectionLinksForALevyUser()
        {
            pageInteractionHelper.VerifyPage(YourFinancesLink);
            return this;
        }

        public FinancePage NavigateToFinancePage()
        {
            formCompletionHelper.Click(YourFinancesLink);
            return new FinancePage(_context);
        }

        public HomePage NavigateToEmployerIncentivesPage()
        {
            formCompletionHelper.Click(EmployerIncentivesLink);
            new EmployerIncentivesPage(_context).NavigateBackToHomePage();
            return new HomePage(_context);
        }
    }
}
