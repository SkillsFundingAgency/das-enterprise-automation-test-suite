using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class YourSchoolApprenticesPage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Your apprentices - maintained schools only";
        private By NoOfApprentices2021 => By.CssSelector("#z0__Answer");
        private By NoOfApprentices2022 => By.CssSelector("#z1__Answer");
        private By NoOfApprentices => By.CssSelector("#z2__Answer");


        public YourSchoolApprenticesPage(ScenarioContext context) : base(context)  { }

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