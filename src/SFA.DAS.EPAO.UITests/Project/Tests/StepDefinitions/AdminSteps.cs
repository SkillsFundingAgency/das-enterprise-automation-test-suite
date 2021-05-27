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

            objectContext.SetOrganisationIdentifier(epaoid);

            organisationDetailsPage = adminStepshelper.MakeEPAOOrganisationLive(GoToEpaoAdminHomePage());
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
        public void ThenTheAdminCanSearchUsingOrganisationName()
        {
            objectContext.SetOrganisationIdentifier(ePAOAdminDataHelper.OrganisationName);

            organisationDetailsPage = adminStepshelper.SearchEpaoRegister(GoToEpaoAdminHomePage());
        }

        [Then(@"the admin can search using organisation epao id")]
        public void ThenTheAdminCanSearchUsingOrganisationEpaoId()
        {
            objectContext.SetOrganisationIdentifier(ePAOAdminDataHelper.OrganisationEpaoId);

            organisationDetailsPage = adminStepshelper.SearchEpaoRegister(GoToEpaoAdminHomePage());
        }

        [Then(@"the admin can add contact details")]
        public void ThenTheAdminCanAddContactDetails() => organisationDetailsPage = organisationDetailsPage.AddNewContact().AddContact().ReturnToOrganisationDetailsPage().SelectContact().ReturnToOrganisationDetailsPage();

        [Then(@"the admin can add standards details")]
        public void ThenTheAdminCanAddStandardsDetails() => organisationDetailsPage = organisationDetailsPage.AddAStandard().SearchStandards().AddStandardToOrganisation().AddStandardsDetails().VerifyStandards().ReturnToOrganisationDetailsPage();

        [Then(@"the admin can update organisation standards status to be live")]
        public void ThenTheAdminCanUpdateOrganisationStandardsStatusToBeLive()
        {
            ePAOAdminSqlDataHelper.UpdateOrgStandardStatusToNew(ePAOAdminDataHelper.OrganisationEpaoId, ePAOAdminDataHelper.StandardCode);
            
            organisationDetailsPage = organisationDetailsPage
                .SelectStandards()
                .VerifyOrgStandardsStatus("New")
                .EditStandard()
                .EditStandardsDetails()
                .VerifyOrgStandardsStatus("Live")
                .ReturnToOrganisationDetailsPage();
        }

        [Then(@"the admin can search using organisation ukprn")]
        public void ThenTheAdminCanSearchUsingOrganisationUkprn()
        {
            objectContext.SetOrganisationIdentifier(ePAOAdminDataHelper.OrganisationUkprn);

            organisationDetailsPage = adminStepshelper.SearchEpaoRegister(GoToEpaoAdminHomePage());
        }

        [Then(@"the admin can search batches")]
        public void ThenTheAdminCanSearchBatches() => GoToEpaoAdminHomePage().SearchEPAOBatch().SearchBatches().VerifyingBatchDetails().SignOut();

        private StaffDashboardPage GoToEpaoAdminHomePage() => ePAOHomePageHelper.LoginToEpaoAdminHomePage();
    }
}