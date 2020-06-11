using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class ApplicationOverviewPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Application overview";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApplicationOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public NewOrganisationDetailsPage GoToNewOrganisationDetailsPage()
        {
            formCompletionHelper.ClickLinkByText("Organisation details");
            return new NewOrganisationDetailsPage(_context);
        }

        public NewOrgDeclarationsPage GoToNewOrgDeclarationsPage()
        {
            formCompletionHelper.ClickLinkByText("Declarations");
            return new NewOrgDeclarationsPage(_context);
        }

        public NewOrgFinancialhealthAssesmentPage GoToFinancialhealthAssesmentPage()
        {
            formCompletionHelper.ClickLinkByText("Financial health assessment");
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