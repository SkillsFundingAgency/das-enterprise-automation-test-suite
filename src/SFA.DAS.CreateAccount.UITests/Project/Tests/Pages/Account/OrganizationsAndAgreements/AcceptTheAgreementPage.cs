using System.Linq;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.OrganizationsAndAgreements
{
    internal class AcceptTheAgreementPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private readonly By _pageHeader = By.XPath(".//*[@class=\"agreement-title\"]//h1");
        private readonly By _acceptAndFinish = By.XPath(".//input[@type=\"submit\"");

        private readonly IWebDriver _webdriver;

        public AcceptTheAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _webdriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public bool IsPagePresented()
        {
            return _pageInteractionHelper.GetText(_pageHeader).Contains("ESFA Apprenticeship Agreement for Employers");
        }

        public void ScrollToLast()
        {
            var elements = _webdriver.FindElements(By.XPath(".//*[@class=\"agreement-contents\"]//p"));
            var target = elements.Last();
            var action = new Actions(_webdriver);
            action.MoveToElement(target);
            action.Perform();
        }

        public OrganizationsAndAgreementsBasePage AcceptAndFinish()
        {
            _formCompletionHelper.ClickElement(_acceptAndFinish);
            return new OrganizationsAndAgreementsBasePage(_context);
        }
    }
}