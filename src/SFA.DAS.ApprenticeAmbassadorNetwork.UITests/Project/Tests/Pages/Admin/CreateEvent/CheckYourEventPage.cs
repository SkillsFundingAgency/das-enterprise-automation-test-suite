using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class CheckYourEventPage : AanAdminBasePage
{
    protected override string PageTitle => "Check your event before publishing";

    private static By ChangeFormatSelector => By.CssSelector("a[href='/events/new/format']");

    public CheckYourEventPage(ScenarioContext context) : base(context) { }

    public SucessfullyPublisedEventPage SubmitEvent()
    {
        Continue();

        return new SucessfullyPublisedEventPage(context);
    }

    public EventPreviewPage GoToEventPreviewPage(EventFormat eventFormat)
    {
        formCompletionHelper.ClickLinkByText("preview the event here");

        return new EventPreviewPage(context, eventFormat);
    }

    public EventFormatPage ChangeEventFormat() 
    {
        formCompletionHelper.Click(ChangeFormatSelector);

        return new EventFormatPage(context);
    }
}
