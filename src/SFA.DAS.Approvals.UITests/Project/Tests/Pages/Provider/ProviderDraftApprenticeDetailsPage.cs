using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderDraftApprenticeDetailsPage : ApprovalsBasePage
    {   
        protected override string PageTitle => "Draft apprentice details";

        protected override bool TakeFullScreenShot => false;

        public ProviderDraftApprenticeDetailsPage(ScenarioContext context) : base(context)  { }

        internal ProviderApproveApprenticeDetailsPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
            return new ProviderApproveApprenticeDetailsPage(_context);
        }
    }
}
