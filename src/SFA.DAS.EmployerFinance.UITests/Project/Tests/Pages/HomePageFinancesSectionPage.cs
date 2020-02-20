using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    class HomePageFinancesSectionPage : EmployerFinanceBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName();
        private readonly ScenarioContext _context;

        #region Locators
        private By FinancesSectionHeading => By.XPath("//h2[text()='Finances']");
        private By FundingAvailabilityLink(string checkFundingAvailabilityLinkText) => By.LinkText(checkFundingAvailabilityLinkText);
        private By YourFundingReservationsLink(string fundingReservationsLinkText) => By.LinkText(fundingReservationsLinkText);
        private By YourFinancesLink(string yourFinancesLinkText) => By.LinkText(yourFinancesLinkText);
        #endregion

        public HomePageFinancesSectionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
            VerifyPage(FinancesSectionHeading);
        }

        public HomePageFinancesSectionPage VerifyFundingAvailabilityLink(string FundingAvailabilityLinkText)
        {
            pageInteractionHelper.VerifyText(FundingAvailabilityLink(FundingAvailabilityLinkText), FundingAvailabilityLinkText);
            return this;
        }

        public HomePageFinancesSectionPage VerifyYourFinancesSectionLinks(string fundingReservationsLinkText, string yourFinancesLinkText)
        {
            pageInteractionHelper.VerifyText(YourFundingReservationsLink(fundingReservationsLinkText), fundingReservationsLinkText);
            pageInteractionHelper.VerifyText(YourFinancesLink(yourFinancesLinkText), yourFinancesLinkText);
            return this;
        }

        public ReserveFundingToTrainAnApprenticePage ClickCheckFundingAvailabilityLink(string checkFundingAvailabilityLinkText)
        {
            formCompletionHelper.Click(FundingAvailabilityLink(checkFundingAvailabilityLinkText));
            return new ReserveFundingToTrainAnApprenticePage(_context);
        }

        public YourFundingReservationsHomePage ClickOnYourFundingReservationsLink(string linkText)
        {
            formCompletionHelper.Click(YourFundingReservationsLink(linkText));
            return new YourFundingReservationsHomePage(_context);
        }

        public FinancePage ClickOnYourFinancesLink(string linkText)
        {
            formCompletionHelper.Click(YourFinancesLink(linkText));
            return new FinancePage(_context);
        }
    }
}
