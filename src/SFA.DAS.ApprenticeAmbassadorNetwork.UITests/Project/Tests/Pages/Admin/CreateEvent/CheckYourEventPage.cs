namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class CheckYourEventPage : AanAdminBasePage
{
    protected override string PageTitle => "Check your event before publishing";

    public CheckYourEventPage(ScenarioContext context) : base(context) { }

    public SucessfullyPublisedEventPage SubmitEvent()
    {
        Continue();

        return new SucessfullyPublisedEventPage(context);
    }
}
