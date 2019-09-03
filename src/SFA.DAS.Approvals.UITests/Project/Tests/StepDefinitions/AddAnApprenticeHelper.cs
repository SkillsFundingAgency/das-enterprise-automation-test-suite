using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    internal class AddAnApprenticeHelper
    {
        private readonly AssertHelper _assertHelper;

        internal AddAnApprenticeHelper(AssertHelper assertHelper)
        {
            _assertHelper = assertHelper;
        }

        internal CohortSentYourTrainingProviderPage EmployerCreateCohort(ApprenticesHomePage apprenticesHomePage)
        {
            return ConfirmProviderDetailsAreCorrect(apprenticesHomePage)
               .EmployerSendsToProviderToAddApprentices()
               .SendInstructionsToProviderForEmptyCohort();
        }

        internal ReviewYourCohortPage EmployerAddApprentice(ApprenticesHomePage apprenticesHomePage)
        {
          return ConfirmProviderDetailsAreCorrect(apprenticesHomePage)
                .EmployerAddsApprentices();
        }

        internal ReviewYourCohortPage AddApprentices(ReviewYourCohortPage employerReviewYourCohortPage, int numberOfApprentices, ObjectContext _objectContext)
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


        internal (string noOfApprentice, string apprenticeTotalCost) AddAnApprentice(ReviewYourCohortPage employerReviewYourCohortPage, int count)
        {
            employerReviewYourCohortPage
                .SelectAddAnApprentice()
                .SubmitValidApprenticeDetails();

            string apprenticeTotalCost = SetApprenticeTotalCost(employerReviewYourCohortPage);

            string noOfApprentice = SetNoOfApprentice(employerReviewYourCohortPage, count);

            return (noOfApprentice, apprenticeTotalCost);
        }

        internal void SetCohortReference(ObjectContext objectContext, string cohortReference)
        {
            objectContext.SetCohortReference(cohortReference);

            TestContext.Progress.WriteLine($"Cohort Reference: {cohortReference}");
        }

        internal string SetApprenticeTotalCost(ReviewYourCohortPage employerReviewYourCohortPage)
        {
            string apprenticeTotalCost = string.Empty;

            _assertHelper.RetryOnNUnitException(() =>
            {
                apprenticeTotalCost = employerReviewYourCohortPage.ApprenticeTotalCost();

                Assert.AreNotEqual("£0", apprenticeTotalCost, "Apprentice cost is not added");
            });

            return apprenticeTotalCost;
        }

        internal string SetNoOfApprentice(ReviewYourCohortPage employerReviewYourCohortPage, int count)
        {
            string noOfApprentice = string.Empty;

            _assertHelper.RetryOnNUnitException(() =>
            {
                noOfApprentice = employerReviewYourCohortPage.NoOfApprentice();

                Assert.AreEqual(count.ToString(), noOfApprentice, "Apprentice count is not added");
            });

            return noOfApprentice;
        }
        private StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect(ApprenticesHomePage apprenticesHomePage)
        {
            return apprenticesHomePage
                .AddAnApprentice()
                .StartNow()
                .SubmitValidUkprn()
                .ConfirmProviderDetailsAreCorrect();
        }

    }
}
