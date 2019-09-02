using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCohortApprovedAndSentToEmployerPage : BasePage
    {
        protected override string PageTitle => "Cohort approved and sent to employer";

        public ProviderCohortApprovedAndSentToEmployerPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }     
}
