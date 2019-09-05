using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCohortSentForReviewPage : BasePage
    {
        protected override string PageTitle => "Cohort sent for review";

        public ProviderCohortSentForReviewPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }   
    }
}