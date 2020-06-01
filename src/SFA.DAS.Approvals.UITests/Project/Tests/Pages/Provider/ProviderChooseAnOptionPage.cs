using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderChooseAnOptionPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Choose an option";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CohortApproveOptions => By.CssSelector(".selection-button-radio");
        protected override By ContinueButton => By.Id("paymentPlan");

        public ProviderChooseAnOptionPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderMessageForEmployerPage SubmitSendToEmployerToReview()
        {
            SelectOption("SaveStatus-AmendAndSend");
            return new ProviderMessageForEmployerPage(_context);
        }

        public ProviderCohortApprovedPage SubmitApprove()
        {
            SelectOption("SaveStatus-Approve");
            return new ProviderCohortApprovedPage(_context);
        }

        public ProviderMessageForEmployerPage SubmitApproveAndSendToEmployerForApproval()
        {
            SelectOption("SaveStatus-ApproveAndSend");
            return new ProviderMessageForEmployerPage(_context);
        }

        public ProviderYourCohortsPage SubmitSaveButDontSendToEmployer()
        {
            SelectOption("SaveStatus-Save");
            return new ProviderYourCohortsPage(_context);
        }

        private void SelectOption(string option)
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(CohortApproveOptions, option);
            Continue();
        }
    }
}
