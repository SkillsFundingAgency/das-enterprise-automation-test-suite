using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class DoYouAcceptTheEmployerAgreementOnBehalfOfPage : RegistrationBasePage
    {
        protected override string PageTitle => "Do you accept the employer agreement on behalf of";

        #region Locators
        private static By WantToSignRadioButton => By.CssSelector("label[for=want-to-sign]");
        private static By DoNotWantToSignRadioButton => By.CssSelector("label[for=do-not-want-to-sign]");
        private static By ContinueToYourAgreementButton => By.LinkText("Continue to your agreement");
        protected override By ContinueButton => By.XPath("//input[@class='govuk-button govuk-!-margin-top-6']");
        #endregion

        public DoYouAcceptTheEmployerAgreementOnBehalfOfPage (ScenarioContext context) : base(context) => VerifyPage();

        public CreateYourEmployerAccountPage SignAgreement()
        {
            Sign();
            return new CreateYourEmployerAccountPage(context);
        }

        public SetPermissionsForTrainingProviderPage ProviderLeadRegistrationSignAgreement()
        {
            Sign();
            return new SetPermissionsForTrainingProviderPage(context);
        }

        public CreateYourEmployerAccountPage DoNotSignAgreement()
        {
            DoNotSign();
            return new CreateYourEmployerAccountPage(context);
        }

        public AccessDeniedPage ClickYesAndContinueDoYouAcceptTheEmployerAgreementOnBehalfOfPage()
        {
            SelectRadioOptionByText("Yes, I accept the agreement");
            formCompletionHelper.Click(ContinueButton);
            return new AccessDeniedPage(context);
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