using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class CreateAnAccountPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Create an account";

        #region Locators
        private static By GivenNameTextbox => By.Id("GivenName");
        private static By FamilyNameTextbox => By.Id("FamilyName");
        private static By EmailAddressTextbox => By.Id("Email");
        #endregion

        public CreateAnAccountPage(ScenarioContext context) : base(context) => VerifyPage();

        public ConfirmYourIdentityPage EnterAccountDetailsAndClickCreateAccount()
        {
            formCompletionHelper.EnterText(GivenNameTextbox, applyCreateUserDataHelpers.GivenName);
            formCompletionHelper.EnterText(FamilyNameTextbox, applyCreateUserDataHelpers.FamilyName);
            formCompletionHelper.EnterText(EmailAddressTextbox, applyCreateUserDataHelpers.CreateAccountEmail);
            Continue();
            return new ConfirmYourIdentityPage(context);
        }
    }
}
