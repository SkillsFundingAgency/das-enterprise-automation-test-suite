namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class GuestSpeakerDetailPage(ScenarioContext context) : AanAdminBasePage(context)
{
    protected override string PageTitle => "Guest speaker name";

    private static By Name => By.CssSelector("#name");

    private static By JobRoleAndOrganisation => By.CssSelector("#jobRoleAndOrganisation");

    public GuestSpeakersPage AddGuestSpeaker(int i)
    {
        formCompletionHelper.EnterText(Name, $"{i}_{aanAdminCreateEventDatahelper.GuestSpeakerName}");

        formCompletionHelper.EnterText(JobRoleAndOrganisation, $"{i}_{aanAdminCreateEventDatahelper.GuestSpeakerRole}");

        Continue();

        return new(context);
    }
}
