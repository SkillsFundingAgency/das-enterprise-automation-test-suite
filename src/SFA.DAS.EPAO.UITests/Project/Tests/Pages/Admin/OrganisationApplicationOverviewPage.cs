namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class OrganisationApplicationOverviewPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Application overview";

    public OrganisationApplicationOverviewPage(ScenarioContext context) : base(context) => VerifyPage();

    public NewOrganisationDetailsPage GoToNewOrganisationDetailsPage()
    {
        formCompletionHelper.ClickLinkByText("Evaluate organisation details");
        return new(context);
    }

    public NewOrgDeclarationsPage GoToNewOrgDeclarationsPage()
    {
        formCompletionHelper.ClickLinkByText("Evaluate declarations");
        return new(context);
    }

    public NewOrgFinancialhealthAssesmentPage GoToFinancialhealthAssesmentPage()
    {
        formCompletionHelper.ClickLinkByText("Evaluate financial health assessment");
        return new(context);
    }

    public OrganisationApplicationsPage ReturnToOrganisationApplicationsPage()
    {
        formCompletionHelper.ClickLinkByText("Return to applications");
        return new(context);
    }

    public AssessmentSummaryPage CompleteReview()
    {
        Continue();
        return new(context);
    }
}