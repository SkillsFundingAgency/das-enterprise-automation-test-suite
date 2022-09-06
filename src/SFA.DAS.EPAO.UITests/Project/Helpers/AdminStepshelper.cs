namespace SFA.DAS.EPAO.UITests.Project.Helpers;

public class AdminStepshelper
{
    public static OrganisationDetailsPage SearchEpaoRegister(StaffDashboardPage staffDashboardPage) => staffDashboardPage.SearchEPAO().SearchForAnOrganisation().SelectAnOrganisation();

    public static OrganisationDetailsPage AddOrganisation(StaffDashboardPage staffDashboardPage) => staffDashboardPage.AddOrganisation().EnterDetails();

    public static CertificateDetailsPage SearchAssessments(StaffDashboardPage staffDashboardPage, string uln) => staffDashboardPage.Search().SearchFor(uln).SelectACertificate();

    public static OrganisationDetailsPage MakeEPAOOrganisationLive(StaffDashboardPage staffDashboardPage)
    {
        return SearchEpaoRegister(staffDashboardPage).VerifyOrganisationStatus("New")
            .EditOrganisation()
            .MakeOrgLive()
            .VerifyOrganisationStatus("Live");
    }

    public static StaffDashboardPage ApproveAStandard(StaffDashboardPage staffDashboardPage)
    {
        staffDashboardPage = staffDashboardPage
            .GoToNewStandardApplications()
            .GoToNewStandardApplicationOverviewPage()
            .GoToApplyToAssessAStandardPage()
            .SelectYesAndContinue()
            .ReturnToOrganisationApplicationsPage()
            .ReturnToDashboard();

        return staffDashboardPage
            .GoToInProgressStandardApplication()
            .GoToInProgressStandardApplicationOverviewPage()
            .CompleteReview()
            .ApproveApplication()
            .ReturnToStandardApplications()
            .ReturnToDashboard();
    }

    public static StaffDashboardPage ApproveAnOrganisation(StaffDashboardPage staffDashboardPage, bool approveFinancialAssesment)
    {
        staffDashboardPage = staffDashboardPage
            .GoToNewOrganisationApplications()
            .GoToNewOrganisationApplicationOverviewPage()
            .GoToNewOrganisationDetailsPage()
            .SelectYesAndContinue()
            .GoToNewOrgDeclarationsPage()
            .SelectYesAndContinue()
            .ReturnToOrganisationApplicationsPage()
            .ReturnToDashboard();

        if (approveFinancialAssesment)
        {
            staffDashboardPage = staffDashboardPage
            .GoToNewFinancialAssesmentPage()
            .GoToNewApplicationOverviewPage()
            .SelectGoodAndContinue()
            .ReturnToAccountHome()
            .ReturnToDashboard();
        }

        var applicationOverview = staffDashboardPage
            .GoToInProgressOrganisationApplication()
            .GoToInProgressOrganisationApplicationOverviewPage();

        if (approveFinancialAssesment)
        {
            applicationOverview = applicationOverview.GoToFinancialhealthAssesmentPage().SelectYesAndContinue();
        }

        staffDashboardPage = applicationOverview
            .CompleteReview()
            .ApproveApplication()
            .ReturnToOrganisationApplications()
            .ReturnToDashboard();

        return staffDashboardPage
            .GoToApprovedOrganisationApplication()
            .GoToApprovedOrganisationApplicationOverviewPage()
            .ReturnToOrganisationApplicationsPage()
            .ReturnToDashboard();
    }
}