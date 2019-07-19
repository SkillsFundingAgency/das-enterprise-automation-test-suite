using System.Linq;
using SFA.DAS.CreateAccount.UITests.Project.Framework.Helpers;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.PayeSchemes
{
    public class PayeSchemePage : BasePage
    {
        [FindsBy(How = How.Id, Using = "addNewPaye")] private IWebElement _addSchemeButton;
        [FindsBy(How = How.Id, Using = "accept")] private IWebElement _acceptSchemeAddition;
        [FindsBy(How = How.XPath, Using = ".//*[@class=\"success-summary\"]//h1")] private IWebElement _notificationElement;
        [FindsBy(How = How.XPath, Using = ".//h1[@class=\"heading-xlarge\"]")] private IWebElement _pageHeader;

        public PayeSchemePage(ScenarioContext context) : base(context)
        {
            _context = context;
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
            return new UsingYourGovtGatewayDetailsPage(context);
        }

        internal PayeSchemePage AcceptScheme()
        {
            _formCompletionHelper.ClickElement(_acceptSchemeAddition);
            if (this.WebBrowserDriver.EmployerAccountHomepage().IsMoreLinkPresent())
                this.WebBrowserDriver.EmployerAccountHomepage().ClickMoreLink();
            this.WebBrowserDriver.EmployerAccountHomepage().OpenPayeSchemesPage();
            return this;
        }

        internal string[] GetAvailableSchemas()
        {
            return WebBrowserDriver
                .FindElements(By.XPath(".//table//tbody//tr//td[1]"))
                .Select((element) => element.Text)
                .ToArray();
        }

        internal PayeDetailsPage OpenPayeDetails(string scheme)
        {
            var rowtoSelect = WebBrowserDriver.FindElements(By.CssSelector("table tr")).ToList().FindIndex(x => x.Text.ContainsCompareCaseInsensitive(scheme));

            var detailsLink = WebBrowserDriver.FindElements(By.CssSelector("table tr a")).ToList()[rowtoSelect - 1];

            detailsLink.Click();

            return new PayeDetailsPage(context);
        }

        internal string GetNotification()
        {
            return _notificationElement.Text;
        }
    }
}