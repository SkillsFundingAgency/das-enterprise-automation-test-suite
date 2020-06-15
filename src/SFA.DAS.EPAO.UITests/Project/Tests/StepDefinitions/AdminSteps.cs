using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AdminSteps : EPAOBaseSteps
    {
        public AdminSteps(ScenarioContext context) : base(context) { }

        [Then(@"the admin can add organisation")]
        public void ThenTheAdminCanAddOrganisation() => adminStepshelper.AddOrganisation(GoToEpaoAdminHomePage());

        [Then(@"the admin can make organisation to be live")]
        public void ThenTheAdminCanMakeOrganisationToBeLive()
        {
            var epaoid = ePAOAdminDataHelper.MakeLiveOrganisationEpaoId;

            ePAOAdminSqlDataHelper.UpdateOrgStatusToNew(epaoid);

            organisationDetailsPage = adminStepshelper.MakeEPAOOrganisationLive(GoToEpaoAdminHomePage(), epaoid);
        }

        [Then(@"the admin can edit the organisation")]
        public void ThenTheAdminCanEditTheOrganisation()
        {
            organisationDetailsPage = organisationDetailsPage
                .EditOrganisation()
                .EditDetails()
                .VerifyOrganisationCharityNumber()
                .VerifyOrganisationCompanyNumber();
        }

        [Then(@"the admin can search using organisation name")]
        public void ThenTheAdminCanSearchUsingOrganisationName() => organisationDetailsPage = adminStepshelper.SearchEpaoRegister(GoToEpaoAdminHomePage(),ePAOAdminDataHelper.OrganisationName);

        [Then(@"the admin can search using organisation epao id")]
        public void ThenTheAdminCanSearchUsingOrganisationEpaoId() => organisationDetailsPage = adminStepshelper.SearchEpaoRegister(GoToEpaoAdminHomePage(),ePAOAdminDataHelper.OrganisationEpaoId);

        [Then(@"the admin can add contact details")]
        public void ThenTheAdminCanAddContactDetails() => organisationDetailsPage = organisationDetailsPage.AddNewContact().AddContact().ReturnToOrganisationDetailsPage().SelectContact().ReturnToOrganisationDetailsPage();

        [Then(@"the admin can add standards details")]
        public void ThenTheAdminCanAddStandardsDetails() => organisationDetailsPage = organisationDetailsPage.AddAStandard().SearchStandards().AddStandardToOrganisation().AddStandardsDetails().VerifyStandards().ReturnToOrganisationDetailsPage();

        [Then(@"the admin can update organisation standards status to be live")]
        public void ThenTheAdminCanUpdateOrganisationStandardsStatusToBeLive()
        {
            ePAOAdminSqlDataHelper.UpdateOrgStandardStatusToNew(ePAOAdminDataHelper.OrganisationEpaoId, ePAOAdminDataHelper.Standards);
            
            organisationDetailsPage = organisationDetailsPage
                .SelectStandards()
                .VerifyOrgStandardsStatus("New")
                .EditStandard()
                .EditStandardsDetails()
                .VerifyOrgStandardsStatus("Live")
                .ReturnToOrganisationDetailsPage();
        }
        
        [Then(@"the admin can search using organisation ukprn")]
        public void ThenTheAdminCanSearchUsingOrganisationUkprn() => organisationDetailsPage = adminStepshelper.SearchEpaoRegister(GoToEpaoAdminHomePage(),ePAOAdminDataHelper.OrganisationUkprn);

        [Then(@"the admin can search batches")]
        public void ThenTheAdminCanSearchBatches() => GoToEpaoAdminHomePage().SearchEPAOBatch().SearchBatches().VerifyingBatchDetails().SignOut();

        [Then(@"the admin can search using uln")]
        public void ThenTheAdminCanSearchUsingUln() => certificateDetailsPage = GoToEpaoAdminHomePage().Search().SearchFor(ePAOAdminDataHelper.LearnerUln).SelectACertificate();

        [Then(@"the admin can access learners audit history")]
        public void ThenTheAdminCanAccessLearnersAuditHistory() => certificateDetailsPage.ShowAllHistory();

        private StaffDashboardPage GoToEpaoAdminHomePage() => ePAOHomePageHelper.LoginToEpaoAdminHomePage();

    }
}