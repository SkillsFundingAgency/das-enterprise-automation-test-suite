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
        private By NumberOfTransferRejectedCohorts => By.CssSelector(".block-five .bold-xxlarge");

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

        public RejectedTransferRequestsPage GoToRejectedTransferRequests()
        {
            int employerRejectedTransferRequests = Convert.ToInt32(_pageInteractionHelper.GetText(NumberOfTransferRejectedCohorts));
            if (employerRejectedTransferRequests > 0)
            {
                _formCompletionHelper.ClickElement(NumberOfTransferRejectedCohorts);
                return new RejectedTransferRequestsPage(_context);
            }
            throw new Exception("No cohorts available with Employer in Rejected Transfers Request Status");
        }
    }

    public class RejectedTransferRequestsPage : BasePage
    {
        protected override string PageTitle => "Rejected transfer requests";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprovalsConfig _config;
        #endregion

        private By CohortInfoRow => By.CssSelector("tbody tr");
        private By CohortEditLink => By.LinkText("Edit");

        public RejectedTransferRequestsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ReviewYourCohortPage OpenRejectedCohort()
        {
            var cohortRows = _pageInteractionHelper.FindElements(CohortInfoRow);
            var cohortEditLinks = _pageInteractionHelper.FindElements(CohortEditLink);
            int i = 0;

            foreach (IWebElement cohortRow in cohortRows)
            {
                if ((cohortRow.Text.Contains(_objectContext.GetCohortReference())))
                {
                    _formCompletionHelper.ClickElement(cohortEditLinks[i]);
                    break;
                }
                i++;
            }
            return new ReviewYourCohortPage(_context);
        }
    }
}

