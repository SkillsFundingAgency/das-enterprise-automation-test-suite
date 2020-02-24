using SFA.DAS.UI.FrameworkHelpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HomePage : InterimEmployerBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName();
        protected override string Linktext => "Home";
        private readonly RegexHelper _regexHelper;
        private readonly ScenarioContext _context;

        #region Locators
        private By PublicAccountIdLocator => By.CssSelector(".heading-secondary");
        private By SucessSummary => By.CssSelector(".success-summary");
        private By AcceptYourAgreementLink => By.LinkText("Accept your agreement");
        protected By FundingAvailabilityLink => By.LinkText("Check funding availability and make a reservation");
        protected By YourFundingReservationsLink => By.LinkText("Your funding reservations");
        protected By YourFinancesLink => By.LinkText("Your finances");
        #endregion

        internal HomePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
            _regexHelper = context.Get<RegexHelper>();
        }

        public HomePage(ScenarioContext context) : this(context, false) { }

        public void VerifySucessSummary()
        {
            pageInteractionHelper.VerifyText(SucessSummary, "All agreements signed");
        }

        public string AccountId()
        {
            return _regexHelper.GetAccountId(pageInteractionHelper.GetUrl());
        }

        public string PublicAccountId()
        {
            return _regexHelper.GetPublicAccountId(pageInteractionHelper.GetText(PublicAccountIdLocator));
        }

        public AboutYourAgreementPage ClickAcceptYourAgreementLinkInHomePagePanel()
        {
            formCompletionHelper.Click(AcceptYourAgreementLink);
            return new AboutYourAgreementPage(_context);
        }
    }
}