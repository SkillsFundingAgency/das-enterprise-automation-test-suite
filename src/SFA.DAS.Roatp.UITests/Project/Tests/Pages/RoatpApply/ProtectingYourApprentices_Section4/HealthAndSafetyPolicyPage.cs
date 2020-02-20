using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ProtectingYourApprentices_Section4
{
    public class HealthAndSafetyPolicyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation's health and safety policy";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public HealthAndSafetyPolicyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public OverallResponsibilityForHealthAndSafetyPage HealthAndSafetyPolicyFileUploadAndContinue()
        {
            UploadFile();
            return new OverallResponsibilityForHealthAndSafetyPage(_context);
        }
    }
}
