using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class ReviewCohortPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//*[@class=\"column-one-third total-cost\"]//h2")] private IWebElement _totalCost;
        [FindsBy(How = How.XPath, Using = ".//a[contains(text(), \'Save and continue\')]")] private IWebElement _saveAndContinue;
        [FindsBy(How = How.XPath, Using = ".//a[contains(text(), \'Add an apprentice\')]")] private IWebElement _addApperenticeButton;

        public ReviewCohortPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public string GetTotalCost()
        {
            return _totalCost.Text;
        }

        public CohortUntilPage SaveAndContinue()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _saveAndContinue);
            return new CohortUntilPage(WebBrowserDriver);
        }

        public AddApperentieceFillFormPage AddAnApperentice()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _addApperenticeButton);
            return new AddApperentieceFillFormPage(WebBrowserDriver);
        }
    }
}