using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class IsYourOrganisationALocalAuthorityPage(ScenarioContext context) : PublicSectorReportingBasePage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");
        protected override string PageTitle => "Is your organisation a local authority";
        protected override By ContinueButton => By.CssSelector("#SubmitSelectOptionForm");
        private static By YesRadioButton => By.CssSelector("#islocalauthority-action-yes");

        public ReportYourProgressPage SelectYesAndContinue()
        {
            javaScriptHelper.ClickElement(YesRadioButton);
            Continue();
            return new ReportYourProgressPage(context);
        }
    }
}
