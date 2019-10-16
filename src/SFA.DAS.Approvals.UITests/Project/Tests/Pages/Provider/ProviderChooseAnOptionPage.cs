using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderChooseAnOptionPage : BasePage
    {
        protected override string PageTitle => "Choose an option";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly TableRowHelper _tableRowHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprenticeDataHelper _datahelper;
        #endregion

        private By CohortApproveOptions => By.CssSelector(".selection-button-radio");
        private By ContinueButton => By.Id("paymentPlan");

        public ProviderChooseAnOptionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _datahelper = context.Get<ApprenticeDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _tableRowHelper = context.Get<TableRowHelper>();
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

        public ProviderCohortSavedPage SubmitSaveButDontSendToEmployer()
        {
            SelectOption("SaveStatus-Save");
            return new ProviderCohortSavedPage(_context);
        }

        private void SelectOption(string option)
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(CohortApproveOptions, option);
            _formCompletionHelper.ClickElement(ContinueButton);
        }
    }
}
