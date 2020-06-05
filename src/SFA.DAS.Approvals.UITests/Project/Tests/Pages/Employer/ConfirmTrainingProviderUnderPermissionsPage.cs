using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmTrainingProviderUnderPermissionsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm training provider";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By SelectYesConfirm => By.XPath("//fieldset[@class='govuk-fieldset']//input[@automation-id='choice-1']");

        public ConfirmTrainingProviderUnderPermissionsPage(ScenarioContext context) : base(context) => _context = context;

        internal TrainingProviderAddedPage ConfirmTrainingProvider()
        {
            formCompletionHelper.SelectRadioOptionByLocator(SelectYesConfirm);
            Continue();
            return new TrainingProviderAddedPage(_context);
        }
    }
}