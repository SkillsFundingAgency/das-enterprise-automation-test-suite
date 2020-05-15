using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway
{
    public class GatewayEndtoEndStepsHelpers
    {
        private readonly OrganisationChecks_Section1Helpers _organisationChecksSectionHelpers;
        private readonly PeopleInControlChecks_Section2Helpers _peopleInControlChecksSectionHelpers;
        private readonly RegisterChecks_Section3Helpers _registerChecks_SectionHelpers;
        private readonly ExperienceAndAccreditationChecks_Section4Helpers _experienceAndAccreditationChecks_SectionHelpers;
        private readonly OrganisationsCriminalAndComplianceChecks_Section5Helpers _organisationsCriminalAndComplianceChecks_SectionHelpers;
        private readonly PeopleInControlCriminalAndComplianceChecks_Section6Helpers _peopleInControlCriminalAndComplianceChecksSectionHelpers;
        private ScenarioContext context;

        public GatewayEndtoEndStepsHelpers()
        {
            _organisationChecksSectionHelpers = new OrganisationChecks_Section1Helpers();
            _peopleInControlChecksSectionHelpers = new PeopleInControlChecks_Section2Helpers();
            _registerChecks_SectionHelpers = new RegisterChecks_Section3Helpers();
            _experienceAndAccreditationChecks_SectionHelpers = new ExperienceAndAccreditationChecks_Section4Helpers();
            _organisationsCriminalAndComplianceChecks_SectionHelpers = new OrganisationsCriminalAndComplianceChecks_Section5Helpers();
            _peopleInControlCriminalAndComplianceChecksSectionHelpers = new PeopleInControlCriminalAndComplianceChecks_Section6Helpers();
        }

        public GatewayEndtoEndStepsHelpers(ScenarioContext context)
        {
            this.context = context;
        }

        internal GWApplicationOverviewPage CompleteOrganisationChecks_Section1_TradingNameNotRequired(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = _organisationChecksSectionHelpers.PassOrganisationChecks_LegalName(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationChecksSectionHelpers.NotRequiredOrganisationChecks_TradingName(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationChecksSectionHelpers.PassOrganisationChecks_OrganisationStatus(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationChecksSectionHelpers.PassOrganisationChecks_Address(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationChecksSectionHelpers.PassOrganisationChecks_ICONumber(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationChecksSectionHelpers.PassOrganisationChecks_WebsiteAddress(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationChecksSectionHelpers.PassOrganisationChecks_OrganisationHighRisk(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal GWApplicationOverviewPage CompletePeopleInControlChecks_Section2(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = _peopleInControlChecksSectionHelpers.PassPeopleInControlChecks_PeopleInControl(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _peopleInControlChecksSectionHelpers.PassPeopleInControlChecks_PeopleInControlHighRisk(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal GWApplicationOverviewPage CompleteRegisterChecks_Section3(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = _registerChecks_SectionHelpers.PassRegisterChecks_ROATP(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _registerChecks_SectionHelpers.PassRegisterChecks_RegisterOfEndPointAssessmentOrganisations(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal GWApplicationOverviewPage CompleteExperienceAndAccreditationChecks_Section4_NotRequired_OFS_ITT_SubContractor(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = _experienceAndAccreditationChecks_SectionHelpers.NotRequiredExperienceAndAccreditationChecks_OFS_ITT(gwApplicationOverviewPage);
            //gwApplicationOverviewPage = _experienceAndAccreditationChecks_SectionHelpers.PassExperienceAndAccreditationChecks_InitialTeacherTraining(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _experienceAndAccreditationChecks_SectionHelpers.PassExperienceAndAccreditationChecks_Ofsted(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _experienceAndAccreditationChecks_SectionHelpers.NotRequiredExperienceAndAccreditationChecks_SubContractor(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal GWApplicationOverviewPage CompleteOrganisationsCriminalAndComplianceChecks_Section5(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = _organisationsCriminalAndComplianceChecks_SectionHelpers.PassOrganisationsCriminalAndComplianceChecks_CompositionWithCreditors(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationsCriminalAndComplianceChecks_SectionHelpers.PassOrganisationsCriminalAndComplianceChecks_FailedToPayBackFunds(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationsCriminalAndComplianceChecks_SectionHelpers.PassOrganisationsCriminalAndComplianceChecks_ContractTerminatedEarlyByPublicBody(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationsCriminalAndComplianceChecks_SectionHelpers.PassOrganisationsCriminalAndComplianceChecks_WithDrawnFromContractEarlyByPublicBody(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationsCriminalAndComplianceChecks_SectionHelpers.PassOrganisationsCriminalAndComplianceChecks_RegisterOfTrainingOrganisations(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationsCriminalAndComplianceChecks_SectionHelpers.PassOrganisationsCriminalAndComplianceChecks_FudingRemovedFromAnyEducationBodies(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationsCriminalAndComplianceChecks_SectionHelpers.PassOrganisationsCriminalAndComplianceChecks_RemovedFromAnyProfessionalOrTradeBodies(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationsCriminalAndComplianceChecks_SectionHelpers.PassOrganisationsCriminalAndComplianceChecks_ITTAccreditation(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationsCriminalAndComplianceChecks_SectionHelpers.PassOrganisationsCriminalAndComplianceChecks_RemovedFromAnyCharityRegister(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationsCriminalAndComplianceChecks_SectionHelpers.PassOrganisationsCriminalAndComplianceChecks_InvestigatedDueToSafeGuardingIssues(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationsCriminalAndComplianceChecks_SectionHelpers.PassOrganisationsCriminalAndComplianceChecks_InvestigatedDuetoWhistleBlowingIssues(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _organisationsCriminalAndComplianceChecks_SectionHelpers.PassOrganisationsCriminalAndComplianceChecks_InsolvencyOrWindingProceedings(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal GWApplicationOverviewPage CompletePeopleInControlCriminalAndComplianceChecks_Section6(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage = _peopleInControlCriminalAndComplianceChecksSectionHelpers.PassOrganisationsCriminalAndComplianceChecks_UnSpentCriminalConvictions(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _peopleInControlCriminalAndComplianceChecksSectionHelpers.PassOrganisationsCriminalAndComplianceChecks_FailedToPayBackFunds(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _peopleInControlCriminalAndComplianceChecksSectionHelpers.PassOrganisationsCriminalAndComplianceChecks_InvestigatedForFraudOrIrregularities(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _peopleInControlCriminalAndComplianceChecksSectionHelpers.PassOrganisationsCriminalAndComplianceChecks_OngoingInvestigationForFraudOrIrregularities(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _peopleInControlCriminalAndComplianceChecksSectionHelpers.PassOrganisationsCriminalAndComplianceChecks_ContractTerminatedEarlyByPublicBody(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _peopleInControlCriminalAndComplianceChecksSectionHelpers.PassOrganisationsCriminalAndComplianceChecks_WithdrawnFromContractWithApublic(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _peopleInControlCriminalAndComplianceChecksSectionHelpers.PassOrganisationsCriminalAndComplianceChecks_BreachedTaxPaymentsOrSocialSecurityContributions(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _peopleInControlCriminalAndComplianceChecksSectionHelpers.PassOrganisationsCriminalAndComplianceChecks_RegisterOfRemovedTrustees(gwApplicationOverviewPage);
            gwApplicationOverviewPage = _peopleInControlCriminalAndComplianceChecksSectionHelpers.PassOrganisationsCriminalAndComplianceChecks_BeenMadeBankrupt(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal GWApplicationOverviewPage CompleteAllSectionsWithPass(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            CompleteOrganisationChecks_Section1_TradingNameNotRequired(gwApplicationOverviewPage);
            CompletePeopleInControlChecks_Section2(gwApplicationOverviewPage);
            CompleteRegisterChecks_Section3(gwApplicationOverviewPage);
            CompleteExperienceAndAccreditationChecks_Section4_NotRequired_OFS_ITT_SubContractor(gwApplicationOverviewPage);
            CompleteOrganisationsCriminalAndComplianceChecks_Section5(gwApplicationOverviewPage);
            CompletePeopleInControlCriminalAndComplianceChecks_Section6(gwApplicationOverviewPage);
            return gwApplicationOverviewPage;
        }

        internal FinalConfirmationPage ConfirmGatewayOutcomeAsPass(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            gwApplicationOverviewPage.Access_Section7_ConfirmGateWayOutcome()
                 .PassThisApplicationAndContinue()
                 .YesSurePassThisApplicationAndGoToGovernance();
            return new FinalConfirmationPage(context);
        }
    }
}