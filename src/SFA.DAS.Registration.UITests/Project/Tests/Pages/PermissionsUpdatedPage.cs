using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class PermissionsUpdatedPage : RegistrationBasePage
    {
        protected override string PageTitle => "You've successfully changed";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
        protected By HomeLink => By.XPath("(//li[@class='das-navigation__list-item'])[1]");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PermissionsUpdatedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        /* public new HomePage GoToHomePage()
         {
             SelectRadioOptionByForAttribute("choice-3");
             Continue();
             return new HomePage(_context);
         }
        */
        public new HomePage GoToHomePage()
        {
            formCompletionHelper.ClickElement(HomeLink);
            return new HomePage(_context);
        }
    }
}
