using SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpApply
{
    [Binding]
    public class UnHappyPathSteps
    {
        private readonly ScenarioContext _context;
        private readonly RoatpApplyEnd2EndStepsHelper _end2EndStepsHelper;
        private ApplicationOverviewPage _overviewPage;
        
        public UnHappyPathSteps(ScenarioContext context)
        {
            _context = context;
            _end2EndStepsHelper = new RoatpApplyEnd2EndStepsHelper();
        }

        [When(@"the provider selects the unhappy path")]
        public void WhenTheProviderSelectsTheUnhappyPath()  => _overviewPage = _end2EndStepsHelper.CompleteSecion1_UnHappyPath(new ApplicationOverviewPage(_context));
      
        [Then(@"the provider cannot continue the journey")]
        public void ThenTheProviderCannotContinueTheJourney() => _overviewPage.VerifyExperienceAndAccreditationsStatus(StatusHelper.StatusInProgress);
    }
}
