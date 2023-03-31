using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class TotalNumberOfEmployeesPage : PublicSectorReportingBasePage
    {
        protected override By PageHeader => By.CssSelector(".heading-medium");
        protected override string PageTitle => "Total number of employees";
        protected override By ContinueButton => By.CssSelector("#SubmitSelectOptionForm");
        private By YesRadioButton => By.CssSelector("#totalemployees-action-yes");

        public TotalNumberOfEmployeesPage(ScenarioContext context) : base(context) { }

        public ReportYourProgressPage SelectYesAndContinue()
        {
            javaScriptHelper.ClickElement(YesRadioButton);
            Continue();
            return new ReportYourProgressPage(context);
        }
    }
}
