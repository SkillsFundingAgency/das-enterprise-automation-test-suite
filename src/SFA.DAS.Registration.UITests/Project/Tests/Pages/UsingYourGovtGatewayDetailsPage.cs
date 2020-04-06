using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class UsingYourGovtGatewayDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "Using your Government Gateway details";
        private readonly ScenarioContext _context;
        
        #region Locators
        protected override By ContinueButton => By.Id("agree_and_continue");
        #endregion

        public UsingYourGovtGatewayDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public GgSignInPage ContinueToGGSignIn()
        {
            Continue();
            return new GgSignInPage(_context);
        }
    }
}