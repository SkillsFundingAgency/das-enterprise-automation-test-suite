using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class FinancePage : BasePage
    {
        protected override string PageTitle => "Finanace";

        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly SupportConsoleConfig _config;
        #endregion

        public FinancePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

    }
}