using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class WhenDoYouWantToViewEmpAgreementPage : RegistrationBasePage
    {
        protected override string PageTitle => "When do you want to view the employer agreement?";

        #region Locators
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");
        protected override By ContinueButton => By.Id("submit-when-do-you-want-to-view-button");
        private static By ViewItNowRadionButton => By.CssSelector("label");
        #endregion

        public WhenDoYouWantToViewEmpAgreementPage(ScenarioContext context) : base(context) { VerifyPage(); var email = objectContext.GetRegisteredEmail(); objectContext.SetOrUpdateUserCreds(email, string.Empty, context.Get<RegistrationSqlDataHelper>().CollectAccountDetails(email)); }

        public SignAgreementPage SelectViewAgreementNowAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ViewItNowRadionButton, "view-it-now");
            Continue();
            return new SignAgreementPage(context);
        }

        public HomePage SelectViewItLaterAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ViewItNowRadionButton, "view-it-later");
            Continue();
            return new HomePage(context);
        }
    }
}
