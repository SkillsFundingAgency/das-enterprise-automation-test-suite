using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class StubSignIn : AppBasePage
    {
        protected override string PageTitle => "StubSignIn";
        protected static By StubId => By.Id("Id");
        protected static By Email => By.Id("Email");
        protected static By SignInButton => By.CssSelector("button.app-button[type=\"submit\"]\r\n");

        public StubSignIn(ScenarioContext context) : base(context)
        {
        
        }

        public WelcomePage SignIn()
        {
            var user = context.GetUser<ApprAppUser>();
            formCompletionHelper.EnterText(StubId, user.IdOrUserRef);
            formCompletionHelper.EnterText(Email, user.Username);
            formCompletionHelper.Click(SignInButton);
            return new WelcomePage(context);
        }
    }
}
