using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers.RATEmployerStepHelpers;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;


namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RATEmployerSteps
    {
        private readonly ScenarioContext _context;
        private readonly RATLoginHelper _rATloginHelper;
        

        public RATEmployerSteps(ScenarioContext context)
        {
            _context = context;
            _rATloginHelper = new RATLoginHelper(context);
        }

    [Given(@"the user transitions from FAT to RAT after clicking on ask if training providers can run this course as employer owner")]
        public void GivenTheUserTransitionsFromFATToRATAfterClickingOnAskIfTrainingProvidersCanRunThisCourseAsEmployerOwner()
        {
            _rATloginHelper.RATTransitionLinkPage();
        }
    }
}