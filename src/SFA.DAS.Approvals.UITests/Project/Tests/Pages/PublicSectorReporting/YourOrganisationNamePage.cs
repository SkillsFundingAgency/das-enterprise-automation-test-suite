using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.PublicSectorReporting
{
    public class YourOrganisationNamePage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Your organisation";

        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        private By OrganisatiponNameInput => By.CssSelector("#Report_OrganisationName");

        public YourOrganisationNamePage(ScenarioContext context) : base(context)  { }
        
        public ReportYourProgressPage EnterNameOftheOrganisation()
        {
            formCompletionHelper.EnterText(OrganisatiponNameInput, registrationDataHelper.CompanyTypeOrg);
            Continue();
            return new ReportYourProgressPage(context);
        }
    }
}