using SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers;
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
        private readonly ApprenticeHeleprs _apprenticeHelpers;
        private ApprenticeConfirmationPage _apprenticeConfirmationPage;
        private NewApprenticeshipLandingPage _newApprenticeshipLandingPage;

        public ApprenticeSteps(ScenarioContext context)
        {
              _context = context;
            _apprenticeHelpers = new ApprenticeHeleprs(_context);
        }

        [Given(@"the Apprentice Lands on Apprentice details form")]
        public void GivenTheApprenticeLandsOnApprenticeDetailsForm() => _apprenticeConfirmationPage = _apprenticeHelpers.CompleteApprenticeForm_HappyPath(_newApprenticeshipLandingPage);


            //=> new NewApprenticeshipLandingPage(_context).SelectAprpenticesStartnow().CompleteApprenticeDetails();

    }
}
