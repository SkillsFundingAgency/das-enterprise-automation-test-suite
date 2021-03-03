using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFLoginPage : EIBasePage
    {
        protected override string PageTitle => "Log In";

        protected override By PageHeader => By.CssSelector("h1");

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        private By Username => By.CssSelector("input[name='username']");

        private By Password => By.CssSelector("input[name='password']");

        private By SignInButton => By.CssSelector("button.primary[type='submit']");

        public VRFLoginPage(ScenarioContext context) : base(context) => _context = context;

        public DfeUatHomePage SignIntoDfeUat()
        {
            formCompletionHelper.EnterText(Username, eIConfig.EI_DfeUatUsername);
            formCompletionHelper.EnterText(Password, eIConfig.EI_DfeUatPassword);
            formCompletionHelper.Click(SignInButton);
            return new DfeUatHomePage(_context);
        }
    }
}
