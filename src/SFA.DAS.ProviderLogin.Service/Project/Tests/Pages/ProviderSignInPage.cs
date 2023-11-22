using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class ProviderSignInPage : DfeSignInPage
{
    public ProviderSignInPage(ScenarioContext context) : base(context) { }

    public void SubmitValidLoginDetails(ProviderLoginUser login) => SubmitValidLoginDetails(login.Username, login.Password);
}