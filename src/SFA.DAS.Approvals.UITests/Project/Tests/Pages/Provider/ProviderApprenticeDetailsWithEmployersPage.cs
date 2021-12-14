using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeDetailsWithEmployersPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice details with employer";

        protected override bool TakeFullScreenShot => false;

        public ProviderApprenticeDetailsWithEmployersPage(ScenarioContext context) : base(context)  { }

        internal ProvideViewApprenticesDetailsPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
            return new ProvideViewApprenticesDetailsPage(context);
        }
    }
}
