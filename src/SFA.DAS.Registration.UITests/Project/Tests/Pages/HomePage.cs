using SFA.DAS.UI.FrameworkHelpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Helpers;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HomePage : InterimEmployerBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName();
        protected override string Linktext => "Home";

        private readonly RegexHelper _regexHelper;
        private readonly ScenarioContext _context;

        #region Locators
        protected By YourFundingReservationsLink => By.LinkText("Your funding reservations");
        protected By YourFinancesLink => By.LinkText("Your finances");
        private By PublicAccountIdLocator => By.CssSelector(".heading-secondary");
        private By SucessSummary => By.CssSelector(".success-summary");
        private By AcceptYourAgreementLink => By.LinkText("Accept your agreement");
        private By StartAddingApprenticesNowTaskLink => By.LinkText("Start adding apprentices now");
        private By AccountNameText => By.CssSelector("p.heading-xlarge");
        private By YourSavedFavouritesLink => By.CssSelector(".das-favourites-link__text");
        #endregion

        protected By ContinueSettingUpAnApprenticeship => By.Id("call-to-action-continue-setting-up-an-apprenticeship");

        protected By ContinueTo => By.LinkText("Continue");

        protected By StartNowButton => By.LinkText("Start now");

        public HomePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
            _regexHelper = context.Get<RegexHelper>();
        }

        public HomePage(ScenarioContext context) : this(context, false) { }

        public HomePage VerifySucessSummary(string message)
        {
            pageInteractionHelper.VerifyText(SucessSummary, message);
            return this;
        }

        public HomePage VerifyAccountName(string name)
        {
            pageInteractionHelper.VerifyText(AccountNameText, name);
            return this;
        }

        public string AccountId() => _regexHelper.GetAccountId(pageInteractionHelper.GetUrl());

        public string PublicAccountId() => _regexHelper.GetPublicAccountId(pageInteractionHelper.GetText(PublicAccountIdLocator));

        public AboutYourAgreementPage ClickAcceptYourAgreementLinkInHomePagePanel()
        {
            formCompletionHelper.Click(AcceptYourAgreementLink);
            return new AboutYourAgreementPage(_context);
        }

        public void ContinueToCreateAdvert() => formCompletionHelper.ClickElement(ContinueTo);

        public void VerifyReserveFundingPanel() => pageInteractionHelper.VerifyText(ContinueSettingUpAnApprenticeship, "Continue setting up an apprenticeship");

        public void VerifyStartAddingApprenticesNowTaskLink() => VerifyPage(StartAddingApprenticesNowTaskLink);

        public YourSavedFavouritesPage GoToYourSavedFavourites()
        {
            formCompletionHelper.Click(YourSavedFavouritesLink);
            return new YourSavedFavouritesPage(_context);
        }
    }
}