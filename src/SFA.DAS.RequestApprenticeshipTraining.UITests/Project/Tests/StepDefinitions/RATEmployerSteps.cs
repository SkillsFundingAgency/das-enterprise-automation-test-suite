using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project;
using TechTalk.SpecFlow;
using Polly;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers;


namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RATEmployerSteps
    {
        private static ScenarioContext context;
        private readonly ScenarioContext _context;
        private readonly RATLoginHelper _rATloginHelper;
        private readonly EmployerPortalLoginHelper _employerLoginHelper = new(context);


        public RATEmployerSteps(ScenarioContext context)
        {
            _context = context;
            _rATloginHelper = new RATLoginHelper(context);
        }

    [Given(@"the user clicks on ask if training providers can run this course as employer owner")]
        public void GivenTheUserClicksOnAskIfTrainingProvidersCanRunThisCourseAsEmployerOwner() => _rATloginHelper.RATTransitionLinkPage();

        [Then(@"the Employer logs in using employer RAT Account")]
        public void ThenTheEmployerLogsInUsingEmployerRatAccount()
        {
            _employerLoginHelper.Login(context.GetUser<RATOwnerUser>(), true);
            
        }

    }
}