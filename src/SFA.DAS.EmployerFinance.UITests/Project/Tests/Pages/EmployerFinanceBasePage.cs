using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public abstract class EmployerFinanceBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By FinanceLink => By.LinkText("Finance");

        protected EmployerFinanceBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public FinancePage GoToFinancePage()
        {
            formCompletionHelper.ClickElement(FinanceLink);
            return new FinancePage(_context);
        }
    }
}
