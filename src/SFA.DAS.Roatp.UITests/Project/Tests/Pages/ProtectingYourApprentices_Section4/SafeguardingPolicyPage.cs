using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.ProtectingYourApprentices_Section4
{
    public class SafeguardingPolicyPage : RoatpBasePage
    {
        protected override string PageTitle => "Upload your organisation's safeguarding policy";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public SafeguardingPolicyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public OverallResponsibilityForSafeguardingPage SafeguardingPolicyFileUploadAndContinue()
        {
            UploadFile();
            return new OverallResponsibilityForSafeguardingPage(_context);
        }
    }
}
