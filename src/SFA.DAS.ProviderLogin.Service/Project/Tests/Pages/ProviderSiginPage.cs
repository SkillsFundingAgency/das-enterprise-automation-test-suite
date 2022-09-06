using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class ProviderSiginPage : SignInBasePage
    {
        public ProviderSiginPage(ScenarioContext context) : base(context) { }

        public ProviderHomePage SubmitValidLoginDetails(ProviderLoginUser login)
        {
            SubmitValidLoginDetails(login.UserId, login.Password);
            return new ProviderHomePage(context);
        }

        public ProviderHomePage SubmitValidLoginDetails(ProviderPortableFlexiJobUser login)
        {
            SubmitValidLoginDetails(login.UserId, login.Password);
            return new ProviderHomePage(context);
        }
    }
}