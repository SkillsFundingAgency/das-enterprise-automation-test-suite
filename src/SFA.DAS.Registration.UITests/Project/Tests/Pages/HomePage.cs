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
        private By StartAddingApprenticesNowTaskLink => By.LinkText("Start adding apprentices now");
        protected By YourFundingReservationsLink => By.LinkText("Your funding reservations");
        protected By YourFinancesLink => By.LinkText("Your finances");
        #endregion

        #region DynamicHomePanel
        protected By ContinueSettingUpAnApprenticeship => By.Id("call-to-action-continue-setting-up-an-apprenticeship");

        protected By ContinueTo => By.LinkText("Continue");

        protected By StartNowButton => By.LinkText("Start now");
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

        public DoYouNeedToCreateAnAdvertBasePage ContinueToCreateAdvert()
        {
            formCompletionHelper.ClickElement(ContinueTo);
            return new DoYouNeedToCreateAnAdvertBasePage(_context);
        }
        
        public void VerifyReserveFundingPanel() => pageInteractionHelper.VerifyText(ContinueSettingUpAnApprenticeship, "Continue setting up an apprenticeship");
        
        public void VerifyStartAddingApprenticesNowTaskLink() => VerifyPage(StartAddingApprenticesNowTaskLink);
    }
}