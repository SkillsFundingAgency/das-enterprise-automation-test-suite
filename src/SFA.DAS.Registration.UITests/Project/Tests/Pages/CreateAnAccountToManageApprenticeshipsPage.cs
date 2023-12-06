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
        private static By SigninLink => By.LinkText("sign in");
        private static By CreateAccountLink => By.Id("service-start");
        private static By AcceptAllCookies => By.XPath("//button[text()='Accept all cookies']");
        #endregion

        public CreateAnAccountToManageApprenticeshipsPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
            ClickIfDisplayed(AcceptAllCookies);
        }

        public StubSignInPage GoToStubSignInPage() => StubSignInPage(() => formCompletionHelper.ClickElement(SigninLink));

        public StubSignInPage ClickOnCreateAccountLink() => StubSignInPage(() => formCompletionHelper.ClickElement(CreateAccountLink));

        private StubSignInPage StubSignInPage(Action action)
        {
            action();

            return new StubSignInPage(context);
        }
    }
}
