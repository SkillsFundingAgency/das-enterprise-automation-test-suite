using System;
using System.Collections.Generic;
using System.Text;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway
{
   public  class OrganisationsCriminalAndComplianceChecks_Section5Helpers
    {
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_CompositionWithCreditors(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section5_CompositionWithCreditors()
            .SelectPassAndContinue()
            .VerifyCompositionwithcreditors_Section5(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_FailedToPayBackFunds(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section5_FailedToPayBackFunds()
            .SelectPassAndContinue()
            .VerifyFailedtopaybackfunds_Section5(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_ContractTerminatedEarlyByPublicBody(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section5_ContractTErminatedEarlyByPublicBody()
            .SelectPassAndContinue()
            .VerifyContractterminatedearlybyapublicbody_Section5(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_WithDrawnFromContractEarlyByPublicBody(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section5_WithdrawnFromContractWithPublicBody()
            .SelectPassAndContinue()
            .VerifyWithdrawnfromacontractwithapublicbody_Section5(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_RegisterOfTrainingOrganisations(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section5_ROTO()
            .SelectPassAndContinue()
            .VerifyRegisterofTrainingOrganisations_RoTO_Section5(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_FudingRemovedFromAnyEducationBodies(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section5_FundingRemovedFromEducationBodies()
            .SelectPassAndContinue()
            .VerifyFundingremovedfromanyeducationbodies_Section5(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_RemovedFromAnyProfessionalOrTradeBodies(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section5_RemovedFromProfessionalOrTradeRegisters()
            .SelectPassAndContinue()
            .VerifyRemovedfromanyprofessionalortraderegisters_Section5(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_ITTAccreditation(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section5_InitialTeacherTrainingAccreditation()
            .SelectPassAndContinue()
            .VerifyInitialTeacherTrainingaccreditation_Section5(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_RemovedFromAnyCharityRegister(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section5_RemovedFromCharityRegister()
            .SelectPassAndContinue()
            .VerifyRemovedfromanycharityregister_Section5(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_InvestigatedDueToSafeGuardingIssues(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section5_InvestigatedDueToSafeguarding()
            .SelectPassAndContinue()
            .VerifyInvestigatedduetosafeguardingissues_Section5(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_InvestigatedDuetoWhistleBlowingIssues(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section5_InvestigatedDueToWhistleblowig()
            .SelectPassAndContinue()
            .VerifyInvestigatedduetowhistleblowingissues_Section5(StatusHelper_AdminPage.StatusPass);
        }
        internal GWApplicationOverviewPage PassOrganisationsCriminalAndComplianceChecks_InsolvencyOrWindingProceedings(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section5_InsolvencyOrWindingUpProceedings()
            .SelectPassAndContinue()
            .VerifyInsolvencyorwindingupproceedings_Section5(StatusHelper_AdminPage.StatusPass);
        }
    }
}
