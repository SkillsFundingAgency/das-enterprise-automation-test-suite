namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class IsEventAtSchoolPage : AanAdminBasePage
{
    protected override string PageTitle => "Is this event held at a school?";

    public IsEventAtSchoolPage(ScenarioContext context) : base(context) { }

    public NameOfTheSchoolPage SubmitIsEventAtSchoolAsYes()
    {
        SelectRadioOptionByForAttribute("true");

        Continue();

        return new(context);
    }

    public EventOrganiserNamePage SubmitIsEventAtSchoolAsNo()
    {
        SelectRadioOptionByForAttribute("false");

        Continue();

        return new(context);
    }
}
