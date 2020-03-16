using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AdminSteps
    {
        private readonly ScenarioContext _context;
        private readonly EPAOAdminDataHelper _ePAOAdminDataHelper;
        private CertificateDetailsPage _certificateDetailsPage;
        private OrganisationDetailsPage _organisationDetailsPage;

        public AdminSteps(ScenarioContext context)
        {
            _context = context;
            _ePAOAdminDataHelper = context.Get<EPAOAdminDataHelper>();
        }

        [Then(@"the admin can add organisation")]
        public void ThenTheAdminCanAddOrganisation() => GoToEpaoAdminHomePage().AddOrganisation().EnterDetails();

        [Then(@"the admin can search using organisation name")]
        public void ThenTheAdminCanSearchUsingOrganisationName() => _organisationDetailsPage = SearchEpaoRegister(_ePAOAdminDataHelper.OrganisationName);

        [Then(@"the admin can search using organisation epao id")]
        public void ThenTheAdminCanSearchUsingOrganisationEpaoId() => _organisationDetailsPage = SearchEpaoRegister(_ePAOAdminDataHelper.OrganisationEpaoId);

        [Then(@"the admin can add contact details")]
        public void ThenTheAdminCanAddContactDetails() => _organisationDetailsPage = _organisationDetailsPage.AddNewContact().AddContact().ReturnToOrganisationDetailsPage().SelectContact().ReturnToOrganisationDetailsPage();

        [Then(@"the admin can add standards details")]
        public void ThenTheAdminCanAddStandardsDetails() => _organisationDetailsPage = _organisationDetailsPage.AddAStandard().SearchStandards().AddStandardToOrganisation().AddStandardsDetails().VerifyStandards().ReturnToOrganisationDetailsPage();

        [Then(@"the admin can view standards details")]
        public void ThenTheAdminCanViewStandardsDetails() => _organisationDetailsPage = _organisationDetailsPage.SelectStandards().ReturnToOrganisationDetailsPage();

        [Then(@"the admin can search using organisation ukprn")]
        public void ThenTheAdminCanSearchUsingOrganisationUkprn() => _organisationDetailsPage = SearchEpaoRegister(_ePAOAdminDataHelper.OrganisationUkprn);

        [Then(@"the admin can search batches")]
        public void ThenTheAdminCanSearchBatches() => GoToEpaoAdminHomePage().SearchEPAOBatch().SearchBatches().VerifyingBatchDetails().SignOut();

        [Then(@"the admin can search using uln")]
        public void ThenTheAdminCanSearchUsingUln() => _certificateDetailsPage = GoToEpaoAdminHomePage().Search().SearchFor(_ePAOAdminDataHelper.LearnerUln).SelectACertificate();

        [Then(@"the admin can access learners audit history")]
        public void ThenTheAdminCanAccessLearnersAuditHistory() => _certificateDetailsPage.ShowAllHistory();

        private OrganisationDetailsPage SearchEpaoRegister(string keyword) => GoToEpaoAdminHomePage().SearchEPAO().SearchForAnOrganisation(keyword).SelectAnOrganisation();

        private StaffDashboardPage GoToEpaoAdminHomePage()
        {
            new ServiceStartPage(_context).ClickStartNow().LoginToAccess1Staff();

            return new SignInPage(_context).SignInWithValidDetails();
        }
    }
}
