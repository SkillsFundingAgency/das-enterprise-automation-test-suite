namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class NameOfTheSchoolPage : AanAdminBasePage
{
    protected override string PageTitle => "Name of the school";

    public NameOfTheSchoolPage(ScenarioContext context) : base(context) { }

    public EventOrganiserNamePage SubmitSchoolName()
    {
        EnterSchoolName(aanAdminCreateEventDatahelper);

        return new(context);
    }

    public CheckYourEventPage UpdateSchoolName()
    {
        EnterSchoolName(aanAdminUpdateEventDatahelper);

        return new(context);
    }

    private void EnterSchoolName(AanAdminCreateEventBaseDatahelper datahelper)
    {
        SelectAutoDropDown(datahelper.EventSchoolName);

        Continue();
    }
}
