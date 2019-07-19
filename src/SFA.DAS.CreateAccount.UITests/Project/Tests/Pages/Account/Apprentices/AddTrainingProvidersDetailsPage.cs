using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class AddTrainingProvidersDetailsPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "ProviderId")] private IWebElement _providerIdInput;
        [FindsBy(How = How.XPath, Using = ".//*[@type=\"submit\"]")] private IWebElement _continueButton;

        public AddTrainingProvidersDetailsPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public AddTrainingProvidersDetailsPage SetProviderId(string id)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _providerIdInput, id);
            return this;
        }

        public ConfirmTrainingProviderPage Continue()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _continueButton);
            return new ConfirmTrainingProviderPage(WebBrowserDriver);
        }
    }
}