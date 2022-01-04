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
            EnterAccessCode().Continue();

            return new AddAPAYESchemePage(context);
        }

        public ConfirmYourIdentityPage EnterAccessCode()
        {
            formCompletionHelper.EnterText(AccessCodeInput, config.RE_ConfirmCode);
            return this;
        }

        public InvitationsPage ContinueToInvitationsPage()
        {
            Continue();
            return new InvitationsPage(context);
        }
    }
}