using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class GatewayInformPage : BasePage
    {
        protected override string PageTitle => "Using your Government Gateway details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.Id("agree_and_continue");

        private By SetItUpLaterLink => By.CssSelector("a.button-link");

        public GatewayInformPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public GgSignInPage ContinueToGGSignIn()
        {
            Continue();
            return new GgSignInPage(_context);
        }
    }
}