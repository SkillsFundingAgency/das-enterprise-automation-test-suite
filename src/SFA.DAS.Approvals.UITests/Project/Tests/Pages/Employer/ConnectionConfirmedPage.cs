using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConnectionConfirmedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Connection confirmed";

        protected override By PageHeader => By.ClassName("bold-large");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector(".button");

        private By GoToHomePageRadioButton => By.CssSelector(".selection-button-radio");

        public ConnectionConfirmedPage(ScenarioContext context) : base(context) => _context = context;

        public HomePage GoToHomePage()
        {
            formCompletionHelper.SelectRadioOptionByText(GoToHomePageRadioButton, "Go back to the homepage");
            Continue();
            return new HomePage(_context);
        }
    }
}