namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class IncludeGuestSpeakerPage : AanAdminBasePage
{
    protected override string PageTitle => "Does the event include guest speakers?";

    public IncludeGuestSpeakerPage(ScenarioContext context) : base(context) { }

    public GuestSpeakersPage SubmitGuestSpeakerAsYes()
    {
        EnterYesOrNoRadioOption("true");

        return new(context);
    }

    public EventDatePage SubmitGuestSpeakerAsNo()
    {
        EnterYesOrNoRadioOption("false");

        return new(context);
    }
}
