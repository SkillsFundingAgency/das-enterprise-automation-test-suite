using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.Pages
{
    public class MyAccountWithPAYE :BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By CloseIconLink => By.CssSelector(".link-with-icon");

        public MyAccountWithPAYE(ScenarioContext context): base(context)
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

        private MyAccountWithPAYE CloseLink()
        {
            _formCompletionHelper.ClickElement(CloseIconLink);
            return this;
        }
    }
}