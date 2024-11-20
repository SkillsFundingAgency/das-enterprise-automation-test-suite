namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;

public enum AddApprenticePermissions
{
    [ToString("Yes, employer will review records")]
    AllowConditional,
    [ToString("No")]
    DoNotAllow
}

public enum RecruitApprenticePermissions
{
    [ToString("Yes")]
    Allow,
    [ToString("Yes, employer will review adverts")]
    AllowConditional,
    [ToString("No")]
    DoNotAllow
}

public class AddAsATrainingProviderPage(ScenarioContext context, ProviderConfig providerConfig) : AddOrReviewRequestFromProvider(context)
{
    protected override string PageTitle => $"Add {providerConfig.Name.ToUpperInvariant()} as a training provider";

    protected override By AllowRequestOption => By.CssSelector("#acceptAddAccountRequestYes");
    protected override By DeclineRequestOption => By.CssSelector("#acceptAddAccountRequestNo");
}

public class ReviewPermissionsFromProviderPage(ScenarioContext context, ProviderConfig providerConfig) : AddOrReviewRequestFromProvider(context)
{
    protected override string PageTitle => $"Review permissions request from {providerConfig.Name.ToUpperInvariant()}";

    protected override By AllowRequestOption => By.CssSelector("#acceptPermissionsYes");
    protected override By DeclineRequestOption => By.CssSelector("#acceptPermissionsNo");
}

public class ManageTrainingProvidersPage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
{
    protected override string PageTitle => "Manage training providers";

    private static By ChangePermissionsLink(string ukprn) => By.CssSelector($"a[href*='providers/{ukprn}/changePermissions?']");

    private static By NotificationBanner => By.CssSelector($".govuk-notification-banner");

    private static By TableRows => By.ClassName("govuk-table__row");

    public ManageTrainingProvidersPage VerifyYouHaveAddedNotification(string providerName)
    {
        VerifyPage(NotificationBanner, $"You've added {providerName} and set their permissions.");

        return this;
    }

    public ManageTrainingProvidersPage VerifyYouHaveDeclinedNotification()
    {
        VerifyPage(NotificationBanner, "You've declined");

        return this;
    }

    public ManageTrainingProvidersPage VerifyYouHaveSetPermissionNotification(string providerName)
    {
        VerifyPage(NotificationBanner, $"You've set {providerName}’s permissions.");

        return this;
    }

    public ManageTrainingProvidersPage VerifyYouHaveSetPermissionNotification()
    {
        VerifyPage(NotificationBanner, "You've set permissions for");

        return this;
    }

    public AddAsATrainingProviderPage ViewProviderRequests(ProviderConfig providerConfig, string requestId)
    {
        OpenRequest(providerConfig, requestId);

        return new(context, providerConfig);
    }

    public ReviewPermissionsFromProviderPage ReviewProviderRequests(ProviderConfig providerConfig, string requestId)
    {
        OpenRequest(providerConfig, requestId);

        return new(context, providerConfig);
    }

    public EnterYourTrainingProviderNameReferenceNumberUKPRNPage SelectAddATrainingProvider()
    {
        formCompletionHelper.ClickButtonByText(ContinueButton, "Add a training provider");

        return new(context);
    }

    public SetPermissionsForTrainingProviderPage SelectChangePermissions(string ukprn)
    {
        formCompletionHelper.ClickElement(ChangePermissionsLink(ukprn));

        return new SetPermissionsForTrainingProviderPage(context);
    }

    private void OpenRequest(ProviderConfig providerConfig, string requestId)
    {
        VerifyFromMultipleElements(TableRows, providerConfig.Name.ToUpperInvariant());

        formCompletionHelper.Click(By.CssSelector($"a[href*='{requestId}']"));
    }
}
