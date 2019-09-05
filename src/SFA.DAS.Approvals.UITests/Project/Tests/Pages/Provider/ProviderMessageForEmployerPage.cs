using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderMessageForEmployerPage : BasePage
    {
        protected override string PageTitle => "Message for employer";

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
        public  ProviderCohortSentForReviewPage SendInstructionsToEmployerForCohortToReview()
        {
            _formCompletionHelper.EnterText(MessageBox, _datahelper.MessageToEmployer);
            _formCompletionHelper.ClickElement(SendButton);
            return new ProviderCohortSentForReviewPage(_context);
        }
    }
}
