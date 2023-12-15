namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class IsEventAtSchoolPage(ScenarioContext context) : AanAdminBasePage(context)
{
    protected override string PageTitle => "Provide event location details";

    public NameOfTheSchoolPage SubmitIsEventAtSchoolAsYes()
    {
        EnterYesOrNoRadioOption("true");

        return new(context);
    }

    public EventOrganiserNamePage SubmitIsEventAtSchoolAsNo()
    {
        EnterYesOrNoRadioOption("false");

        return new(context);
    }
}
