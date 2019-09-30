using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    internal class ReviewYourCohortStepsHelper
    {
        private readonly AssertHelper _assertHelper;
        internal ReviewYourCohortStepsHelper(AssertHelper assertHelper)
        {
            _assertHelper = assertHelper;
        }

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
    }
}
