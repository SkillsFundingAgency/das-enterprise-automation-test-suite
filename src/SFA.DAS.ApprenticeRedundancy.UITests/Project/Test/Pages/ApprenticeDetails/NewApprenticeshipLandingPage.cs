using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages
{
    public class NewApprenticeshipLandingPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "Find another apprenticeship";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private By StartNowButtonForApprentice = By.CssSelector("a.das-panel-button");
        #endregion

        public NewApprenticeshipLandingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApprenticeDetailsPage SelectAprpenticesStartnow()
        {
            Continue();
            return new ApprenticeDetailsPage(_context);
        }
    }
}
