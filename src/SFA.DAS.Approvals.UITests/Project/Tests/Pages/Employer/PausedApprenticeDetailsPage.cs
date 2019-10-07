using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class PausedApprenticeDetailsPage : ConfirmApprenticeStatus
    {
        protected override string PageTitle => "Apprenticeship paused";

        public PausedApprenticeDetailsPage(ScenarioContext context): base(context)
        {
            
        }
    }
}