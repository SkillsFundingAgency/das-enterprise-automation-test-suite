using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Homepage
{
    public class ConfirmYourIdentityPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "AccessCode")] private IWebElement EnterCodeField { get; set; }
        [FindsBy(How = How.ClassName, Using = "heading-xlarge")] private IWebElement PageHeader { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@type=\"submit\"]")] private IWebElement ConfirmIdentityContinueBtn { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id=\'content\']/form/button")] private IWebElement RequestAnotherEmailLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(@class, 'danger')]")] private IWebElement InvalidCoderrorInBox { get; set; }
        [FindsBy(How = How.Id, Using = "invalidMessage")] private IWebElement InvalidCodeErrorInField { get; set; }
        [FindsBy(How = How.XPath, Using = ".//a[@class=\'link-back\']")] private IWebElement _backButton;
        private By _headerText = By.XPath("(//h1)[1]");
        private By _additionalHeaderText = By.XPath("(//p)[2]");
        private By _headerErrorMessage = By.XPath("//ul[contains(@class, 'error-summary-list')]/li/a");
        private By _textboxErrorMessage = By.XPath("//span[contains(@class, 'error-message')]");

        public ConfirmYourIdentityPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal AccountSettingsPage ValidAccesCode(string validAccesCode)
        {
            EnterValidAccessCode(validAccesCode);
            return new AccountSettingsPage(WebBrowserDriver);
        }

        internal SiteHomepage MoveBack()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _backButton);
            return new SiteHomepage(WebBrowserDriver);
        }

        internal ConfirmYourIdentityPage InvalidAccesCode(string invalidAccesCode)
        {
            EnterInvalidAccessCode(invalidAccesCode);
            return this;
        }

        internal bool IsPagePresented()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, PageHeader) == "Confirm your identity";
        }

        private void EnterValidAccessCode(string validAccesCode)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, EnterCodeField, validAccesCode);
            ClickContinue();
        }

        public void EnterInvalidAccessCode(string invalidAccesCode)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, EnterCodeField, invalidAccesCode);
            ClickContinue();
        }

        public void ClickContinue()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, ConfirmIdentityContinueBtn);
        }

        internal string GetInvalidCodeErrorInField()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, InvalidCodeErrorInField);
        }

        internal string GetInvalidCoderrorInBox()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, InvalidCoderrorInBox);
        }

        internal string GetHeaderText()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, _headerText);
        }

        internal string GetAdditionalHeaderText()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, _additionalHeaderText);
        }

        internal string GetHeaderErrorMessage()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, _headerErrorMessage);
        }

        internal string GetTextBoxErrorMessage()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, _textboxErrorMessage);
        }
    }
}