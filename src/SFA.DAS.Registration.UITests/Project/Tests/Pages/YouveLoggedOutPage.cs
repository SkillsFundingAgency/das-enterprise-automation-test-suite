using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YouveLoggedOutPage : RegistrationBasePage
    {
        protected override string PageTitle => "You've logged out";
        private readonly ScenarioContext _context;

        #region Locators
        protected override By ContinueButton => By.LinkText("Continue");
        #endregion

        public YouveLoggedOutPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public IndexPage CickContinueInYouveLoggedOutPage()
        {
            Continue();
            return new IndexPage(_context);
        }
    }
}
