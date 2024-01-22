using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.DfeSignPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class ProviderDfeSignInPage(ScenarioContext context) : DfeSignInPage(context)
{
    public void SubmitValidLoginDetails(ProviderLoginUser login)
    {
        SubmitValidLoginDetails(login.Username, login.Password);

        new NotADfeProviderSignPage(context).IsPageDisplayed();
    }
}