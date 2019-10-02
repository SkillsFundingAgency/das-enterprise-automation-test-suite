using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class CohortSentYourTrainingProviderPage : CohortReferenceBasePage
    {
        protected override string PageTitle => "Cohort sent to your training provider";

        public CohortSentYourTrainingProviderPage(ScenarioContext context) : base(context)
        {
        }
    }
}