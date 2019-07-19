using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class CohortUntilPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//label[@for=\"SaveStatus-Save\"]")] private IWebElement _dontSendProviderCheckbox;
        [FindsBy(How = How.XPath, Using = ".//*[@type=\"submit\"]")] private IWebElement _continueButton;

        public CohortUntilPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public CohortUntilPage DontSendOption()
        {
            _formCompletionHelper.SelectRadioButton(_dontSendProviderCheckbox);
            return this;
        }

        public CohortsLandingPage Continue()
        {
            _formCompletionHelper.ClickElement(_continueButton);
            return new CohortsLandingPage(context);
        }
    }
}