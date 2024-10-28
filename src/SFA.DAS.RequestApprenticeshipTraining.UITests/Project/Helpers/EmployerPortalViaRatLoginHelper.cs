using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers;

public class EmployerPortalViaRatLoginHelper(ScenarioContext context) : EmployerPortalLoginHelper(context)
{
    public AskIfTrainingProvidersCanRunThisCoursePage LoginViaRat(RatEmployerBaseUser loginUser)
    {
        SetCredentials(loginUser, true);

        new StubSignInEmployerPage(context).Login(loginUser).Continue();

        return new(context);
    }
}
