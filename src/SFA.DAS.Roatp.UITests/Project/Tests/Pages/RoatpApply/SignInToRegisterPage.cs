using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class SignInToRegisterPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Sign in to Register of apprenticeship training providers service";

        private By EnterUsername => By.Id("Username");

        private By EnterPassword => By.Id("Password");

        public SignInToRegisterPage(ScenarioContext context) : base(context) => VerifyPage();

        public EnterUkprnPage SubmitValidUserDetailsEnterUkprnPage()
        {
            SubmitValidUserDetails();
            return new EnterUkprnPage(context);
        }

        public ApplicationOverviewPage SubmitValidUserDetailsApplicationOverviewPage()
        {
            SubmitValidUserDetails();
            return new ApplicationOverviewPage(context);
        }

        public void  SubmitValidUserDetails()
        {
            formCompletionHelper.EnterText(EnterUsername, objectContext.GetEmail());
            formCompletionHelper.EnterText(EnterPassword, objectContext.GetPassword());
            Continue();
        }
    }
}
