using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class IdamsPage : SupportConsoleBasePage
    {
        protected override string PageTitle => "";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        private By AccessStaff1Link => By.XPath("//span[contains(text(),'Access1 Staff')]");
        #endregion

        public IdamsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage(AccessStaff1Link);
        }

        public SignInPage ClickAccessStaff1Link()
        {
            _formCompletionHelper.Click(AccessStaff1Link);
            return new SignInPage(_context);
        }
    }
}