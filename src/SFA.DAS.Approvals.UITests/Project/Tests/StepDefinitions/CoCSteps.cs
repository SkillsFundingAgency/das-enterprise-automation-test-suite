using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CoCSteps
    {
        private readonly ScenarioContext _context;

        private readonly ExistingAccountsStepsHelper _stepsHelper;

        private readonly EmployerStepsHelper _employerStepsHelper;

        private readonly ProviderStepsHelper _providerStepsHelper;

        public CoCSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new ExistingAccountsStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
        }

        [Given(@"the Employer has approved apprentice")]
        public void GivenTheEmployerHasApprovedApprentice()
        {
            _stepsHelper.Login(_context.GetUser<LevyUser>(), true);

            var employerReviewYourCohortPage = _employerStepsHelper.EmployerAddApprentice(1);

            var cohortReference = employerReviewYourCohortPage.SaveAndContinue()
                .SubmitApproveAndSendToTrainingProvider()
                .SendInstructionsToProviderForAnApprovedCohort()
                .CohortReference();

            _employerStepsHelper.SetCohortReference(cohortReference);

            var providerReviewYourCohortPage = _providerStepsHelper.EditApprentice();

            providerReviewYourCohortPage.SelectContinueToApproval()
                            .SubmitApprove();
        }

    }
}
