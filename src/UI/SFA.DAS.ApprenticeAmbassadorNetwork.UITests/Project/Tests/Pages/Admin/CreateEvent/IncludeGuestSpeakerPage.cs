namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class IncludeGuestSpeakerPage(ScenarioContext context) : AanAdminBasePage(context)
{
    protected override string PageTitle => "Does the event include guest speakers?";

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
