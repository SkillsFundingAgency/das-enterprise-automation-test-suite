using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    public class AddAnApprenticeHelper
    {
        private readonly AssertHelper _assetHelper;

        public AddAnApprenticeHelper(AssertHelper assertHelper)
        {
            _assetHelper = assertHelper;
        }


        public ReviewYourCohortPage EmployerNavigateToAddAnApprentice(ApprenticesHomePage apprenticesHomePage)
        {
            return apprenticesHomePage
                .AddAnApprentice()
                .StartNow()
                .SubmitValidUkprn()
                .ConfirmProviderDetailsAreCorrect()
                .EmployerAddsApprentices();
        }

        public ReviewYourCohortPage AddApprentices(ReviewYourCohortPage employerReviewYourCohortPage, int numberOfApprentices, ObjectContext _objectContext)
        {
            string noOfApprentice = string.Empty, apprenticeTotalCost = string.Empty;

            for (int i = 1; i <= numberOfApprentices; i++)
            {
                var x = AddAnApprentice(employerReviewYourCohortPage, i);
                noOfApprentice = x.noOfApprentice;
                apprenticeTotalCost = x.apprenticeTotalCost;
            }

            _objectContext.SetNoOfApprentices(noOfApprentice);
            _objectContext.SetApprenticeTotalCost(apprenticeTotalCost);

            return employerReviewYourCohortPage;

        }


        public (string noOfApprentice, string apprenticeTotalCost) AddAnApprentice(ReviewYourCohortPage employerReviewYourCohortPage, int count)
        {
            string noOfApprentice = string.Empty, apprenticeTotalCost = string.Empty;

            employerReviewYourCohortPage
                .SelectAddAnApprentice()
                .SubmitValidApprenticeDetails();

            _assetHelper.RetryOnNUnitException(() =>
            {
                apprenticeTotalCost = employerReviewYourCohortPage.ApprenticeTotalCost();

                Assert.AreNotEqual("£0", apprenticeTotalCost, "Apprentice cost is not added");
            });

            _assetHelper.RetryOnNUnitException(() =>
            {
                noOfApprentice = employerReviewYourCohortPage.NoOfApprentice();

                Assert.AreEqual(count.ToString(), noOfApprentice, "Apprentice count is not added");
            });

            return (noOfApprentice, apprenticeTotalCost);
        }
    }
}
