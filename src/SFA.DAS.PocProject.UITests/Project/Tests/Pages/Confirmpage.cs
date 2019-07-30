using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.Pages
{
    public class ConfirmPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectSpecificConfig _config;
        #endregion

        private By AccessCodeInput => By.Id("AccessCode");

        private By ContinueButton => By.CssSelector("input.button");

        private By RequestAnotheEmailLink => By.CssSelector("input.link-button");

        public ConfirmPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetConfigSection<ProjectSpecificConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected override string PageTitle => "Confirm your identity";

        public GetApprenticeshipFunding ContinueToGetApprenticeshipFunding()
        {
            EnterAccessCode()
                   .Continue();
            return new GetApprenticeshipFunding(_context);
        }

        private ConfirmPage EnterAccessCode()
        {
            _formCompletionHelper.EnterText(AccessCodeInput, _config.ConfirmCode);
            return this;
        }

        private ConfirmPage Continue()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
            return this;
        }
    }
}