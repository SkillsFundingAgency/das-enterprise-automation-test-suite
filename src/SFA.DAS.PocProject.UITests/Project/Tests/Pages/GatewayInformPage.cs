using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.Pages
{
    public class GatewayInformPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly PayeAccountDetails _config;
        #endregion

        private By ContinueButton => By.Id("agree_and_continue");

        private By SetItUpLaterLink => By.CssSelector("a.button-link");

        public GatewayInformPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected override string PageTitle => "Using your Government Gateway details";

        public GgSignInPage ContinueToGGSignIn()
        {
            Continue();
            return new GgSignInPage(_context);
        }

        private GatewayInformPage Continue()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
            return this;
        }
    }
}