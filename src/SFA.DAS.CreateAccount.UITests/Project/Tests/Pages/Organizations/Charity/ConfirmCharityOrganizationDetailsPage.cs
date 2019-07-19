using SFA.DAS.CreateAccount.UITests.Project.Framework.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.Charity
{
    internal class ConfirmCharityOrganizationDetailsPage : BasePage
    {
        public ConfirmCharityOrganizationDetailsPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver) { }
        [FindsBy(How = How.XPath, Using = ".//input[@value=\"Yes, continue\"]")] private IWebElement _continueButton;

        public void Continue()
        {
            formCompletionHelper.ClickElement(_continueButton);
        }

        private By orgName = By.XPath("//tbody/tr[1]/td");
        internal string GetOrganizationInfo()
        {
            return pageInteractionHelper.GetText(orgName);
        }

        private By charityAddress = By.XPath("//tbody/tr[2]/td");
        internal string GetCharityAddress()
        {
            return pageInteractionHelper.GetText(charityAddress);
        }

        private By charityNumber = By.XPath("//tbody/tr[3]/td");
        internal string GetCharityNumber()
        {
            return pageInteractionHelper.GetText(charityNumber);
        }

        private By payeNumber = By.XPath("//tbody/tr[4]/td");
        internal string GetPayeScheme()
        {
            return pageInteractionHelper.GetText(payeNumber);
        }
    }
}