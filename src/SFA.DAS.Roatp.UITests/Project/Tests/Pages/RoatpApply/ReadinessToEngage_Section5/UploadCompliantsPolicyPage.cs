using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class UploadCompliantsPolicyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation's complaints policy";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public UploadCompliantsPolicyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EnterWebsiteLinkPage CompliantsPolicyFileUploadAndContinue()
        {
            UploadFile();
            return new EnterWebsiteLinkPage(_context);
        }
    }
}
