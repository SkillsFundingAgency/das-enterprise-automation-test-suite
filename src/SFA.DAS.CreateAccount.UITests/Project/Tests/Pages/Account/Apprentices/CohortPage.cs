using System.Linq;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    public class CohortPage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By _cohortRequest => By.CssSelector("div.grid-row div span");

        private readonly IWebDriver _webdriver;

        public CohortPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _webdriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool AreThereAnyActiveCohort()
        {
            return _webdriver.FindElements(_cohortRequest).ToList().All(activecohortcount => activecohortcount.Text == "0");
        }
    }
}