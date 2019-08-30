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
        private readonly AddAnApprenticeHelper _addAnApprenticeHelper;

        public CreateCohortSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            var assertHelper = _context.Get<AssertHelper>();
            _addAnApprenticeHelper = new AddAnApprenticeHelper(assertHelper);
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
                var x = _addAnApprenticeHelper.AddAnApprentice(employerReviewYourCohortPage, i);
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
    }
}
