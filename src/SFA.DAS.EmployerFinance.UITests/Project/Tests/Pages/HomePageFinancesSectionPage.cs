using OpenQA.Selenium;
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
        private By CheckFundingAvailabilityLink(string checkFundingAvailabilityLinkText) => By.LinkText(checkFundingAvailabilityLinkText);
        private By YourFundingReservationsLink(string fundingReservationsLinkText) => By.LinkText(fundingReservationsLinkText);
        private By YourFinancesLinkText(string yourFinancesLinkText) => By.LinkText(yourFinancesLinkText);
        #endregion

        public HomePageFinancesSectionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
            VerifyPage(FinancesSectionHeading);
        }

        public HomePageFinancesSectionPage VerifyFundingAvailabilityLink(string checkFundingAvailabilityLinkText)
        {
            pageInteractionHelper.VerifyText(CheckFundingAvailabilityLink(checkFundingAvailabilityLinkText), checkFundingAvailabilityLinkText);
            return this;
        }

        public HomePageFinancesSectionPage VerifyYourFinancesSectionLinks(string fundingReservationsLinkText, string yourFinancesLinkText)
        {
            pageInteractionHelper.VerifyText(YourFundingReservationsLink(fundingReservationsLinkText), fundingReservationsLinkText);
            pageInteractionHelper.VerifyText(YourFinancesLinkText(yourFinancesLinkText), yourFinancesLinkText);
            return this;
        }

        public ReserveFundingToTrainAnApprenticePage ClickCheckFundingAvailabilityLink(string checkFundingAvailabilityLinkText)
        {
            formCompletionHelper.Click(CheckFundingAvailabilityLink(checkFundingAvailabilityLinkText));
            return new ReserveFundingToTrainAnApprenticePage(_context);
        }
    }
}
