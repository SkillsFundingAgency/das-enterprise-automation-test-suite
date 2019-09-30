using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class RequestSentConfirmPage : BasePage
    {
        protected override string PageTitle => "Request sent";

        protected override By PageHeader => By.ClassName("bold-large");

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By ContinueButton => By.CssSelector(".button");

        private By GoToHomePageRadioButton => By.CssSelector(".selection-button-radio");

        public RequestSentConfirmPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public HomePage GoToHomePage()
        {
            _formCompletionHelper.SelectRadioOptionByText(GoToHomePageRadioButton, "Go to the homepage");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new HomePage(_context);
        }
    }
}