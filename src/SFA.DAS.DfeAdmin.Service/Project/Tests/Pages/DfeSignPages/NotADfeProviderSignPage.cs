namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.DfeSignPages;

public class NotADfeProviderSignPage(ScenarioContext context) : NotADfeSignPage(context)
{
    protected override By Identifier => DfeSignInPage.DfePageIdentifier;
}
