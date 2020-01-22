using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ApplicationOverviewPage : RoatpBasePage
    {
        protected override string PageTitle => "Application overview";
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private string StatusCompleted => "COMPLETED";

        private By ProviderRouteStatus => By.XPath("(//li[@class='app-task-list__item'])[1]");

        public ApplicationOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public bool VerifyProviderRouteStatus() => VerifyPage(ProviderRouteStatus, StatusCompleted);
    }

}
