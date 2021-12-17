using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class UsingYourGovtGatewayDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Using your Government Gateway details";
        
        #region Locators
        protected override By ContinueButton => By.Id("agree_and_continue");
        #endregion

        public UsingYourGovtGatewayDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public GgSignInPage ContinueToGGSignIn()
        {
            Continue();
            return new GgSignInPage(context);
        }
    }
}