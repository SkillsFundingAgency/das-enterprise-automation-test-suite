using System.Linq;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
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

        [FindsBy(How = How.XPath, Using = ".//*[@class=\"agreement-title\"]//h1")] private IWebElement _pageHeader;
        [FindsBy(How = How.XPath, Using = ".//input[@type=\"submit\"]")] private IWebElement _acceptAndFinish;

        public AcceptTheAgreementPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public bool IsPagePresented()
        {
            return _pageHeader.Text.Contains("ESFA Apprenticeship Agreement for Employers");
        }

        public void ScrollToLast()
        {
            var elements = WebBrowserDriver.FindElements(By.XPath(".//*[@class=\"agreement-contents\"]//p"));
            var target = elements.Last();
            var action = new Actions(_context);
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