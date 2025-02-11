namespace SFA.DAS.Live.SmokeTests.Project.Tests.Pages;

public abstract class LiveRegistrationBasePage : VerifyBasePage
{
    protected LiveEasUser liveEasUser;

    public LiveRegistrationBasePage(ScenarioContext context) : base(context)
    {
        VerifyPage();

        liveEasUser = context.Get<LiveEasUser>();
    }
}