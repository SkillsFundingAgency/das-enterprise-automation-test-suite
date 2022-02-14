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

        [Then(@"the admin can search using organisation ukprn")]
        public void ThenTheAdminCanSearchUsingOrganisationUkprn()
        {
            objectContext.SetOrganisationIdentifier(ePAOAdminDataHelper.OrganisationUkprn);

            organisationDetailsPage = adminStepshelper.SearchEpaoRegister(GoToEpaoAdminHomePage());
        }

        [Given(@"the (Admin all roles user) is logged into the Admin Service Application")]
        public void GivenTheAdminIsLoggedIntoTheAdminServiceApplication(string userName)
        {
            staffDashboardPage = GoToEpaoAdminHomePage();
        }

        [Given(@"the Admin can search using learner uln")]
        [When(@"the Admin can search using learner uln")]
        [Then(@"the Admin can search using learner uln")]
        public void GivenOrThenTheAdminCanSearchUsingUln()
        {
            certificateDetailsPage = adminStepshelper.SearchAssessments(staffDashboardPage, ePAOAdminDataHelper.LearnerUln);
        }

        [When(@"the Admin amends the certificate")]
        public void WhenTheAdminAmendsTheCertificate()
        {
            amendReasonPage = certificateDetailsPage.
                ClickAmendCertificateLink();
                
        }

        [Then(@"the reason for amend can be entered")]
        public void ThenTheReasonForAmendCanBeEntered()
        {
            checkAndSubmitAssessmentDetailsPage = amendReasonPage.
                EnterTicketReferenceAndSelectReason("1234567890", "Incorrect apprentice details");
        }

        [Then(@"the amend can be confirmed")]
        public void ThenTheAmendCanBeConfirmed()
        {
            confirmationAmendPage = checkAndSubmitAssessmentDetailsPage.
                ClickConfirmAmend();
        }

        [Then(@"the certificate history contains the reason for amending")]
        public void ThenTheCertificateHistoryContainsTheReasonForAmending()
        {
            confirmationAmendPage.ClickSearchAgain().
                SearchFor(ePAOAdminDataHelper.LearnerUln).
                SelectACertificate().
                VerifyActionHistoryItem(1, "AmendReason").
                VerifyIncidentNumber(1, "1234567890").
                VerifyFirstReason(1, "Incorrect apprentice details");
        }

        [When(@"the Admin reprints the certificate")]
        public void WhenTheAdminReprintsTheCertificate()
        {
            reprintReasonPage = certificateDetailsPage.
                ClickReprintCertificateLink();
        }

        [Then(@"the reason for reprint can be entered")]
        public void ThenTheReasonForReprintCanBeEntered()
        {
            checkAndSubmitAssessmentDetailsPage = reprintReasonPage.
            EnterTicketReferenceAndSelectReason();
        }

        [Then(@"the reprint can be confirmed")]
        public void ThenTheReprintCanBeConfirmed()
        {
            confirmationReprintPage = checkAndSubmitAssessmentDetailsPage.
                ClickConfirmReprint();
        }

        [Then(@"the certificate history contains the reason for reprinting")]
        public void ThenTheCertificateHistoryContainsTheReasonForReprinting()
        {
            confirmationReprintPage.ClickSearchAgain().
                SearchFor(ePAOAdminDataHelper.LearnerUln).
                SelectACertificate().
                VerifyActionHistoryItem(1, "Reprint").
                VerifyActionHistoryItem(2, "ReprintReason").
                VerifyIncidentNumber(2, "1234567890").
                VerifyFirstReason(2, "Delivery failed");
        }

        [Then(@"the admin can search batches")]
        public void ThenTheAdminCanSearchBatches() => GoToEpaoAdminHomePage().SearchEPAOBatch().SearchBatches().VerifyingBatchDetails().SignOut();

        private StaffDashboardPage GoToEpaoAdminHomePage() => ePAOHomePageHelper.LoginToEpaoAdminHomePage();
    }
}