using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderChooseAnOptionPage : BasePage
    {
        protected override string PageTitle => "Choose an option";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By CohortApproveOptions => By.CssSelector(".selection-button-radio");
        protected override By ContinueButton => By.Id("paymentPlan");

        public ProviderChooseAnOptionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

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
            _formCompletionHelper.SelectRadioOptionByForAttribute(CohortApproveOptions, option);
            Continue();
        }
    }
}
