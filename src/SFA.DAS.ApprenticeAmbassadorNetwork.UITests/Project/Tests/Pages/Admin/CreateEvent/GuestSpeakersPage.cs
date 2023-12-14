namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class GuestSpeakersPage(ScenarioContext context) : AanAdminBasePage(context)
{
    protected override string PageTitle => "Confirm details of guest speaker";

    public EventDatePage AddAndDeleteGuestSpeakers(int add)
    {
        AddGuestSpeakers(add);

        int delete = RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, add);

        for (int i = 0; i < delete; i++) formCompletionHelper.ClickLinkByText("Delete");

        Continue();

        return new(context);
    }

    public CheckYourEventPage UpdateGuestSpeakers(int add)
    {
        AddGuestSpeakers(add);

        Continue();

        return new(context);
    }

    private void AddGuestSpeakers(int add)
    {
        for (int i = 1; i <= add; i++)
        {
            formCompletionHelper.ClickLinkByText("Add Speaker");

            new GuestSpeakerDetailPage(context).AddGuestSpeaker(i);
        }
    }
}
