using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class YourEmployeesPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Your employees - excluding maintained schools";
        private static By NoOfEmployees2022 => By.CssSelector("#z1__Answer");
        private static By NoOfEmployees2021 => By.CssSelector("#z0__Answer");
        private static By NoOfEmployees => By.CssSelector("#z2__Answer");
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        public YourEmployeesPage(ScenarioContext context) : base(context)  { }

        public ReportYourProgressPage EnterEmployeesDetails()
        {
            formCompletionHelper.EnterText(NoOfEmployees2021, publicSectorReportingDataHelper.NoofEmployees2021);
            formCompletionHelper.EnterText(NoOfEmployees2022, publicSectorReportingDataHelper.NoofEmployees2022);
            formCompletionHelper.EnterText(NoOfEmployees, publicSectorReportingDataHelper.NoofNewEmployees);
            Continue();
            return new ReportYourProgressPage(context);
        }
    }
}