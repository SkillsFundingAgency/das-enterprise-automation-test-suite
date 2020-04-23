using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmTrainingProviderUnderPermissionsPage : BasePage
    {
        protected override string PageTitle => "Confirm training provider";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion
        private By SelectYesConfirm = By.XPath("//fieldset[@class='govuk-fieldset']//input[@automation-id='choice-1']");

        public ConfirmTrainingProviderUnderPermissionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal TrainingProviderAddedPage ConfirmTrainingProvider()
        {
            _formCompletionHelper.SelectRadioOptionByLocator(SelectYesConfirm);
            Continue();
            return new TrainingProviderAddedPage(_context);
        }
    }
}