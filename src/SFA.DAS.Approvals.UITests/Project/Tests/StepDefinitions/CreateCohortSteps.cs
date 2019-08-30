using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateCohortSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly AssertHelper _assetHelper;

        public CreateCohortSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _assetHelper = _context.Get<AssertHelper>();
        }

        [When(@"the Employer approves (.*) cohort and sends to provider")]
        public void TheEmployerApprovesCohortAndSendsToProvider(int numberOfApprentices)
        {
            string noOfApprentice = string.Empty, apprenticeTotalCost = string.Empty;

            var employerReviewYourCohortPage = new ApprenticesHomePage(_context, true)
                .GoToApprenticesHomePage()
                .AddAnApprentice()
                .StartNow()
                .SubmitValidUkprn()
                .ConfirmProviderDetailsAreCorrect()
                .EmployerAddsApprentices();

            for (int i = 1; i <= numberOfApprentices; i++)
            {
                var x = AddAnApprentice(employerReviewYourCohortPage, i);
                noOfApprentice = x.noOfApprentice;
                apprenticeTotalCost = x.apprenticeTotalCost;
            }

            _objectContext.SetNoOfApprentices(noOfApprentice);
            _objectContext.SetApprenticeTotalCost(apprenticeTotalCost);

            var cohortReference = employerReviewYourCohortPage.SaveAndContinue()
                .SubmitApproveAndSendToTrainingProvider()
                .SendInstructionsToProviderForAnApprovedCohort()
                .CohortReference();

            _objectContext.SetCohortReference(cohortReference);

            TestContext.Progress.WriteLine($"Cohort Reference: {cohortReference}");
        }

        private (string noOfApprentice, string apprenticeTotalCost) AddAnApprentice(ReviewYourCohortPage employerReviewYourCohortPage, int count)
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
