

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions;

[Binding]
public class ProviderCreateAccountSteps(ScenarioContext context) : EmpProRelationBaseSteps(context)
{
    [Given(@"a provider requests employer to create account with all permission")]
    public void AProviderRequestsEmployerToCreateAccountWithAllPermission()
    {
        GoToProviderRelationsHomePage();

        eprDataHelper.EmployerEmail = objectContext.GetRegisteredEmail();

        GoToEmailAccountNotFoundPage().ContinueToInvite().SubmitEmployerName().SendInvitation().GoToViewEmployersPage().VerifyPendingRequest();
    }

    [Then(@"the employer declines the create account request")]
    public void TheEmployerDeclinesTheCreateAccountRequest()
    {
        OpenEmpInviteFromProvider();

        new StubSignInEmployerPage(context).Register().Continue();

        new CreateYourApprenticeshipServiceAccount(context).DoNotCreateAccount().ConfirmDoNotCreateAccount();
    }
}