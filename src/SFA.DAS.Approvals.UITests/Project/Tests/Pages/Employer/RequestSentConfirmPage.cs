using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class RequestSentConfirmPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Request sent";

        protected override By PageHeader => By.ClassName("bold-large");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector(".button");

        private By GoToHomePageRadioButton => By.CssSelector(".selection-button-radio");

        public RequestSentConfirmPage(ScenarioContext context) : base(context) => _context = context;

        public HomePage GoToHomePage()
        {
            formCompletionHelper.SelectRadioOptionByText(GoToHomePageRadioButton, "Go to the homepage");
            Continue();
            return new HomePage(_context);
        }
    }
}