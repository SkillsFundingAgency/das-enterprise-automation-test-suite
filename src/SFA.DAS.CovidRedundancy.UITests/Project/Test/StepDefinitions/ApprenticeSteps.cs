using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.StepDefinitions
{
    [Binding]
    public class ApprenticeSteps
    {
        private readonly ScenarioContext _context;

        public ApprenticeSteps(ScenarioContext context) => _context = context;

        [Given(@"the Apprentice Lands on Apprentice details form")]
        public void GivenTheApprenticeLandsOnApprenticeDetailsForm()  => new NewApprenticeshipLandingPage(_context).SelectAprpenticesStartnow();

    }
}
