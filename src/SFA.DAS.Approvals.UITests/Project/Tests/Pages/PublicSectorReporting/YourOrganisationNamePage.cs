using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class YourOrganisationNamePage : PublicSectorReportingBasePage
    {
        protected override string PageTitle => "Your organisation"; 

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        private By OrganisatiponNameInput => By.CssSelector("#Report_OrganisationName");

        public YourOrganisationNamePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReportYourProgressPage EnterNameOftheOrganisation()
        {
            formCompletionHelper.EnterText(OrganisatiponNameInput, registrationConfig.RE_OrganisationName);
            Continue();
            return new ReportYourProgressPage(_context);
        }
    }
}