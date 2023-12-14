using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class ProviderSignInPage(ScenarioContext context) : DfeSignInPage(context)
{
    public void SubmitValidLoginDetails(ProviderLoginUser login) => SubmitValidLoginDetails(login.Username, login.Password);
}