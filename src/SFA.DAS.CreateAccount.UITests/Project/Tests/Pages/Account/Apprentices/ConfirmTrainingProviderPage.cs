using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class ConfirmTrainingProviderPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//label[@for=\"Confirmation-True\"]")] private IWebElement _confirmationTrueCheckbox;
        [FindsBy(How = How.XPath, Using = ".//*[@type=\"submit\"]")] private IWebElement _continueButton;

        public ConfirmTrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public ConfirmTrainingProviderPage Confirm()
        {
            _formCompletionHelper.SelectRadioButton(_confirmationTrueCheckbox);
            return this;
        }

        public StartAddingApprenticesPage Continue()
        {
            _formCompletionHelper.ClickElement(_continueButton);
            return new StartAddingApprenticesPage(WebBrowserDriver);
        }
    }
}