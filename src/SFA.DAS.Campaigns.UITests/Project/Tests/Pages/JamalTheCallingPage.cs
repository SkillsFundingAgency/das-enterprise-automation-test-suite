using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    internal class JamalTheCallingPage: BasePage
    {

        protected override string PageTitle => "";
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Constants
        private const string ExpectedTheCallingHeader = "";
        #endregion

        #region Page Objects Elements
        private readonly By _hireAnApprenticeHeader = By.ClassName("heading-xl");
        #endregion

        public JamalTheCallingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

    }
}