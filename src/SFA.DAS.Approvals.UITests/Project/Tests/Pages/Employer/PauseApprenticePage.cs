using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class PauseApprenticePage : BasePage
    {
        protected override string PageTitle => "Pause apprentice";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By confirmPauseOptions = By.CssSelector(".selection-button-radio");
        private By confirmButton = By.CssSelector(".button");

        public PauseApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ApprenticeDetailsPage SelectYesAndConfirm()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(confirmPauseOptions, "ChangeConfirmed-True");
            _formCompletionHelper.ClickElement(confirmButton);
            return new ApprenticeDetailsPage(_context);
        }
    }
}