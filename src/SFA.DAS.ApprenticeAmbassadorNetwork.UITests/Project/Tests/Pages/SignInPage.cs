using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class SignInPage : AanBasePage
    {
        protected override string PageTitle => "Sign in to My apprenticeship";

        private By EnterUsername => By.Id("Username");

        private By EnterPassword => By.Id("Password");

        public SignInPage(ScenarioContext context) : base(context) => VerifyPage();

        public BeforeYouStartPage SubmitValidUserDetails(string username, string password)
        {
            formCompletionHelper.EnterText(EnterUsername, username);
            formCompletionHelper.EnterText(EnterPassword, password);
            Continue();
            return new BeforeYouStartPage(context);
        }

    }
}
