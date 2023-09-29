using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class ProviderSignInPage : SignInBasePage //DfeSignInPage (pas login changes)
{
    public ProviderSignInPage(ScenarioContext context) : base(context) { }

    //pas login changes
    //public SelectYourOrganisationPage SubmitValidLoginDetails(ProviderLoginUser login)
    //{
    //    SubmitValidLoginDetails(login.UserId, login.Password);
    //    return new SelectYourOrganisationPage(context);
    //}

    public ProviderHomePage SubmitValidLoginDetails(ProviderLoginUser login)
    {
        SubmitValidLoginDetails(login.UserId, login.Password);
        return new ProviderHomePage(context);
    }
}