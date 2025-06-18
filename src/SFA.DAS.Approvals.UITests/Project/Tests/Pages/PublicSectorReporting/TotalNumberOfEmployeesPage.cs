using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class TotalNumberOfEmployeesPage(ScenarioContext context) : PublicSectorReportingBasePage(context)
    {
        protected override string PageTitle => "Total number of employees";
        protected override By ContinueButton => By.CssSelector("#SubmitSelectOptionForm");
        private static By YesRadioButton => By.CssSelector("#totalemployees-action-yes");

        public ReportYourProgressPage SelectYesAndContinue()
        {
            javaScriptHelper.ClickElement(YesRadioButton);
            Continue();
            return new ReportYourProgressPage(context);
        }
    }
}
