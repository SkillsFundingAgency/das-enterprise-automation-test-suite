using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Mailinator
{
    class MailinatorEmailPage : BasePage
    {
        private By _accessCodeText = By.XPath("//h2[contains(text(), 'ABC123')]");
        private By _emailBodyFrame = By.XPath("//iframe[contains(@id, 'msg_body')]");

        public MailinatorEmailPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public string GetAccessCode()
        {
            pageInteractionHelper.SwitchToFrame(_emailBodyFrame);
            return _formCompletionHelper.GetText(_accessCodeText);
        }

        public bool IsEmailBodyFramePresent()
        {
            return _formCompletionHelper.IsElementDisplayed(_emailBodyFrame);
        }
    }
}