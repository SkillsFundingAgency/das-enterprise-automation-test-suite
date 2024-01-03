using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HomePage : InterimHomeBasePage
    {
        #region Locators
        protected static By StartNowButton => By.LinkText("Start now");
        protected static By YourFundingReservationsLink => By.LinkText("Your funding reservations");
        protected static By YourTransfersLink => By.LinkText("Your transfers");
        private static By SucessSummary => By.CssSelector(".das-notification");
        private static By AcceptYourAgreementLink => By.LinkText("Accept your agreement");
        private static By ContinueTo => By.LinkText("Continue");
        private static By SetUpAnApprenticeshipSectionHeader => By.Id("set-up-an-apprenticeship");
        protected static By FinancesSectionHeading => By.XPath("//h2[text()='Finances']");
        protected static By YourFinancesLink => By.LinkText("Your finances");
        protected static By AANLink => By.LinkText("Join the Apprentice Ambassador Network");
        #endregion

        protected override string AccessibilityPageTitle => "Employer home page";

        public HomePage(ScenarioContext context, bool navigate) : base(context, navigate) => AcceptCookies();

        public HomePage(ScenarioContext context) : this(context, false) { }

        public void GoToAanHomePage() => formCompletionHelper.Click(AANLink);

        public HomePage VerifySucessSummary(string message)
        {
            pageInteractionHelper.VerifyText(SucessSummary, message);
            return this;
        }

        public HomePage VerifyAccountName(string name)
        {
            pageInteractionHelper.VerifyText(PageHeader, name);
            return this;
        }

        public AboutYourAgreementPage ClickAcceptYourAgreementLinkInHomePagePanel()
        {
            formCompletionHelper.Click(AcceptYourAgreementLink);
            return new AboutYourAgreementPage(context);
        }

        public void ContinueToCreateAdvert() => formCompletionHelper.ClickElement(ContinueTo);

        public void VerifySetupAnApprenticeshipSection()
        {
            VerifyElement(SetUpAnApprenticeshipSectionHeader);
            VerifyElement(StartNowButton);
        }
    }
}