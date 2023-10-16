namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class GuestSpeakerDetailPage : AanAdminBasePage
{
    protected override string PageTitle => "Guest speaker name";

    private static By Name => By.CssSelector("#name");

    private static By JobRoleAndOrganisation => By.CssSelector("#jobRoleAndOrganisation");

    public GuestSpeakerDetailPage(ScenarioContext context) : base(context) { }

    public GuestSpeakersPage AddGuestSpeaker(int i)
    {
        formCompletionHelper.EnterText(Name, $"{i}_{aanAdminDatahelper.GuestSpeakerName}");

        formCompletionHelper.EnterText(JobRoleAndOrganisation, $"{i}_{aanAdminDatahelper.GuestSpeakerRole}");

        Continue();

        return new(context);
    }
}
