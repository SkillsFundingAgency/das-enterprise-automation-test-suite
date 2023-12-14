using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class CohortSentYourTrainingProviderPage : CohortReferenceBasePage
    {
        protected override string PageTitle => "Cohort sent to your training provider";

        protected override bool TakeFullScreenShot => false;

        public CohortSentYourTrainingProviderPage(ScenarioContext context) : base(context) { }
    }
}