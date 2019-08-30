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
        private readonly ApprovalsDataHelper _datahelper;
        #endregion


        private By CohortApproveOptions => By.CssSelector(".selection-button-radio");
        private By ContinueButton => By.Id("paymentPlan");

        public ProviderChooseAnOptionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _datahelper = context.Get<ApprovalsDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _tableRowHelper = context.Get<TableRowHelper>();
            VerifyPage();
        }

        public ProviderCohortApprovedPage SubmitApprove()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(CohortApproveOptions, "SaveStatus-Approve");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ProviderCohortApprovedPage(_context);
        }

        public ProviderMessageForEmployerPage SubmitApproveAndSendToEmployerForApproval()
        {
            _formCompletionHelper.SelectRadioOptionByText(CohortApproveOptions, "Approve and send to employer for approval");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ProviderMessageForEmployerPage(_context);
        }
    }

    public class ProviderMessageForEmployerPage : BasePage
    {
        protected override string PageTitle => "Choose an option";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly TableRowHelper _tableRowHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprovalsDataHelper _datahelper;
        #endregion

        private By MessageBox => By.Id("Message");
        private By SendButton => By.CssSelector(".button");

        public ProviderMessageForEmployerPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _datahelper = context.Get<ApprovalsDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _tableRowHelper = context.Get<TableRowHelper>();
            VerifyPage();
        }


        public ProviderCohortApprovedAndSentToEmployerPage SendInstructionsToEmployerForAnApprovedCohort()
        {
            _formCompletionHelper.EnterText(MessageBox, _datahelper.MessageToEmployer);
            _formCompletionHelper.ClickElement(SendButton);
            return new ProviderCohortApprovedAndSentToEmployerPage(_context);
        }
    }

    public class ProviderCohortApprovedAndSentToEmployerPage : BasePage
    {
        protected override string PageTitle => "Cohort approved and sent to employer";

        public ProviderCohortApprovedAndSentToEmployerPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }     
}
