using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class StartAddingApprenticesPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//label[@for=\"SelectedRoute-Employer\"]")] private IWebElement _willAddApprenticesCheckbox;
        [FindsBy(How = How.XPath, Using = ".//*[@type=\"submit\"]")] private IWebElement _continueButton;

        public StartAddingApprenticesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public StartAddingApprenticesPage AddingApprentices()
        {
            _formCompletionHelper.SelectRadioButton(_willAddApprenticesCheckbox);
            return this;
        }

        public ReviewCohortPage Continue()
        {
            _formCompletionHelper.ClickElement(_continueButton);
            return new ReviewCohortPage(context);
        }
    }
}