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

        public EPAOAdmin_BasePage(ScenarioContext context) : base(context) 
        {
            _context = context;
        }

        public SignedOutPage SignOut()
        {
            formCompletionHelper.ClickElement(SignOutLink);
            return new SignedOutPage(_context);
        }
    }
}
