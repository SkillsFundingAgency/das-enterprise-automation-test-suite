using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class SignInToRegisterPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Sign in to Register of apprenticeship training providers service";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By EnterUsername => By.Id("Username");

        private By EnterPassword => By.Id("Password");

        public SignInToRegisterPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EnterUkprnPage SubmitValidUserDetailsEnterUkprnPage()
        {
            SubmitValidUserDetails();
            return new EnterUkprnPage(_context);
        }

        public ApplicationOverviewPage SubmitValidUserDetailsApplicationOverviewPage()
        {
            SubmitValidUserDetails();
            return new ApplicationOverviewPage(_context);
        }

        public void  SubmitValidUserDetails()
        {
            formCompletionHelper.EnterText(EnterUsername, objectContext.GetEmail());
            formCompletionHelper.EnterText(EnterPassword, objectContext.GetPassword());
            Continue();
        }
        public ApplicationOutcomePage SubmitValidUserDetails_ExistingProviders()
        {
            formCompletionHelper.EnterText(EnterUsername, objectContext.GetEmail());
            formCompletionHelper.EnterText(EnterPassword, objectContext.GetPassword());
            Continue();
            return new ApplicationOutcomePage(_context);
        }
    }
}
