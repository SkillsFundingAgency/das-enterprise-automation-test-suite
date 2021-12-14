using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeDetailsWithTransferSendingEmployersPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice details with transfer sending employers";

        protected override bool TakeFullScreenShot => false;

        public ProviderApprenticeDetailsWithTransferSendingEmployersPage(ScenarioContext context) : base(context)  { }

        internal ProvideViewApprenticesDetailsPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
            return new ProvideViewApprenticesDetailsPage(context);
        }
    }
}

