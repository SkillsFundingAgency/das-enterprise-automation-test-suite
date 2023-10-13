namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class GuestSpeakersPage : AanAdminBasePage
{
    protected override string PageTitle => "Guest Speakers";

    public GuestSpeakersPage(ScenarioContext context) : base(context) { }

    public EventDatePage AddAndDeleteGuestSpeakers(int add)
    {
        for (int i = 1; i <= add; i++)
        {
            formCompletionHelper.ClickLinkByText("Add Speaker");

            new GuestSpeakerDetailPage(context).AddGuestSpeaker(i);
        }

        int delete = RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, add);

        for (int i = 0; i < delete; i++) formCompletionHelper.ClickLinkByText("Delete");

        Continue();

        return new(context);
    }
}
