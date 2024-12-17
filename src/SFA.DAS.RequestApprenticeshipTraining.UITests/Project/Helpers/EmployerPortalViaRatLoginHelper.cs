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
