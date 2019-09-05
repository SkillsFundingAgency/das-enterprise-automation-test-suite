using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class YourCohortRequestsPage : BasePage
    {
        protected override string PageTitle => "Your cohort requests";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        private By NumberofCohortsForReview => By.CssSelector(".block-one .bold-xxlarge");

        public YourCohortRequestsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public CohortsForReviewPage GoToCohortsReadyForReview()
        {
            var employerReadyForReviewCohorts = Convert.ToInt32(_pageInteractionHelper.GetText(NumberofCohortsForReview));
            if (employerReadyForReviewCohorts > 0)
            {
                _formCompletionHelper.ClickElement(NumberofCohortsForReview);
                return new CohortsForReviewPage(_context);
            }

            throw new Exception("No cohorts available for review");
        }
    }
}

