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
            var employerReviewYourCohortPage = _addAnApprenticeHelper.EmployerNavigateToAddAnApprentice(new ApprenticesHomePage(_context, true));

            employerReviewYourCohortPage = _addAnApprenticeHelper.AddApprentices(employerReviewYourCohortPage, numberOfApprentices, _objectContext);

            var cohortReference = employerReviewYourCohortPage.SaveAndContinue()
                .SubmitApproveAndSendToTrainingProvider()
                .SendInstructionsToProviderForAnApprovedCohort()
                .CohortReference();

            _addAnApprenticeHelper.SetCohortReference(_objectContext, cohortReference);
        }
    }
}
