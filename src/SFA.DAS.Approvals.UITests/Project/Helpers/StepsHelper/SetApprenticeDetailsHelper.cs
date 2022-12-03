using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
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

        internal ApproveApprenticeDetailsPage SetApprenticeDetails(ReviewYourCohort reviewYourCohort, int numberOfApprentices)
        {
            SetNoOfApprentices(_reviewYourCohortStepsHelper.NoOfApprentice(reviewYourCohort, numberOfApprentices));
            
            return SetApprenticeTotalCost(reviewYourCohort);
        }

        internal ApproveApprenticeDetailsPage SetApprenticeDetails(ReviewYourCohort reviewYourCohort)
        {
            SetNoOfApprentices(_reviewYourCohortStepsHelper.GetNoOfApprentice(reviewYourCohort));
            
            return SetApprenticeTotalCost(reviewYourCohort);           
        }

        internal ApproveApprenticeDetailsPage SetApprenticeTotalCost(ReviewYourCohort reviewYourCohort)
        {
            _objectContext.SetApprenticeTotalCost(_reviewYourCohortStepsHelper.ApprenticeTotalCost(reviewYourCohort));

            //returning new instance to capture screen shot
            return new ApproveApprenticeDetailsPage(_context);
        }

        private void SetNoOfApprentices(int value) => _objectContext.SetNoOfApprentices(value);

        private class ReviewYourCohortStepsHelper
        {
            private readonly RetryAssertHelper _assertHelper;

            internal ReviewYourCohortStepsHelper(RetryAssertHelper assertHelper) => _assertHelper = assertHelper;

            internal string ApprenticeTotalCost(ReviewYourCohort reviewYourCohortPage)
            {
                string apprenticeTotalCost = string.Empty;

                _assertHelper.RetryOnNUnitException(() =>
                {
                    apprenticeTotalCost = reviewYourCohortPage.ApprenticeTotalCost();

                    Assert.AreNotEqual("£0", apprenticeTotalCost, "Apprentice cost is not added");
                });

                return apprenticeTotalCost;
            }

            internal int NoOfApprentice(ReviewYourCohort reviewYourCohortPage, int count)
            {
                int noOfApprentice = 0;

                _assertHelper.RetryOnNUnitException(() =>
                {
                    noOfApprentice = reviewYourCohortPage.TotalNoOfApprentices();

                    Assert.AreEqual(count, noOfApprentice, "Apprentice count is not added");
                });

                return noOfApprentice;
            }

            internal int GetNoOfApprentice(ReviewYourCohort reviewYourCohortPage) => reviewYourCohortPage.TotalNoOfApprentices();
        }

    }
}