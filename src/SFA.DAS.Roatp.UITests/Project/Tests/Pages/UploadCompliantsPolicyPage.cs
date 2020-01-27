using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class UploadCompliantsPolicyPage : RoatpBasePage
    {
        protected override string PageTitle => "Upload your organisation's complaints policy";

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
