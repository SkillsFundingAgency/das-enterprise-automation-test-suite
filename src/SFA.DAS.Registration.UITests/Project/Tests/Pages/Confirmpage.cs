using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ConfirmPage : BasePage
    {
        protected override string PageTitle => "Confirm your identity";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RegistrationConfig _config;
        #endregion

        private By AccessCodeInput => By.Id("AccessCode");

        protected override By ContinueButton => By.CssSelector("input.button");

        private By RequestAnotheEmailLink => By.CssSelector("input.link-button");

        public ConfirmPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetRegistrationConfig<RegistrationConfig>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public GetApprenticeshipFunding ContinueToGetApprenticeshipFunding()
        {
            EnterAccessCode()
                   .Continue();
            return new GetApprenticeshipFunding(_context);
        }

        private ConfirmPage EnterAccessCode()
        {
            _formCompletionHelper.EnterText(AccessCodeInput, _config.RE_ConfirmCode);
            return this;
        }
    }
}