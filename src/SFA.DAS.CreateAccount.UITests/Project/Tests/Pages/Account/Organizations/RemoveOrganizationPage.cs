using System.Linq;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations
{
    public class RemoveOrganizationPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private readonly IWebDriver _webDriver;

        private By _secondOrgInTheList = By.XPath("(//a[contains (text(), 'Remove ')])[2]");
        public RemoveOrganizationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public string[] GetOrganizationsInfo()
        {
            var elements = _webDriver.FindElements(By.XPath(".//tr/td[2]"));
            return elements
                .Select((element) => element.Text)
                .ToArray();
        }

        public RemoveOrganizationConfirmPage ClickSecondOrgInTheList()
        {
            _formCompletionHelper.ClickElement(_secondOrgInTheList);
            return new RemoveOrganizationConfirmPage(_context);
        }
    }
}
