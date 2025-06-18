using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class YourSchoolApprenticesPage(ScenarioContext context) : PublicSectorReportingBasePage(context)
    {
        protected override string PageTitle => "Your apprentices - maintained schools only";
        private static By NoOfApprentices2021 => By.CssSelector("#z0__Answer");
        private static By NoOfApprentices2022 => By.CssSelector("#z1__Answer");
        private static By NoOfApprentices => By.CssSelector("#z2__Answer");

        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        public ReportYourProgressPage EnterSchoolApprenticeDetails()
        {
            formCompletionHelper.EnterText(NoOfApprentices2021, publicSectorReportingDataHelper.NoofApprentices2021);
            formCompletionHelper.EnterText(NoOfApprentices2022, publicSectorReportingDataHelper.NoofApprentices2022);
            formCompletionHelper.EnterText(NoOfApprentices, publicSectorReportingDataHelper.NoofNewApprentices);
            Continue();
            return new ReportYourProgressPage(context);
        }
    }
}