namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

public class NameOfTheSchoolPage(ScenarioContext context) : AanAdminBasePage(context)
{
    protected override string PageTitle => "Name of the school";

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
