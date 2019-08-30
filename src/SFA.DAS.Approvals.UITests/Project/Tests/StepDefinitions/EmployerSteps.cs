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
    public class EmployerSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly AddAnApprenticeHelper _addAnApprenticeHelper;

        public EmployerSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            var assertHelper = _context.Get<AssertHelper>();
            _addAnApprenticeHelper = new AddAnApprenticeHelper(assertHelper);
        }

        [When(@"the Employer adds (.*) cohort and sends to provider")]
        public void WhenTheEmployerAddsCohortAndSendsToProvider(int numberOfApprentices)
        {
            string noOfApprentice = string.Empty, apprenticeTotalCost = string.Empty;

            var employerReviewYourCohortPage = _addAnApprenticeHelper.EmployerNavigateToAddAnApprentice(new ApprenticesHomePage(_context, true));

            employerReviewYourCohortPage = _addAnApprenticeHelper.AddApprentices(employerReviewYourCohortPage, numberOfApprentices, _objectContext);

            var cohortReference = employerReviewYourCohortPage.SaveAndContinue()
                .SubmitSendToTrainingProviderForReview()
                .SendInstructionsToProviderForCohortToBeReviewed()
                .CohortReference();

            _objectContext.SetCohortReference(cohortReference);

            TestContext.Progress.WriteLine($"Cohort Reference: {cohortReference}");
        }

        [Then(@"the Employer approves the cohorts")]
        public void ThenTheEmployerApprovesTheCohorts()
        {
            throw new PendingStepException();
        }

    }
}
