using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public abstract class EmployerFinanceBasePage : BasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FinanceLink => By.LinkText("Finance");

        protected EmployerFinanceBasePage(ScenarioContext context) : base(context) => _context = context;

        public FinancePage GoToFinancePage()
        {
            formCompletionHelper.ClickElement(FinanceLink);
            return new FinancePage(_context);
        }
    }
}
