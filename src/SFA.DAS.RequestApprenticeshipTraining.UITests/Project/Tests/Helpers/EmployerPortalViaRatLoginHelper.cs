using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages;
using TechTalk.SpecFlow;


namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Helpers
{
    public class EmployerPortalViaRatLoginHelper(ScenarioContext context) : EmployerPortalLoginHelper(context)
    {
        public AskIfTrainingProvidersCanRunThisCoursePage LoginViaRat(RATOwnerUser loginUser)
        {
            new StubSignInEmployerPage(context).Login(loginUser).Continue();

            SetCredentials(loginUser, true);

            return new(context);
        }

    }
}