
namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions;

[Binding]
public class ProviderCreateAccountSteps(ScenarioContext context) : EmpProRelationBaseSteps(context)
{
    [Given(@"a provider requests employer to create account with all permission")]
    public void AProviderRequestsEmployerToCreateAccountWithAllPermission()
    {
        GoToProviderAddAnEmployer();

        eprDataHelper.EmployerEmail = objectContext.GetRegisteredEmail();

        new AddAnEmployerPage(context).StartNowToAddAnEmployer().EnterNewEmployerEmail().SubmitPayeAndContinueToInvite().SubmitEmployerName().SendInvitation().GoToViewEmployersPage().VerifyPendingRequest();

        SetRequestId(RequestType.CreateAccount);
    }

    [Then(@"the employer declines the create account request")]
    public void TheEmployerDeclinesTheCreateAccountRequest()
    {
        OpenEmpInviteFromProviderAndRegister().ReadAgreement(eprDataHelper.EmployerOrganisationName).ReturnToCreateYourApprenticeshipServiceAccountr().DoNotCreateAccount().ConfirmDoNotCreateAccount();
    }

    [Then(@"the employer accepts the create account request")]
    public void TheEmployerAcceptsTheCreateAccountRequest()
    {
        OpenEmpInviteFromProviderAndRegister().ChangeName().ChangeName(eprDataHelper.EmployerFirstName, eprDataHelper.EmployerLastName).CreateAccount().GoToHomePage();
    }

    private CreateYourApprenticeshipServiceAccount OpenEmpInviteFromProviderAndRegister()
    {
        OpenEmpInviteFromProvider();

        new StubSignInEmployerPage(context).Register().Continue();

        return new CreateYourApprenticeshipServiceAccount(context);
    }
}