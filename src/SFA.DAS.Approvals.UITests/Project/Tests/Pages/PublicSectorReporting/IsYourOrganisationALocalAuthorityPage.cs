using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class IsYourOrganisationALocalAuthorityPage : PublicSectorReportingBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");
        protected override string PageTitle => "Is your organisation a local authority";
        protected override By ContinueButton => By.CssSelector("#SubmitSelectOptionForm");
        private By YesRadioButton => By.CssSelector("#islocalauthority-action-yes");

        public IsYourOrganisationALocalAuthorityPage(ScenarioContext context) : base(context) { }

        public ReportYourProgressPage SelectYesAndContinue()
        {
            javaScriptHelper.ClickElement(YesRadioButton);
            Continue();
            return new ReportYourProgressPage(context);
        }
    }
}
