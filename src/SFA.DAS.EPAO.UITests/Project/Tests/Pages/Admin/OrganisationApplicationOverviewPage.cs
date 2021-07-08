using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class OrganisationApplicationOverviewPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Application overview";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OrganisationApplicationOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public NewOrganisationDetailsPage GoToNewOrganisationDetailsPage()
        {
            formCompletionHelper.ClickLinkByText("Evaluate organisation details");
            return new NewOrganisationDetailsPage(_context);
        }

        public NewOrgDeclarationsPage GoToNewOrgDeclarationsPage()
        {
            formCompletionHelper.ClickLinkByText("Evaluate declarations");
            return new NewOrgDeclarationsPage(_context);
        }

        public NewOrgFinancialhealthAssesmentPage GoToFinancialhealthAssesmentPage()
        {
            formCompletionHelper.ClickLinkByText("Evaluate financial health assessment");
            return new NewOrgFinancialhealthAssesmentPage(_context);
        }

        public OrganisationApplicationsPage ReturnToOrganisationApplicationsPage()
        {
            formCompletionHelper.ClickLinkByText("Return to applications");
            return new OrganisationApplicationsPage(_context);
        }

        public AssessmentSummaryPage CompleteReview()
        {
            Continue();
            return new AssessmentSummaryPage(_context);
        }
    }
}