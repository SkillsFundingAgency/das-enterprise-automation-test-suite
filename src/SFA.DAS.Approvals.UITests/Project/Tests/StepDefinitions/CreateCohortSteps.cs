using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
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

        public CreateCohortSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
        }

        [When(@"the Employer approves (.*) cohort and sends to provider")]
        public void WhenTheEmployerApprovesCohortAndSendsToProvider(int numberOfApprentices)
        {
            var employerReviewYourCohortPage = new ApprenticesHomePage(_context, true)
                .GoToApprenticesHomePage()
                .AddAnApprentice()
                .StartNow()
                .SubmitValidUkprn()
                .ConfirmProviderDetailsAreCorrect()
                .EmployerAddsApprentices();

            for (int i = 0; i < numberOfApprentices; i++)
            {
                employerReviewYourCohortPage.SelectAddAnApprentice()
                    .SubmitValidApprenticeDetails();
            }

            var apprenticeTotalCost = employerReviewYourCohortPage.ApprenticeTotalCost();

            _objectContext.SetApprenticeTotalCost(apprenticeTotalCost);

            var cohortReference = employerReviewYourCohortPage.SaveAndContinue()
                .SubmitApproveAndSendToTrainingProvider()
                .SendInstructionsToProviderForAnApprovedCohort()
                .CohortReference();

            _objectContext.SetCohortReference(cohortReference);

            TestContext.Progress.WriteLine($"Cohort Reference: {cohortReference}");
        }
    }
}
