using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ReportsPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Reports";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.LinkText("Create new report");

        public ReportsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ReportTimePeriodPage CreateNewReport()
        {
            Continue();
            return new ReportTimePeriodPage(_context);
        }
    }
}
