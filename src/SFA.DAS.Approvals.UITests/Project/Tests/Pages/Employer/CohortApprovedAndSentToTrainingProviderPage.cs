using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class CohortApprovedAndSentToTrainingProviderPage : CohortReferenceBasePage
    {
        protected override string PageTitle => "Cohort approved and sent to training provider";

        public CohortApprovedAndSentToTrainingProviderPage(ScenarioContext context) : base(context)
        {
        }
    }
}