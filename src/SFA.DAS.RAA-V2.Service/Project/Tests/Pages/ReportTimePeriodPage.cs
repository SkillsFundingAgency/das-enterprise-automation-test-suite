using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ReportTimePeriodPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "What time period do you want for the report?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#main-content > div > div > form > div:nth-child(3) > button");

        public ReportTimePeriodPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ReportProcessingPage GenerateReport()
        {
            formCompletionHelper.SelectRadioOptionByText("last 7 days");
            Continue();
            return new ReportProcessingPage(_context, 7);
        }
    }
}
