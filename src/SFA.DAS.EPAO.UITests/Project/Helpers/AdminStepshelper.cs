using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class AdminStepshelper
    {
        public AdminStepshelper() { }

        public OrganisationDetailsPage SearchEpaoRegister(StaffDashboardPage staffDashboardPage) => staffDashboardPage.SearchEPAO().SearchForAnOrganisation().SelectAnOrganisation();

        public OrganisationDetailsPage AddOrganisation(StaffDashboardPage staffDashboardPage) => staffDashboardPage.AddOrganisation().EnterDetails();

        public OrganisationDetailsPage MakeEPAOOrganisationLive(StaffDashboardPage staffDashboardPage)
        {
            return SearchEpaoRegister(staffDashboardPage).VerifyOrganisationStatus("New")
                .EditOrganisation()
                .MakeOrgLive()
                .VerifyOrganisationStatus("Live");
        }

        public StaffDashboardPage ApproveAStandard(StaffDashboardPage staffDashboardPage)
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
                .ReturnToApplications()
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