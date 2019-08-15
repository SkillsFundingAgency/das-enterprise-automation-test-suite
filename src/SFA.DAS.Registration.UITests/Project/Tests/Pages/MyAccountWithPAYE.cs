using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public abstract class MyAccountWithPaye : BasePage
    {
        #region Helpers and Context
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        private readonly ScenarioContext _context;
        protected readonly ProjectConfig config;
        #endregion

        protected bool navigate;

        protected By GlobalNavLink => By.CssSelector("#global-nav-links li a");

        protected abstract string Linktext { get; }

        public MyAccountWithPaye(ScenarioContext context) : base(context)
        {
            _context = context;
            config = context.GetProjectConfig<ProjectConfig>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
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
            var link = pageInteractionHelper.GetLink(GlobalNavLink, Linktext);
            formCompletionHelper.ClickElement(link);
        }
    }
}