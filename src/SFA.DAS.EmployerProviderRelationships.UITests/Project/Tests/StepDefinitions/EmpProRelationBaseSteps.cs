

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions;

public abstract class EmpProRelationBaseSteps(ScenarioContext context)
{
    protected readonly EmployerPortalLoginHelper _employerLoginHelper = new(context);

    protected readonly EmployerHomePageStepsHelper _employerHomePageHelper = new(context);

    protected readonly EmployerPermissionsStepsHelper _employerPermissionsStepsHelper = new(context);

    private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper = new(context);

    protected readonly ProviderConfig providerConfig = context.GetProviderConfig<ProviderConfig>();

    protected readonly ObjectContext objectContext = context.Get<ObjectContext>();

    protected readonly EprDataHelper eprDataHelper = context.Get<EprDataHelper>();

    private readonly RetryAssertHelper _assertHelper = context.Get<RetryAssertHelper>();

    protected readonly string[] tags = context.ScenarioInfo.Tags;

    protected (AddApprenticePermissions AddApprentice, RecruitApprenticePermissions RecruitApprentice) permissions;

    protected SearchEmployerEmailPage GoToSearchEmployerEmailPage() => new ViewEmpAndManagePermissionsPage(context).ClickAddAnEmployer().StartNowToAddAnEmployer();

    protected EmailAccountFoundPage GoToEmailAccountFoundPage() => GoToSearchEmployerEmailPage().EnterEmployerEmail();

    protected EmailAccountNotFoundPage GoToEmailAccountNotFoundPage() => GoToSearchEmployerEmailPage().EnterNewEmployerEmail();

    protected void GoToProviderRelationsHomePage()
    {
        _providerHomePageStepsHelper.GoToProviderHomePage(providerConfig, true);

        GoToUrl(UrlConfig.Relations_Provider_BaseUrl(providerConfig.Ukprn));
    }

    protected void OpenEmpInviteFromProvider()
    {
        _assertHelper.RetryOnNUnitException(() =>
        {
            SetRequestId();

            var expected = "Sent";

            var actual = eprDataHelper.RequestStatus;

            Assert.AreEqual(expected, actual, $"Waiting for Invite status to be '{expected}' for requestid - '{eprDataHelper.RequestId}', email - {eprDataHelper.EmployerEmail}");
        }, RetryTimeOut.GetTimeSpan([60, 60, 60, 45, 45, 45, 45, 45, 45]));


        GoToUrl(UrlConfig.Relations_Employer_Invite(eprDataHelper.RequestId));
    }

    protected void UpdatePermission((AddApprenticePermissions AddApprentice, RecruitApprenticePermissions RecruitApprentice) permissions)
    {
        this.permissions = permissions;

        _employerPermissionsStepsHelper.UpdateProviderPermission(providerConfig, permissions);
    }

    protected void EPRLevyUserLogin() => EPRLogin(context.GetUser<EPRLevyUser>());

    protected void EPRReLogin()
    {
        _employerHomePageHelper.GotoEmployerHomePage();

        SetRequestId();

        eprDataHelper.AgreementId = objectContext.GetAleAgreementId();
    }

    protected void EPRLogin(EPRBaseUser user)
    {
        _employerLoginHelper.Login(user, true);

        new DeleteProviderRelationinDbHelper(context).DeleteProviderRelation();
    }

    private void GoToUrl(string url) => context.Get<TabHelper>().GoToUrl(url);

    private void SetRequestId()
    {
        var request = context.Get<RelationshipsSqlDataHelper>().GetRequestId(providerConfig.Ukprn, eprDataHelper.EmployerEmail);

        objectContext.SetDebugInformation($"fetched request id from db - '{request.requestId}' with status '{request.requestStatus}'");

        eprDataHelper.RequestId = request.requestId;

        eprDataHelper.RequestStatus = request.requestStatus;
    }
}