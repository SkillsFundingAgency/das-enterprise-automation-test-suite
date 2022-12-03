using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class SetApprenticeDetailsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ReviewYourCohortStepsHelper _reviewYourCohortStepsHelper;

        public SetApprenticeDetailsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _reviewYourCohortStepsHelper = new ReviewYourCohortStepsHelper(context.Get<RetryAssertHelper>());
        }

        internal ApproveApprenticeDetailsPage SetApprenticeDetails(ApproveApprenticeDetailsPage employerReviewYourCohortPage, int numberOfApprentices)
        {
            _objectContext.SetNoOfApprentices(_reviewYourCohortStepsHelper.NoOfApprentice(employerReviewYourCohortPage, numberOfApprentices));
            _objectContext.SetApprenticeTotalCost(_reviewYourCohortStepsHelper.ApprenticeTotalCost(employerReviewYourCohortPage));

            //returning new instance to capture screen shot
            return new ApproveApprenticeDetailsPage(_context);
        }
    }
}