using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public abstract class MyAccountWithPaye : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        protected bool navigate;

        protected By GlobalNavLink => By.CssSelector("#global-nav-links li a");

        protected abstract string Linktext { get; }

        public MyAccountWithPaye(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            bool func() => navigate ? VerifyPage(Navigate) : VerifyPage();
            func();
        }

        public HomePage GoToHomePage()
        {
            return new HomePage(_context, true);
        }

        public HomePage HomePage()
        {
            return new HomePage(_context);
        }

        public AboutYourAgreementPage AboutYourAgreementPage()
        {
            return new AboutYourAgreementPage(_context);
        }

        public AboutYourAgreementPage GoToAboutYourAgreementPage()
        {
            return new AboutYourAgreementPage(_context, true);
        }

        protected void Navigate()
        {
            var link = _pageInteractionHelper.GetLink(GlobalNavLink, Linktext);
            _formCompletionHelper.ClickElement(link);
        }
    }
}