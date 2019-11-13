using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public abstract class SupportConsoleBasePage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".heading-large, .heading-xlarge");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SupportConsoleBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }
    }
}