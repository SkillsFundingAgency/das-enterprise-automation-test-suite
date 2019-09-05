using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCohortApprovedPage : BasePage
    {
        protected override string PageTitle => "Cohort approved";

        private readonly ScenarioContext _context;

        public ProviderCohortApprovedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
