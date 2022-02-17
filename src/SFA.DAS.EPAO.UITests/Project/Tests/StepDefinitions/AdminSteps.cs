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
        public void GivenTheAdminIsLoggedIntoTheAdminServiceApplication(string _) => staffDashboardPage = GoToEpaoAdminHomePage();

        [Given(@"the Admin can search using learner uln")]
        [When(@"the Admin can search using learner uln")]
        [Then(@"the Admin can search using learner uln")]
        public void GivenWhenThenTheAdminCanSearchUsingUln() => certificateDetailsPage = adminStepshelper.SearchAssessments(staffDashboardPage, ePAOAdminDataHelper.LearnerUln);

        [When(@"the Admin amends the certificate with ticket reference '(.*)' and selects reason '(.*)'")]
        public void WhenTheAdminAmendsTheCertificateAndEnteresAReasonForAmendment(string ticketReference, string amendReason)
        {
            checkAndSubmitAssessmentDetailsPage = certificateDetailsPage.
                ClickAmendCertificateLink().
                EnterTicketRefeferenceAndSelectReason(ticketReference, amendReason);
        }

        [When(@"the Admin reprints the certificate with ticket reference '(.*)' and selects reason '(.*)'")]
        public void WhenTheAdminReprintTheCertificateAndEnteresAReasonForAmendment(string ticketReference, string reprintReason)
        {
            checkAndSubmitAssessmentDetailsPage = certificateDetailsPage.
                ClickReprintCertificateLink().
                EnterTicketRefeferenceAndSelectReason(ticketReference, reprintReason);
        }

        [Then(@"the SendTo can be changed from '(employer|apprentice)' to '(employer|apprentice)'")]
        public void ThenTheSendToCanBeChangedFrom(string currentSentTo, string newSendTo)
        {
            certificateAddressPage = checkAndSubmitAssessmentDetailsPage.
                ClickChangeSendToLink().
                ChangeSendToRadioButtonAndContinue(currentSentTo, newSendTo);
        }

        [Then(@"the new address can be entered without employer name or recipient")]
        public void ThenTheNewAddressCanBeEnteredWithoutEmployerNameOrRecipient()
        {
            checkAndSubmitAssessmentDetailsPage = certificateAddressPage.
                EnterAddress("Cheylesmore House", "5 Quinton Rd", string.Empty, "Coventry", "CV12WT").
                EnterReasonForChangeAndContinue("A good reason");
        }

        [Then(@"the new address can be entered with employer name '(.*)' and recipient '(.*)'")]
        public void ThenThenNewAddressCanBeEnteredWithEmployerNameAndRecipient(string employer, string recipient)
        {
            checkAndSubmitAssessmentDetailsPage = certificateAddressPage.
                EnterRecipientName(recipient).
                EnterEmployerName(employer).
                EnterAddress("Cheylesmore House", "5 Quinton Rd", string.Empty, "Coventry", "CV12WT").
                EnterReasonForChangeAndContinue("Employer Name and Recipient details updated");
        }

        [Then(@"the recipient's name on the check page is '(.*)'")]
        public void ThenTheRecipientIsTheNewOneWhichWasEntered(string recipient) => checkAndSubmitAssessmentDetailsPage.VerifyRecipient(recipient);

        [Then(@"the recipient is defaulted to the apprentice name")]
        public void ThenTheRecipientIsDefaultedToTheApprenticeName() => checkAndSubmitAssessmentDetailsPage.VerifyRecipientIsApprentice();

        [Then(@"the address contains the employer name '(.*)'")]
        public void ThenTheAddressContainsTheEmployerName(string employer) => checkAndSubmitAssessmentDetailsPage.VerifyEmployer(employer);

        [When(@"the Admin amends the certificate")]
        public void WhenTheAdminAmendsTheCertificate() => amendReasonPage = certificateDetailsPage.ClickAmendCertificateLink();
        
        [When(@"the Admin reprints the certificate")]
        public void WhenTheAdminReprintsTheCertificate() => reprintReasonPage = certificateDetailsPage.ClickReprintCertificateLink();

        [Then(@"the ticket reference '(.*)' and reason for amend '(.*)' can be entered")]
        public void ThenTheReasonForAmendCanBeEntered(string ticketReference, string reasonForAmend)
        {
            checkAndSubmitAssessmentDetailsPage = amendReasonPage.
                EnterTicketRefeferenceAndSelectReason(ticketReference, reasonForAmend);
        }

        [Then(@"the ticket reference '(.*)' and reason for reprint '(.*)' can be entered")]
        public void ThenTheReasonForReprintCanBeEntered(string ticketReference, string reasonForReprint)
        {
            checkAndSubmitAssessmentDetailsPage = reprintReasonPage.
                EnterTicketRefeferenceAndSelectReason(ticketReference, reasonForReprint);
        }

        [Then(@"the amend can be confirmed")]
        public void ThenTheAmendCanBeConfirmed() => confirmationAmendPage = checkAndSubmitAssessmentDetailsPage.ClickConfirmAmend();

        [Then(@"the reprint can be confirmed")]
        public void ThenTheReprintCanBeConfirmed() => confirmationReprintPage = checkAndSubmitAssessmentDetailsPage.ClickConfirmReprint();

        [Then(@"the certificate history contains the incident number '(.*)' and amend reason '(.*)'")]
        public void ThenTheCertificateHistoryContainsTheReasonForAmending(string incidentNumber, string amendReason)
        {
            confirmationAmendPage.ClickSearchAgain().
                SearchFor(ePAOAdminDataHelper.LearnerUln).
                SelectACertificate().
                VerifyActionHistoryItem(1, "AmendReason").
                VerifyIncidentNumber(1, incidentNumber).
                VerifyFirstReason(1, amendReason);
        }

        [Then(@"the certificate history contains the incident number '(.*)' and reprint reason '(.*)'")]
        public void ThenTheCertificateHistoryContainsTheReasonForReprinting(string incidentNumber, string reprintReason)
        {
            confirmationReprintPage.ClickSearchAgain().
                SearchFor(ePAOAdminDataHelper.LearnerUln).
                SelectACertificate().
                VerifyActionHistoryItem(1, "Reprint").
                VerifyActionHistoryItem(2, "ReprintReason").
                VerifyIncidentNumber(2, incidentNumber).
                VerifyFirstReason(2, reprintReason);
        }

        [Then(@"the admin can search batches")]
        public void ThenTheAdminCanSearchBatches() => GoToEpaoAdminHomePage().SearchEPAOBatch().SearchBatches().VerifyingBatchDetails().SignOut();

        private StaffDashboardPage GoToEpaoAdminHomePage() => ePAOHomePageHelper.LoginToEpaoAdminHomePage();
    }
}