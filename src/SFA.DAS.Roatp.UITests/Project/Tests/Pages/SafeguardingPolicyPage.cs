using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class SafeguardingPolicyPage : RoatpBasePage
    {
        protected override string PageTitle => "Upload your organisation's safeguarding policy";

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
