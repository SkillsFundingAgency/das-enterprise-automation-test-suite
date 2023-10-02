using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class ProviderSignInPage : DfeSignInPage
{
    public ProviderSignInPage(ScenarioContext context) : base(context) { }

    public void SubmitValidLoginDetails(ProviderLoginUser login) => SubmitValidLoginDetails(login.UserId, login.Password);
}