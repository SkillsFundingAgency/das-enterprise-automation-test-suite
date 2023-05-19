using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CreateAnAccountToManageApprenticeshipsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Create an account to manage apprenticeships";

        protected override bool TakeFullScreenShot => false;

        #region Locators
        private By SigninLink => By.LinkText("sign in");
        private By CreateAccountLink => By.Id("service-start");
        #endregion

        public CreateAnAccountToManageApprenticeshipsPage(ScenarioContext context) : base(context) => VerifyPage();

        public StubSignInPage GoToStubSignInPage() => StubSignInPage(() => formCompletionHelper.ClickElement(SigninLink));

        public StubSignInPage CreateAccount() => StubSignInPage(() => formCompletionHelper.ClickElement(CreateAccountLink));

        private StubSignInPage StubSignInPage(Action action)
        {
            action();

            return new StubSignInPage(context);
        }
    }
}
