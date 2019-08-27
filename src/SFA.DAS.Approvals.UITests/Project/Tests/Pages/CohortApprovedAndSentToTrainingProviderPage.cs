using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using OpenQA.Selenium;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages
{
    public class CohortApprovedAndSentToTrainingProviderPage : BasePage
    {
        protected override string PageTitle => "Cohort approved and sent to training provider";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        private readonly ApprovalsDataHelper _dataHelper;
        private readonly RegexHelper _regexHelper;
        #endregion

        private By Instructions => By.CssSelector(".instructionSent tbody");

        public CohortApprovedAndSentToTrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _dataHelper = context.Get<ApprovalsDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _regexHelper = context.Get<RegexHelper>();
            VerifyPage();
        }

        internal string CohortReference()
        {
            var reference = _pageInteractionHelper.GetRowData(Instructions, "Cohort reference");
            return _regexHelper.GetCohortReference(reference);
        }
    }
}