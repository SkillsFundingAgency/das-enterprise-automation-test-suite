using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.PayeSchemes
{
    public class PayeDetailsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \"Remove PAYE scheme\")]")] private IWebElement _removeSchemeButton;
        [FindsBy(How = How.XPath, Using = ".//*[@id=\"confirm\"]//label[1]")] private IWebElement _confirmRemovingRadioButton;
        [FindsBy(How = How.XPath, Using = ".//*[@id=\"confirm\"]//label[2]")] private IWebElement _discardRemovindRadioButton;
        [FindsBy(How = How.XPath, Using = ".//button[@type=\"submit\"]")] private IWebElement _continueButton;

        public PayeDetailsPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal PayeDetailsPage ClickOnRemoveScheme()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _removeSchemeButton);
            return this;
        }

        internal PayeSchemePage ConfirmRemoving()
        {
            formCompletionHelper.SelectRadioButton(WebBrowserDriver, _confirmRemovingRadioButton);
            formCompletionHelper.ClickElement(WebBrowserDriver, _continueButton);
            return new PayeSchemePage(WebBrowserDriver);
        }

        internal PayeSchemePage DiscardRemoving()
        {
            formCompletionHelper.SelectRadioButton(WebBrowserDriver, _discardRemovindRadioButton);
            formCompletionHelper.ClickElement(WebBrowserDriver, _continueButton);
            return new PayeSchemePage(WebBrowserDriver);
        }
    }
}