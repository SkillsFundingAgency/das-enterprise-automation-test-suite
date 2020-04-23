using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public abstract class EPAOAdmin_BasePage : EPAO_BasePage
    {
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By SignOutLink => By.CssSelector(".govuk-link[href*='SignOut']");
        private By TRows => By.CssSelector(".govuk-summary-list__row");
        private By THeader => By.CssSelector(".govuk-summary-list__key");
        private By TData => By.CssSelector(".govuk-summary-list__value");

        public EPAOAdmin_BasePage(ScenarioContext context) : base(context) => _context = context;

        public SignedOutPage SignOut()
        {
            formCompletionHelper.ClickElement(SignOutLink);
            return new SignedOutPage(_context);
        }

        protected IWebElement GetData(string headerName)
        {
            foreach (var row in pageInteractionHelper.FindElements(TRows))
            {
                if (row.FindElement(THeader).Text == headerName)
                {
                    return row.FindElement(TData);
                }
            }
            throw new NotFoundException($"{headerName} not found");
        }
    }
}
