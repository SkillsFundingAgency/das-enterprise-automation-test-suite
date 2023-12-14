namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class StaffDashboardPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Staff dashboard";

    private static By NewOrganisationApplication => By.CssSelector("a.govuk-link[href='/OrganisationApplication#new']");
    private static By InProgressOrganisationApplication => By.CssSelector("a.govuk-link[href='/OrganisationApplication#in-progress']");
    private static By ApprovedOrganisationApplication => By.CssSelector("a.govuk-link[href='/OrganisationApplication#approved']");
    private static By NewStandardApplication => By.CssSelector("a.govuk-link[href='/StandardApplication#new']");
    private static By NewWithdrawalApplications => By.CssSelector("a.govuk-link[href='/WithdrawalApplication#new']");
    private static By InProgressWithdrawalApplications => By.CssSelector("a.govuk-link[href='/WithdrawalApplication#in-progress']");
    private static By InProgressStandardApplication => By.CssSelector("a.govuk-link[href='/StandardApplication#in-progress']");
    private static By FeedbackWithdrawalApplications => By.CssSelector("a.govuk-link[href='/WithdrawalApplication#feedback']");
    private static By ApprovedStandardApplication => By.CssSelector("a.govuk-link[href='/StandardApplication#approved']");

    private static By NewFinancialHeathAssesment => By.CssSelector("a.govuk-link[href='/Financial/Open']");
    private static By SearchLink => By.CssSelector("a.govuk-link[href='/Search']");
    private static By BatchSearch => By.CssSelector("a.govuk-link[href='/BatchSearch']");
    private static By Register => By.CssSelector("a.govuk-link[href='/Register']");
    private static By AddOrganisationLink => By.CssSelector("a.govuk-link[href='/register/add-organisation']");
    private static By ScheduleConfig => By.CssSelector("a.govuk-link[href='/ScheduleConfig']");
    private static By Reports => By.CssSelector("a.govuk-link[href='/Reports']");
    private static By CertificateApprovals => By.CssSelector("a.govuk-link[href='/CertificateApprovals/New']");
    private static By ExternalApi => By.CssSelector("a.govuk-link[href='/ExternalApi']");
    private static By Financial => By.CssSelector("a.govuk-link[href='/Financial/Open']");
    private static By Applications => By.CssSelector("a.govuk-link[href='/Applications/Midpoint']");

    public StaffDashboardPage(ScenarioContext context) : base(context) => VerifyPage();

    public SearchPage Search()
    {
        formCompletionHelper.ClickElement(SearchLink);
        return new(context);
    }

    public OrganisationSearchPage SearchEPAO()
    {
        formCompletionHelper.ClickElement(Register);
        return new(context);
    }

    public AddOrganisationPage AddOrganisation()
    {
        formCompletionHelper.ClickElement(AddOrganisationLink);
        return new(context);
    }

    public BatchSearchPage SearchEPAOBatch()
    {
        formCompletionHelper.ClickElement(BatchSearch);
        return new(context);
    }

    public OrganisationApplicationsPage GoToNewOrganisationApplications()
    {
        formCompletionHelper.ClickElement(NewOrganisationApplication);
        return new(context);
    }

    public OrganisationApplicationsPage GoToInProgressOrganisationApplication()
    {
        formCompletionHelper.ClickElement(InProgressOrganisationApplication);
        return new(context);
    }

    public OrganisationApplicationsPage GoToApprovedOrganisationApplication()
    {
        formCompletionHelper.ClickElement(ApprovedOrganisationApplication);
        return new(context);
    }

    public FinancialAssesmentPage GoToNewFinancialAssesmentPage()
    {
        formCompletionHelper.ClickElement(NewFinancialHeathAssesment);
        return new(context);
    }

    public StandardApplicationsPage GoToNewStandardApplications()
    {
        formCompletionHelper.ClickElement(NewStandardApplication);
        return new(context);
    }

    public StandardApplicationsPage GoToInProgressStandardApplication()
    {
        formCompletionHelper.ClickElement(InProgressStandardApplication);
        return new(context);
    }

    public AD_WithdrawalApplicationsPage GoToNewWithdrawalApplications()
    {
        formCompletionHelper.ClickElement(NewWithdrawalApplications);
        return new(context);
    }

    public AD_WithdrawalApplicationsPage GoToFeedbackWithdrawalApplications()
    {
        formCompletionHelper.ClickElement(FeedbackWithdrawalApplications);
        return new(context);
    }
}