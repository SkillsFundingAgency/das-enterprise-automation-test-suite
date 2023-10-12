namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class NameOfTheSchoolPage : AanAdminBasePage
{
    protected override string PageTitle => "Name of the school";

    public NameOfTheSchoolPage(ScenarioContext context) : base(context) { }

    public EventOrganiserNamePage SubmitSchoolName()
    {
        EnterAutoSelect(aanAdminDatahelper.EventSchoolName);

        Continue();

        return new(context);
    }
}
