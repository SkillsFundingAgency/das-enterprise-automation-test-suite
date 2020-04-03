using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ConfirmPage : RegistrationBasePage
    {
        protected override string PageTitle => "Confirm your identity";
        private readonly ScenarioContext _context;

        #region Locators
        private By AccessCodeInput => By.Id("AccessCode");
        protected override By ContinueButton => By.CssSelector("input.button");
        #endregion

        public ConfirmPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AddAPAYESchemePage ContinueToGetApprenticeshipFunding()
        {
            EnterAccessCode()
                   .Continue();
            return new AddAPAYESchemePage(_context);
        }

        public ConfirmPage EnterAccessCode()
        {
            formCompletionHelper.EnterText(AccessCodeInput, config.RE_ConfirmCode);
            return this;
        }

        public InvitationsPage ContinueToInvitationsPage()
        {
            Continue();
            return new InvitationsPage(_context);
        }
    }
}