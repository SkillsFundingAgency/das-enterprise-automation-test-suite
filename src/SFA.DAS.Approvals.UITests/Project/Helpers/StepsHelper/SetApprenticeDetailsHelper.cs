using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class SetApprenticeDetailsHelper(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        private readonly ReviewYourCohortStepsHelper _reviewYourCohortStepsHelper = new(context.Get<RetryAssertHelper>());

        internal ApproveApprenticeDetailsPage SetApprenticeDetails(ReviewYourCohort reviewYourCohort, int numberOfApprentices)
        {
            SetNoOfApprentices(_reviewYourCohortStepsHelper.NoOfApprentice(reviewYourCohort, numberOfApprentices));
            
            return SetApprenticeTotalCost(reviewYourCohort);
        }

        internal ApproveApprenticeDetailsPage SetApprenticeDetails(ReviewYourCohort reviewYourCohort)
        {
            SetNoOfApprentices(ReviewYourCohortStepsHelper.GetNoOfApprentice(reviewYourCohort));
            
            return SetApprenticeTotalCost(reviewYourCohort);           
        }

        internal ApproveApprenticeDetailsPage SetApprenticeTotalCost(ReviewYourCohort reviewYourCohort)
        {
            _objectContext.SetApprenticeTotalCost(_reviewYourCohortStepsHelper.ApprenticeTotalCost(reviewYourCohort));

            //returning new instance to capture screen shot
            return new ApproveApprenticeDetailsPage(context);
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

            internal static int GetNoOfApprentice(ReviewYourCohort reviewYourCohortPage) => reviewYourCohortPage.TotalNoOfApprentices();
        }

    }
}