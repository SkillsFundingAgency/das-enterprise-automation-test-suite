using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using OpenQA.Selenium;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class MessageForYourTrainingProviderPage : BasePage
    {
        protected override string PageTitle => "Message for your training provider";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        private readonly ApprovalsDataHelper _dataHelper;
        #endregion

        private By MessageBox => By.Id("Message");
        private By SendButton => By.CssSelector(".button");

        public MessageForYourTrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _dataHelper = context.Get<ApprovalsDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public CohortApprovedAndSentToTrainingProviderPage SendInstructionsToProviderForAnApprovedCohort()
        {
            _formCompletionHelper.EnterText(MessageBox, _dataHelper.MessageToProvider);
            _formCompletionHelper.ClickElement(SendButton);
            return new CohortApprovedAndSentToTrainingProviderPage(_context);
        }
    }
}