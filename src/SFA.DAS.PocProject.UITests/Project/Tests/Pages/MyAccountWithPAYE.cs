using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class MyAccountWithPaye : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By CloseIconLink => By.CssSelector(".link-with-icon");

        public MyAccountWithPaye(ScenarioContext context): base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        protected override string PageTitle => "welcome to your new digital account";

        public HomePage GoToHomePage()
        {
            CloseLink();
            return new HomePage(_context);
        }

        private MyAccountWithPaye CloseLink()
        {
            _formCompletionHelper.ClickElement(CloseIconLink);
            return this;
        }
    }
}