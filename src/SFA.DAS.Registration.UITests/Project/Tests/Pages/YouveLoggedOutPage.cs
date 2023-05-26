using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YouveLoggedOutPage : RegistrationBasePage
    {
        protected override string PageTitle => "You've logged out";

        protected override bool TakeFullScreenShot => false;

        #region Locators
        protected override By ContinueButton => By.LinkText("Continue");
        #endregion

        public YouveLoggedOutPage(ScenarioContext context) : base(context) { } //=> VerifyPage();

        public CreateAnAccountToManageApprenticeshipsPage CickContinueInYouveLoggedOutPage()
        {
            Continue();
            return new CreateAnAccountToManageApprenticeshipsPage(context);
        }
    }
}
