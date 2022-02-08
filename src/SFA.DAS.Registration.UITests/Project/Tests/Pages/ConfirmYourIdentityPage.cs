using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ConfirmYourIdentityPage : RegistrationBasePage
    {
        protected override string PageTitle => "Confirm your identity";

        protected override bool TakeFullScreenShot => false;

        #region Locators
        private By AccessCodeInput => By.Id("AccessCode");
        protected override By ContinueButton => By.CssSelector("input.button");
        #endregion

        public ConfirmYourIdentityPage(ScenarioContext context) : base(context) => VerifyPage();

        public AddAPAYESchemePage ContinueToGetApprenticeshipFunding()
        {
            EnterAccessCodeAndContinue();

            return new AddAPAYESchemePage(context);
        }

        public InvitationsPage ContinueToInvitationsPage()
        {
            EnterAccessCodeAndContinue();

            return new InvitationsPage(context);
        }

        private void EnterAccessCodeAndContinue() { formCompletionHelper.EnterText(AccessCodeInput, config.RE_ConfirmCode); Continue(); }
    }
}