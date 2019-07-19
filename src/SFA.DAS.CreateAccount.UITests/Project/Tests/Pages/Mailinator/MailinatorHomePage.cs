using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Mailinator
{
    class MailinatorHomePage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By _emailTextBox = By.XPath("//input[contains(@id, 'inboxfield')]");
        private By _goButton = By.XPath("//button[contains(@class, 'btn btn-default')]");

        public MailinatorHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public void EnterTextIntoEmailTextBox(string email)
        {
            _formCompletionHelper.EnterText(_emailTextBox, email);
        }

        public void ClickOnGoButton()
        {
            _formCompletionHelper.ClickElement(_goButton);
        }
    }
}