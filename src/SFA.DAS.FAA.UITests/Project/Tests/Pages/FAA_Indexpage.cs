using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_Indexpage : FAABasePage
    {
        protected override string PageTitle => "Find an apprenticeship";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By SignIn => By.CssSelector("#loginLink");

        protected override By AcceptCookieButton => By.CssSelector("#btn-cookie-accept");

        public FAA_Indexpage(ScenarioContext context) : base(context)
        {
            _context = context;
            AcceptCookies();
        }

        public FAA_SignInPage GoToSignInPage()
        {
            _formCompletionHelper.Click(SignIn);
            return new FAA_SignInPage(_context);
        }

        private new FAA_Indexpage AcceptCookies()
        {
            base.AcceptCookies();
            return this;
        }
    }
}
