using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class CohortSentForReviewPage : CohortReferenceBasePage
    {
        protected override string PageTitle => "Cohort sent for review";

        public CohortSentForReviewPage(ScenarioContext context) : base(context)
        {
            
        }
    }
}