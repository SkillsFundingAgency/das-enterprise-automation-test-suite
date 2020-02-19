using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpAdmin
{
    [Binding]
    public class NewProviderSteps
    {
        private readonly ScenarioContext _context;

        public NewProviderSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"the admin initates an application as main route company")]
        public void GivenTheAdminInitatesAnApplicationAsMainRouteCompany()
        {
            throw new PendingStepException();
        }

    }
}
