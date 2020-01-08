using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_Indexpage : BasePage
    {
        protected override string PageTitle => "Find an apprenticeship";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By SignIn => By.CssSelector("#loginLink");

        private By AcceptCookieButton => By.CssSelector("#btn-cookie-accept");

        public FAA_Indexpage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
            AcceptCookies();
        }

        public FAA_SignInPage GoToSignInPage()
        {
            _formCompletionHelper.Click(SignIn);
            return new FAA_SignInPage(_context);
        }

        private FAA_Indexpage AcceptCookies()
        {
            if (_pageInteractionHelper.IsElementDisplayed(AcceptCookieButton))
            {
                _formCompletionHelper.Click(AcceptCookieButton);
            }
            return this;
        }
    }
}
