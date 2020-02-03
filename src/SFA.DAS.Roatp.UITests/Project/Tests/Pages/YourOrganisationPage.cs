using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class YourOrganisationPage : RoatpBasePage
    {
        protected override string PageTitle => "Your organisation";

        private By WarningContent => By.XPath("//strong[text()='Your organisation must have at least 12 months trading history and a training manager with at least 9 months experience in developing and delivering training. ']");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public YourOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
            VerifyPage(WarningContent);
        }

        public ApplicationOverviewPage VerifyIntorductionAndContinue()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
