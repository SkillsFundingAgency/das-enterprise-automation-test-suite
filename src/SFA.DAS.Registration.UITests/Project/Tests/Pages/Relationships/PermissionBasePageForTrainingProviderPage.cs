namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;

public abstract class PermissionBasePageForTrainingProviderPage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
{
    protected static By ApprenticeAllowRadioOption => By.Id("addRecords-1");
    protected static By ApprenticeDoNotAllowRadioOption => By.Id("addRecords-2");

    protected static By RecruitAllowRadioOption => By.Id("recruitApprentices-1");
    protected static By RecruitAllowConditionalRadioOption => By.Id("recruitApprentices-2");
    protected static By RecruitDoNotAllowRadioOption => By.Id("recruitApprentices-3");


    protected static By AllowRequestOption => By.Id("acceptAddAccountRequestYes");
    protected static By DeclineRequestOption => By.Id("acceptAddAccountRequestNo");

    protected static By ErrorMsg => By.CssSelector(".govuk-error-summary");

    public ManageTrainingProvidersPage AcceptProviderRequest()
    {
        ContinueToConfirm(AllowRequestOption);

        return new(context);
    }

    public AreYouSureYouDoNotWantToAddPage DeclineRequest()
    {
        ContinueToConfirm(DeclineRequestOption);

        return new(context);
    }

    public ManageTrainingProvidersPage AddOrSetPermissions((AddApprenticePermissions cohortpermission, RecruitApprenticePermissions recruitpermission) permisssion)
    {
        SetAddApprentice(permisssion.cohortpermission);

        SetRecruitApprentice(permisssion.recruitpermission);

        return new(context);
    }

    public EmployerAccountCreatedPage AddOrSetPermissionsAndCreateAccount((AddApprenticePermissions cohortpermission, RecruitApprenticePermissions recruitpermission) permisssion)
    {
        SetAddApprentice(permisssion.cohortpermission);

        SetRecruitApprentice(permisssion.recruitpermission);

        return new(context);
    }

    protected void SetAddApprentice(AddApprenticePermissions permission)
    {
        void Continue(By by) => javaScriptHelper.ClickElement(by);

        switch (permission)
        {
            case AddApprenticePermissions.AllowConditional: Continue(ApprenticeAllowRadioOption); break;
            case AddApprenticePermissions.DoNotAllow: Continue(ApprenticeDoNotAllowRadioOption); break;
        };
    }

    protected void SetRecruitApprentice(RecruitApprenticePermissions permission)
    {
        switch (permission)
        {
            case RecruitApprenticePermissions.Allow: ContinueToConfirm(RecruitAllowRadioOption); break;
            case RecruitApprenticePermissions.AllowConditional: ContinueToConfirm(RecruitAllowConditionalRadioOption); break;
            case RecruitApprenticePermissions.DoNotAllow: ContinueToConfirm(RecruitDoNotAllowRadioOption); break;
        };
    }

    private void ContinueToConfirm(By by)
    {
        javaScriptHelper.ClickElement(by);

        Continue();
    }
}
