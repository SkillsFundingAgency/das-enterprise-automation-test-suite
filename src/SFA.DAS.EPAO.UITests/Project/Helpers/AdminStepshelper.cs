using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class AdminStepshelper
    {
        public AdminStepshelper() { }

        public OrganisationDetailsPage SearchEpaoRegister(StaffDashboardPage staffDashboardPage, string keyword) => staffDashboardPage.SearchEPAO().SearchForAnOrganisation(keyword).SelectAnOrganisation();

        public OrganisationDetailsPage AddOrganisation(StaffDashboardPage staffDashboardPage) => staffDashboardPage.AddOrganisation().EnterDetails();

        public OrganisationDetailsPage MakeEPAOOrganisationLive(StaffDashboardPage staffDashboardPage, string keyword)
        {
            return SearchEpaoRegister(staffDashboardPage, keyword).VerifyOrganisationStatus("New")
                .EditOrganisation()
                .MakeOrgLive()
                .VerifyOrganisationStatus("Live");
        }

        public StaffDashboardPage ApproveAStandard(StaffDashboardPage staffDashboardPage)
        {
            return staffDashboardPage
                .GoToNewStandardApplications()
                .GoToNewStandardApplicationOverviewPage()
                .GoToApplyToAssessAStandardPage()
                .SelectYesAndContinue()
                .ReturnToOrganisationApplicationsPage()
                .ReturnToDashboard();
        }

        public StaffDashboardPage ApproveAnOrganisation(StaffDashboardPage staffDashboardPage, bool approveFinancialAssesment)
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

            staffDashboardPage = staffDashboardPage
                .GoToInProgressOrganisationApplication()
                .GoToInProgressOrganisationApplicationOverviewPage()
                .GoToFinancialhealthAssesmentPage()
                .SelectYesAndContinue()
                .CompleteReview()
                .ApproveApplication()
                .ReturnToApplications()
                .ReturnToDashboard();

            return staffDashboardPage
                .GoToApprovedOrganisationApplication()
                .GoToApprovedOrganisationApplicationOverviewPage()
                .ReturnToOrganisationApplicationsPage()
                .ReturnToDashboard();
        }
    }
}