using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Settings
{
    public class RenameAccountPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//*[@class=\"form-group\"]/dl/dd")] private IWebElement _currentNameLabel;
        [FindsBy(How = How.Id, Using = "NewName")] private IWebElement _newNameInput;
        [FindsBy(How = How.Id, Using = "accept")] private IWebElement _saveAndContinueButton;
        [FindsBy(How = How.XPath, Using = ".//a[contains (text(), \'Cancel\')]")] private IWebElement _cancelButton;
        private const string PageTitle = "Rename account";

        public RenameAccountPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        internal string GetCurrentName()
        {
            return _currentNameLabel.Text;
        }

        internal RenameAccountPage SetNewName(string newName)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _newNameInput, newName);
            return this;
        }

        internal void SaveAndContinue()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _saveAndContinueButton);
        }

        internal string[] GetErrors()
        {
            return WebBrowserDriver
                .FindElements(By.XPath(".//*[@class=\"error-summary\"]//ul//li"))
                .Select((element) => element.Text)
                .ToArray();
        }
    }
}