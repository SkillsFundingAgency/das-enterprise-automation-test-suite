namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Provider;

public class AddEmployerAndRequestPermissionsPage(ScenarioContext context) : PermissionBasePageForTrainingProviderPage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

    protected override string PageTitle => $"Add employer and request permissions";

    public RequestSentToEmployerPage ProviderRequestPermissions((AddApprenticePermissions cohortpermission, RecruitApprenticePermissions recruitpermission) permisssion)
    {
        SetAddApprentice(permisssion.cohortpermission);

        SetRecruitApprentice(permisssion.recruitpermission);

        return new(context);
    }
}

public class RequestPermissionsPage(ScenarioContext context) : PermissionBasePageForTrainingProviderPage(context)
{
    protected override string PageTitle => $"Request permissions";

    public RequestSentToEmployerPage ProviderRequestPermissions((AddApprenticePermissions cohortpermission, RecruitApprenticePermissions recruitpermission) permisssion)
    {
        SetAddApprentice(permisssion.cohortpermission);

        SetRecruitApprentice(permisssion.recruitpermission);

        return new(context);
    }

}
public class AccAccountRequestPermissionsPage(ScenarioContext context) : PermissionBasePageForTrainingProviderPage(context)
{
    protected override string PageTitle => $"Request permissions";
    public CheckEmployerDetailsPage ProviderRequestNewPermissions((AddApprenticePermissions cohortpermission, RecruitApprenticePermissions recruitpermission) permisssion)
    {
        SetAddApprentice(permisssion.cohortpermission);

        SetRecruitApprentice(permisssion.recruitpermission);

        Continue();

        return new(context);
    }
}
