using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ReportPublicSectorApprenticeshipTargetPage : BasePage
    {

        protected override string PageTitle => "Annual apprenticeship return";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ReportPublicSectorApprenticeshipTargetPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
