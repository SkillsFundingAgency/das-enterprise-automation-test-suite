using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.Login.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class SignInPage : EsfaSignInPage
    {
        public SignInPage(ScenarioContext context) : base(context) { }

        public SearchHomePage SignInWithValidDetails(LoginUser usercreds)
        {
            SubmitValidLoginDetails(usercreds.Username, usercreds.Password);

            return new SearchHomePage(context);
        }

        public ToolSupportHomePage SignIntoToolSupportWithValidDetails(LoginUser usercreds)
        {
            SubmitValidLoginDetails(usercreds.Username, usercreds.Password);

            return new ToolSupportHomePage(context);
        }
    }
}
