using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ResumeApprenticePage : ChangeApprenticeStatus
    {
        protected override string PageTitle => "Resume apprentice";

        private readonly ScenarioContext _context;

        public ResumeApprenticePage(ScenarioContext context) : base(context) => _context = context;

        public new ResumedApprenticeDetailsPage SelectYesAndConfirm()
        {
            base.SelectYesAndConfirm();
            return new ResumedApprenticeDetailsPage(_context);
        }
    }
}