using SFA.DAS.UI.FrameworkHelpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HomePage : InterimHomeBasePage
    {
        #region Locators
        protected By StartNowButton => By.LinkText("Start now");
        protected By YourFundingReservationsLink => By.LinkText("Your funding reservations");
        protected By YourTransfersLink => By.LinkText("Your transfers");
        private By PublicAccountIdLocator => By.CssSelector(".das-definition-list__definition");
        private By SucessSummary => By.CssSelector(".success-summary");
        private By AcceptYourAgreementLink => By.LinkText("Accept your agreement");
        private By StartAddingApprenticesNowTaskLink => By.LinkText("Start adding apprentices now");
        private By AccountNameText => By.CssSelector("p.heading-xlarge");
        private By ContinueTo => By.LinkText("Continue");
        private By SetUpAnApprenticeshipSectionHeader => By.Id("set-up-an-apprenticeship");
        protected By EIHubLink => By.LinkText("Your hire a new apprentice payments");
        protected By FinancesSectionHeading => By.XPath("//h2[text()='Finances']");
        protected By YourFinancesLink => By.LinkText("Your finances");
        #endregion

        public HomePage(ScenarioContext context, bool navigate) : base(context, navigate) => AcceptCookies();

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

        public string AccountId() => RegexHelper.GetAccountId(GetUrl());

        public string PublicAccountId() => RegexHelper.GetPublicAccountId(pageInteractionHelper.GetText(PublicAccountIdLocator));

        public AboutYourAgreementPage ClickAcceptYourAgreementLinkInHomePagePanel()
        {
            formCompletionHelper.Click(AcceptYourAgreementLink);
            return new AboutYourAgreementPage(context);
        }

        public void ContinueToCreateAdvert() => formCompletionHelper.ClickElement(ContinueTo);

        public void VerifyStartAddingApprenticesNowTaskLink() => VerifyElement(StartAddingApprenticesNowTaskLink);

        public void VerifySetupAnApprenticeshipSection()
        {
            VerifyElement(SetUpAnApprenticeshipSectionHeader);
            VerifyElement(StartNowButton);
        }
    }
}