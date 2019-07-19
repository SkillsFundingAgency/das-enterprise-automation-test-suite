using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class ApprenticesBasePage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        [FindsBy(How = How.XPath, Using = ".//a[contains(text(), \'Add an apprentice\')]")] private IWebElement _addAnApprenticeLink;
        [FindsBy(How = How.XPath, Using = ".//a[contains(text(), \'Your cohorts\')]")] private IWebElement _yourCohortLink;

        public ApprenticesBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool IsPagePresented()
        {
            return _pageInteractionHelper.IsElementDisplayed(_addAnApprenticeLink);
        }

        public AddApprenticePage AddApprentice()
        {
            _formCompletionHelper.ClickElement(_addAnApprenticeLink);
            return new AddApprenticePage(_context);
        }

        public CohortPage OpenCohortPage()
        {
            _formCompletionHelper.ClickElement(_yourCohortLink);
            return new CohortPage(_context);
        }
    }
}