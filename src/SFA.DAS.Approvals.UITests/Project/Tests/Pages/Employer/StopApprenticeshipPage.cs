using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class StopApprenticeshipPage : ChangeApprenticeStatus
    {
        protected override string PageTitle => "Confirm apprenticeship stop";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public StopApprenticeshipPage(ScenarioContext context) : base(context) => _context = context;

        public new StoppedApprenticeDetailsPage SelectYesAndConfirm()
        {
            ConfirmChangesAndContinue();
            return new StoppedApprenticeDetailsPage(_context);
        }

        public StopApprenticeshipPage SelectYesandConfirmForANonStartedApprentice()
        {
            ConfirmChangesAndContinue();
            return new StopApprenticeshipPage(_context);
        }
        
        private StopApprenticeshipPage ConfirmChangesAndContinue()
        {
            base.SelectYesAndConfirm();
            return this;
        }
    }
}