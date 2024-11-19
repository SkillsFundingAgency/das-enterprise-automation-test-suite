

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions;

[Binding]
public class EmployerRelationSteps(ScenarioContext context) : EmpProRelationBaseSteps(context)
{
    [Given(@"Levy employer grants all permission to a provider")]
    public void LevyEmployerGrantsAllPermissionToAProvider()
    {
        permissions = (AddApprenticePermissions.AllowConditional, RecruitApprenticePermissions.Allow);

        EPRLevyUserLogin();

        _employerPermissionsStepsHelper.SetAllProviderPermissions(providerConfig);
    }

    [When(@"the employer changes recruit apprentice permission")]
    public void TheEmployerChangesRecruitApprenticePermission()
    {
        EmployerUpdatePermission((AddApprenticePermissions.AllowConditional, RecruitApprenticePermissions.AllowConditional));
    }

    [When(@"the provider does not grant any permission")]
    public void WhenTheProviderDoesNotGrantAnyPermission()
    {
        EmployerUpdatePermission((AddApprenticePermissions.DoNotAllow, RecruitApprenticePermissions.DoNotAllow));
    }

    [Then(@"an employer has to select at least one permission")]
    public void ThenAnEmployerHasToSelectAtLeastOnePermission()
    {
        EPRLevyUserLogin();

        new ManageTrainingProvidersLinkHomePage(context).OpenRelationshipPermissions()
            .SelectAddATrainingProvider()
            .SearchForATrainingProvider(providerConfig)
            .VerifyDoNotAllowPermissions();
    }

    [Then(@"the provider should be added with the correct permissions")]
    public void TheProviderShouldBeAddedWithTheCorrectPermissions()
    {
        var page = _employerPermissionsStepsHelper.OpenProviderPermissions();

        var providersOnthePage = context.Get<TableRowHelper>().GetTableRows(linkcolumnName: "Permissions");

        var actual = providersOnthePage.Single(x => x["Permissions"].ContainsCompareCaseInsensitive(providerConfig.Ukprn));

        Assert.Multiple(() =>
        {
            Assert.That(actual["Permission to add apprentice records"], Is.EqualTo(EnumToString.GetStringValue(permissions.AddApprentice)), "Incorrect add apprentice permission trainning provider page");

            Assert.That(actual["Permission to recruit apprentices"], Is.EqualTo(EnumToString.GetStringValue(permissions.RecruitApprentice)), "Incorrect add apprentice permission trainning provider page");
        });

        page.GoToHomePage();
    }

    [Then(@"the employer is unable to add an existing provider")]
    public void ThenTheEmployerIsUnableToAddAnExistingProvider()
    {
        new ManageTrainingProvidersLinkHomePage(context).OpenRelationshipPermissions()
            .SelectAddATrainingProvider()
            .SearchForAnExistingTrainingProvider(providerConfig);

        new AlreadyLinkedToTrainingProviderPage(context).CannotAddExistingTrainingProvider();
    }

    [Then(@"the employer accepts the add account request")]
    public void TheEmployerAcceptsTheAddAccountRequest()
    {
        EPRReLoginAcceptOrDeclineProviderPermissionsRequest(RequestType.AddAccount, true);
    }

    [Then(@"the employer declines the add account request")]
    public void TheEmployerDeclinesTheAddAccountRequest()
    {
        EPRReLoginAcceptOrDeclineProviderPermissionsRequest(RequestType.AddAccount, false);
    }

    [Then(@"the employer declines the update permission request")]
    public void TheEmployerDeclinesTheUpdatePermissionRequest()
    {
        EPRReLoginAcceptOrDeclineProviderPermissionsRequest(RequestType.Permission, false);
    }

    [Then(@"the employer accepts the update permission request")]
    public void TheEmployerAcceptsTheUpdatePermissionRequest()
    {
        EPRReLoginAcceptOrDeclineProviderPermissionsRequest(RequestType.Permission, true);
    }

    private void EPRReLoginAcceptOrDeclineProviderPermissionsRequest(RequestType requestType, bool doesAllow)
    {
        EPRReLogin(requestType);

        _employerPermissionsStepsHelper.AcceptOrDeclineProviderRequest(requestType, providerConfig, eprDataHelper.LatestRequestId, doesAllow);
    }

}