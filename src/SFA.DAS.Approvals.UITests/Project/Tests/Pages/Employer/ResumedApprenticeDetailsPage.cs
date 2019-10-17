using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{

    public class ResumedApprenticeDetailsPage : ConfirmApprenticeStatus
    {
        protected override string PageTitle => "Apprenticeship resumed";
        
        public ResumedApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
        }
    }
}