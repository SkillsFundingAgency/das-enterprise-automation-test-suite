using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Mailinator
{
    class MailinatorInboxPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By _emailSubjectField = By.XPath("//td[contains(text(),'Access code: apprenticeship service')]");

        public MailinatorInboxPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public string GetEmailSubject()
        {
            return _pageInteractionHelper.GetText(_emailSubjectField);
        }

        public void ClickOnEmailToOpenIt()
        {
            _formCompletionHelper.ClickElement(_emailSubjectField);
        }

        public bool IsEmailPresent()
        {
            return _pageInteractionHelper.IsElementDisplayed(_emailSubjectField);
        }
    }
}