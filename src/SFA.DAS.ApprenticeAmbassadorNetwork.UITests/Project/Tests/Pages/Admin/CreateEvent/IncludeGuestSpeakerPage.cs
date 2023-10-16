namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class IncludeGuestSpeakerPage : AanAdminBasePage
{
    protected override string PageTitle => "Does the event include guest speakers?";

    public IncludeGuestSpeakerPage(ScenarioContext context) : base(context) { }

    public GuestSpeakersPage SubmitGuestSpeakerAsYes()
    {
        SelectRadioOptionByForAttribute("true");

        Continue();

        return new(context);
    }

    public EventDatePage SubmitGuestSpeakerAsNo()
    {
        SelectRadioOptionByForAttribute("false");

        Continue();

        return new(context);
    }
}
