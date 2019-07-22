using System.Linq;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.PayeSchemes
{
    public class PayeSchemePage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.Id, Using = "addNewPaye")] private IWebElement _addSchemeButton;
        [FindsBy(How = How.Id, Using = "accept")] private IWebElement _acceptSchemeAddition;
        [FindsBy(How = How.XPath, Using = ".//*[@class=\"success-summary\"]//h1")] private IWebElement _notificationElement;
        [FindsBy(How = How.XPath, Using = ".//h1[@class=\"heading-xlarge\"]")] private IWebElement _pageHeader;

        private readonly IWebDriver _webdriver;

        public PayeSchemePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _webdriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool IsPagePresented()
        {
            return _pageInteractionHelper.GetText(_pageHeader) == "PAYE schemes";
        }

        internal UsingYourGovtGatewayDetailsPage AddScheme()
        {
            _formCompletionHelper.ClickElement(_addSchemeButton);
            return new UsingYourGovtGatewayDetailsPage(_context);
        }

        internal PayeSchemePage AcceptScheme()
        {
            _formCompletionHelper.ClickElement(_acceptSchemeAddition);
            if (_context.EmployerAccountHomepage().IsMoreLinkPresent())
                _context.EmployerAccountHomepage().ClickMoreLink();
            _context.EmployerAccountHomepage().OpenPayeSchemesPage();
            return this;
        }

        internal string[] GetAvailableSchemas()
        {
            return _webdriver
                .FindElements(By.XPath(".//table//tbody//tr//td[1]"))
                .Select((element) => element.Text)
                .ToArray();
        }

        internal PayeDetailsPage OpenPayeDetails(string scheme)
        {
            var rowtoSelect = _webdriver.FindElements(By.CssSelector("table tr")).ToList().FindIndex(x => x.Text.ContainsCompareCaseInsensitive(scheme));

            var detailsLink = _webdriver.FindElements(By.CssSelector("table tr a")).ToList()[rowtoSelect - 1];

            detailsLink.Click();

            return new PayeDetailsPage(_context);
        }

        internal string GetNotification()
        {
            return _notificationElement.Text;
        }
    }
}