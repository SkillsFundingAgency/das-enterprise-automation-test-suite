using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SignAgreementPage : RegistrationBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName();

        protected override string AccessibilityPageTitle => "Sign an agreement page";

        protected override bool TakeFullScreenShot => false;

        #region Locators
        private static By WantToSignRadioButton => By.CssSelector("label[for=want-to-sign]");
        private static By DoNotWantToSignRadioButton => By.CssSelector("label[for=do-not-want-to-sign]");
        private static By ContinueToYourAgreementButton => By.LinkText("Continue to your agreement");
        protected override By ContinueButton => By.CssSelector("input.govuk-button, input.button");
        #endregion

        public SignAgreementPage(ScenarioContext context) : base(context) => VerifyPage(WantToSignRadioButton);

        public YouHaveAcceptedTheEmployerAgreementPage SignAgreement()
        {
            Sign();
            return new YouHaveAcceptedTheEmployerAgreementPage(context);
        }

        public CreateYourEmployerAccountPage ProviderLeadRegistrationSignAgreement()
        {
            Sign();
            return new CreateYourEmployerAccountPage(context);
        }

        public HomePage DoNotSignAgreement()
        {
            DoNotSign();
            return new HomePage(context);
        }

        private void Sign() => Continue(WantToSignRadioButton);

        private void DoNotSign() => Continue(DoNotWantToSignRadioButton);

        private void Continue(By by)
        {
            formCompletionHelper.ClickElement(by);
            formCompletionHelper.ClickElement(ContinueButton);
        }
        public DoYouAcceptTheEmployerAgreementOnBehalfOfPage ClickAcceptYourAgreementAndAndRedirectedToAccessDeniedPage()
        {
            formCompletionHelper.Click(ContinueToYourAgreementButton);
            return new DoYouAcceptTheEmployerAgreementOnBehalfOfPage(context);
        }
    }
}