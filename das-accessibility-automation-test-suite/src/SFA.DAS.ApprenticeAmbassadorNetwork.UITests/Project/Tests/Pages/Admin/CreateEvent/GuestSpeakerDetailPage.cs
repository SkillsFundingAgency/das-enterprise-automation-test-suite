namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class GuestSpeakerDetailPage(ScenarioContext context) : AanAdminBasePage(context)
{
    protected override string PageTitle => "Guest speaker name";

    private static By Name => By.CssSelector("input#Name");

    private static By JobRoleAndOrganisation => By.CssSelector("input#JobRoleAndOrganisation");

    public GuestSpeakersPage AddGuestSpeaker(int i)
    {
        formCompletionHelper.EnterText(Name, $"{i}_{AanAdminCreateEventBaseDatahelper.GuestSpeakerName}");

        formCompletionHelper.EnterText(JobRoleAndOrganisation, $"{i}_{AanAdminCreateEventBaseDatahelper.GuestSpeakerRole}");

        Continue();

        return new(context);
    }
}
