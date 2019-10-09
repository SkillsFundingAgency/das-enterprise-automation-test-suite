using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderPermissions
    {
        private readonly ScenarioContext _context;
        private readonly EmployerStepsHelper _employerStepsHelper;

        public ProviderPermissions(ScenarioContext context)
        {
            _employerStepsHelper = new EmployerStepsHelper(context);
        }


        [Given(@"Employer grant create cohort permission to a provider")]
        public void GivenEmployerGrantCreateCohortPermissionToAProvider()
        {
            throw new PendingStepException();
        }

    }
}
