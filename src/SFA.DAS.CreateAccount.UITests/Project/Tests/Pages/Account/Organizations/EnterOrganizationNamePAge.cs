using System.Linq;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.PublicSectorOrganization;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations
{
    internal class EnterOrganizationNamePage : BasePage
    {
        [FindsBy(How = How.Id, Using = "Name")] private IWebElement _nameInput;
        [FindsBy(How = How.Id, Using = "accept")] private IWebElement _continueButton;

        public EnterOrganizationNamePage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public EnterOrganizationNamePage SetName(string name)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _nameInput, name);
            return this;
        }

        public OrganizationAddressPage Continue()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _continueButton);
            return new OrganizationAddressPage(WebBrowserDriver);
        }

        public FindOrganizationAddressPage ContinueWithFindOrganizationAddress()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _continueButton);
            return new FindOrganizationAddressPage(WebBrowserDriver);
        }

        internal string[] GetErrors()
        {
            return WebBrowserDriver
                .FindElements(By.XPath(".//*[@class=\"error-summary\"]//li"))
                .Select((element) => element.Text)
                .ToArray();
        }
    }
}