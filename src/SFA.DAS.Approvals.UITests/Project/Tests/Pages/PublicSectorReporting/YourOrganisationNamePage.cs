using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class YourOrganisationNamePage(ScenarioContext context) : PublicSectorReportingBasePage(context)
    {
        protected override string PageTitle => "Your organisation";

        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        private static By OrganisatiponNameInput => By.CssSelector("#Report_OrganisationName");

        public ReportYourProgressPage EnterNameOftheOrganisation()
        {
            formCompletionHelper.EnterText(OrganisatiponNameInput, registrationDataHelper.CompanyTypeOrg);
            Continue();
            return new ReportYourProgressPage(context);
        }
    }
}