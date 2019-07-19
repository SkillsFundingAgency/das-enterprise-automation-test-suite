using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class ReviewCohortPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.XPath, Using = ".//*[@class=\"column-one-third total-cost\"]//h2")] private IWebElement _totalCost;
        [FindsBy(How = How.XPath, Using = ".//a[contains(text(), \'Save and continue\')]")] private IWebElement _saveAndContinue;
        [FindsBy(How = How.XPath, Using = ".//a[contains(text(), \'Add an apprentice\')]")] private IWebElement _addApperenticeButton;

        public ReviewCohortPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public string GetTotalCost()
        {
            return _totalCost.Text;
        }

        public CohortUntilPage SaveAndContinue()
        {
            _formCompletionHelper.ClickElement(_saveAndContinue);
            return new CohortUntilPage(_context);
        }

        public AddApperentieceFillFormPage AddAnApperentice()
        {
            _formCompletionHelper.ClickElement(_addApperenticeButton);
            return new AddApperentieceFillFormPage(_context);
        }
    }
}