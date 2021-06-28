using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class PauseApprenticePage : ChangeApprenticeStatus
    {
        protected override string PageTitle => "Pause apprenticeship";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PauseApprenticePage(ScenarioContext context) : base(context) => _context = context;

        public new ApprenticeDetailsPage SelectYesAndConfirm()
        {
            base.SelectYesAndConfirm();
            return new ApprenticeDetailsPage(_context);
        }
    }
}