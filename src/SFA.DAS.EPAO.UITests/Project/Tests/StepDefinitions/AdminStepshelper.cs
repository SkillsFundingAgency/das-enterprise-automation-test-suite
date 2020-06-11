using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    public class AdminStepshelper
    {
        private readonly ScenarioContext _context;
        private readonly EPAOHomePageHelper _ePAOHomePageHelper;

        public AdminStepshelper(ScenarioContext context)
        {
            _context = context;
            _ePAOHomePageHelper = new EPAOHomePageHelper(_context);
        }

        public StaffDashboardPage GoToEpaoAdminHomePage(bool openInNewTab = false) => _ePAOHomePageHelper.GoToEpaoAdminHomePage(openInNewTab);

        public OrganisationDetailsPage SearchEpaoRegister(string keyword) => _ePAOHomePageHelper.GoToEpaoAdminHomePage().SearchEPAO().SearchForAnOrganisation(keyword).SelectAnOrganisation();

        public OrganisationDetailsPage AddOrganisation() => GoToEpaoAdminHomePage().AddOrganisation().EnterDetails();

        public OrganisationDetailsPage MakeEPAOOrganisationLive(string keyword)
        {
            return SearchEpaoRegister(keyword).VerifyOrganisationStatus("New")
                .EditOrganisation()
                .MakeOrgLive()
                .VerifyOrganisationStatus("Live");
        }

        public StaffDashboardPage ApproveAStandard()
        {
            return GoToEpaoAdminHomePage(true)
                .GoToNewStandardApplications()
                .GoToNewStandardApplicationOverviewPage()
                .GoToApplyToAssessAStandardPage()
                .SelectYesAndContinue()
                .ReturnToOrganisationApplicationsPage()
                .ReturnToDashboard();
        }

        public StaffDashboardPage ApproveAnOrganisation()
        {
            var staffDashboardPage = GoToEpaoAdminHomePage(true)
                .GoToNewOrganisationApplications()
                .GoToNewOrganisationApplicationOverviewPage()
                .GoToNewOrganisationDetailsPage()
                .SelectYesAndContinue()
                .GoToNewOrgDeclarationsPage()
                .SelectYesAndContinue()
                .ReturnToOrganisationApplicationsPage()
                .ReturnToDashboard();

            staffDashboardPage = staffDashboardPage
                .GoToNewFinancialAssesmentPage()
                .GoToNewApplicationOverviewPage()
                .SelectGoodAndContinue()
                .ReturnToAccountHome()
                .ReturnToDashboard();

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