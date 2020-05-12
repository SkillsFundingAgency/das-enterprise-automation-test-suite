
using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public partial class GWApplicationOverviewPage : RoatpGateWayBasePage
    {
        private void NavigateToTask(string sectionName, string taskName, int index = 0) => formCompletionHelper.ClickElement(GetTaskLinkElement(sectionName, taskName, index));

        #region Section-1 Organisation Checks
        public LegalNameCheckPage Access_Section1_LegalName()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_1);
            return new LegalNameCheckPage(_context);
        }
        public TradingNameCheckPage Access_Section1_TradingName()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_2);
            return new TradingNameCheckPage(_context);
        }
        public OrganisationStatusCheckPage Access_Section1_OrganisationStatus()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_3);
            return new OrganisationStatusCheckPage(_context);
        }
        public AddressCheckPage Access_Section1_Address()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_4);
            return new AddressCheckPage(_context);
        }
        public ICONumberCheckPage Access_Section1_IcoRegistrationNumber()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_5);
            return new ICONumberCheckPage(_context);
        }
        public WebsiteAddressCheckPage Access_Section1_WebsiteAddress()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_6);
            return new WebsiteAddressCheckPage(_context);
        }
        public OrganisationHighRiskCheckPage Access_Section1_OrganisationHighRisk()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_7);
            return new OrganisationHighRiskCheckPage(_context);
        }
        #endregion

        #region Section-2 People In Control Checks
        public PeopleInControlCheckPage Access_Section2_PeopleInControl()
        {
            NavigateToTask(PeopleincontrolChecks, PeopleincontrolChecks_1);
            return new PeopleInControlCheckPage(_context);
        }
        public PeopleInControlHighRiskCheckPage Access_Section2_PeopleInControlHighRisk()
        {
            NavigateToTask(OrganisationChecks, PeopleincontrolChecks_2);
            return new PeopleInControlHighRiskCheckPage(_context);
        }
        #endregion

        #region Section-3 RegisterChecks
        public RoatpCheckPage Access_Section3_ROATP()
        {
            NavigateToTask(RegisterChecks, RegisterChecks_1);
            return new RoatpCheckPage(_context);
        }
        public RegisterOfEPAOCheckPage Access_Section3_RegisterOfEPAO()
        {
            NavigateToTask(RegisterChecks, RegisterChecks_2);
            return new RegisterOfEPAOCheckPage(_context);
        }
        #endregion

        #region Section-4 Experience And Accreditation Checks
        public OfficeForStudentCheckPage Access_Section4_OFS()
        {
            NavigateToTask(ExperienceAndAccreditationChecks, ExperienceAndAccreditationChecks_1);
            return new OfficeForStudentCheckPage(_context);
        }
        public InitialTeacherTrainingCheckPage Access_Section4_ITT()
        {
            NavigateToTask(ExperienceAndAccreditationChecks, ExperienceAndAccreditationChecks_2);
            return new InitialTeacherTrainingCheckPage(_context);
        }
        public OfsteadCheckPage Access_Section4_Ofstead()
        {
            NavigateToTask(ExperienceAndAccreditationChecks, ExperienceAndAccreditationChecks_3);
            return new OfsteadCheckPage(_context);
        }
        public SubcontractorDeclarationCheckPage Access_Section4_SubcontractorDeclaration()
        {
            NavigateToTask(ExperienceAndAccreditationChecks, ExperienceAndAccreditationChecks_4);
            return new SubcontractorDeclarationCheckPage(_context);
        }
        #endregion

        #region Section-5 Organisation's Criminal And Compliance Checks
        public CompositionWithCreditorsPage Access_Section5_CompositionWithCreditors()
        {
            NavigateToTask(OrganisationsCriminalandComplianceChecks, OrganisationsCriminalandComplianceChecks_1);
            return new CompositionWithCreditorsPage(_context);
        }
        public FailedToPayBackFundsCheckPage Access_Section5_FailedToPayBackFunds()
        {
            NavigateToTask(OrganisationsCriminalandComplianceChecks, OrganisationsCriminalandComplianceChecks_2);
            return new FailedToPayBackFundsCheckPage(_context);
        }
        public ContractTerminatedByPublicBodyCheckPage Access_Section5_ContractTErminatedEarlyByPublicBody()
        {
            NavigateToTask(OrganisationsCriminalandComplianceChecks, OrganisationsCriminalandComplianceChecks_3);
            return new ContractTerminatedByPublicBodyCheckPage(_context);
        }
        public WithdrawnFromContractWithPublicBodyCheckPage Access_Section5_WithdrawnFromContractWithPublicBody()
        {
            NavigateToTask(OrganisationsCriminalandComplianceChecks, OrganisationsCriminalandComplianceChecks_4);
            return new WithdrawnFromContractWithPublicBodyCheckPage(_context);
        }
        public RemovedFromROTOCheckPage Access_Section5_ROTO()
        {
            NavigateToTask(OrganisationsCriminalandComplianceChecks, OrganisationsCriminalandComplianceChecks_5);
            return new RemovedFromROTOCheckPage(_context);
        }
        public FundingRemovedFromEducationalBodiesCheckPage Access_Section5_FundingRemovedFromEducationBodies()
        {
            NavigateToTask(OrganisationsCriminalandComplianceChecks, OrganisationsCriminalandComplianceChecks_6);
            return new FundingRemovedFromEducationalBodiesCheckPage(_context);
        }
        public RemovedFromProfessionalOrTradeRegistersCheckPage Access_Section5_RemovedFromProfessionalOrTradeRegisters()
        {
            NavigateToTask(OrganisationsCriminalandComplianceChecks, OrganisationsCriminalandComplianceChecks_7);
            return new RemovedFromProfessionalOrTradeRegistersCheckPage(_context);
        }
        public InitialTeacherTrainingCheckPage Access_Section5_InitialTeacherTrainingAccreditation()
        {
            NavigateToTask(OrganisationsCriminalandComplianceChecks, OrganisationsCriminalandComplianceChecks_8);
            return new InitialTeacherTrainingCheckPage(_context);
        }
        public RemovedFromAnyCharityRegisterCheckPage Access_Section5_RemovedFromCharityRegister()
        {
            NavigateToTask(OrganisationsCriminalandComplianceChecks, OrganisationsCriminalandComplianceChecks_9);
            return new RemovedFromAnyCharityRegisterCheckPage(_context);
        }
        public InvestigatedDuetoSafeguardingIssuesCheckPage Access_Section5_InvestigatedDueToSafeguarding()
        {
            NavigateToTask(OrganisationsCriminalandComplianceChecks, OrganisationsCriminalandComplianceChecks_10);
            return new InvestigatedDuetoSafeguardingIssuesCheckPage(_context);
        }
        public InvestigatedDuetoWhistleBlowingIssuesCheckPage Access_Section5_InvestigatedDueToWhistleblowig()
        {
            NavigateToTask(OrganisationsCriminalandComplianceChecks, OrganisationsCriminalandComplianceChecks_11);
            return new InvestigatedDuetoWhistleBlowingIssuesCheckPage(_context);
        }
        public InsolvencyOrWindingUpProceedingsPage Access_Section5_InsolvencyOrWindingUpProceedings()
        {
            NavigateToTask(OrganisationsCriminalandComplianceChecks, OrganisationsCriminalandComplianceChecks_12);
            return new InsolvencyOrWindingUpProceedingsPage(_context);
        }
        #endregion

        #region Section-6 People In Control Criminal And Compliance Checks
        public UnspentCriminalConvictionsCheckPage Access_Section6_UnspentCriminalConvictions()
        {
            NavigateToTask(PeopleinControlsCriminalandComplianceChecks, PeopleinControlsCriminalandComplianceChecks_1);
            return new UnspentCriminalConvictionsCheckPage(_context);
        }
        public FailedToPayBackFundsPage Access_Section6_FailedToPayBackFunds()
        {
            NavigateToTask(PeopleinControlsCriminalandComplianceChecks, PeopleinControlsCriminalandComplianceChecks_2);
            return new FailedToPayBackFundsPage(_context);
        }
        public InvestigatedForFraudOrIrregularitiesPage Access_Section6_InvestigatedForFraudorIrregularities()
        {
            NavigateToTask(PeopleinControlsCriminalandComplianceChecks, PeopleinControlsCriminalandComplianceChecks_3);
            return new InvestigatedForFraudOrIrregularitiesPage(_context);
        }
        public OngoingInvestigationsForFraudOrIrregularitiesCheckPage Access_Section6_OngoingInvestigationsForFraudorIrregularities()
        {
            NavigateToTask(PeopleinControlsCriminalandComplianceChecks, PeopleinControlsCriminalandComplianceChecks_4);
            return new OngoingInvestigationsForFraudOrIrregularitiesCheckPage(_context);
        }
        public ContractTerminatedByPublicBodyCheckPage Access_Section6_ContractTerminateEarlyByPublicBody()
        {
            NavigateToTask(PeopleinControlsCriminalandComplianceChecks, PeopleinControlsCriminalandComplianceChecks_5);
            return new ContractTerminatedByPublicBodyCheckPage(_context);
        }
        public WithdrawnFromContractWithPublicBodyCheckPage Access_Section6_WithdrawnFromContractWithPublicBody()
        {
            NavigateToTask(PeopleinControlsCriminalandComplianceChecks, PeopleinControlsCriminalandComplianceChecks_6);
            return new WithdrawnFromContractWithPublicBodyCheckPage(_context);
        }
        public BreachedTaxPaymentsCheckPage Access_Section6_BreachedTaxPaymentsOrSocialSecurityPayments()
        {
            NavigateToTask(PeopleinControlsCriminalandComplianceChecks, PeopleinControlsCriminalandComplianceChecks_7);
            return new BreachedTaxPaymentsCheckPage(_context);
        }
        public RegisterOfRemovedTrusteesCheckPage Access_Section6_RegisterOfREmovedTrustees()
        {
            NavigateToTask(PeopleinControlsCriminalandComplianceChecks, PeopleinControlsCriminalandComplianceChecks_8);
            return new RegisterOfRemovedTrusteesCheckPage(_context);
        }
        public BeenMadeBankruptCheckPage Access_Section6_BeenMadeBankrupt()
        {
            NavigateToTask(PeopleinControlsCriminalandComplianceChecks, PeopleinControlsCriminalandComplianceChecks_9);
            return new BeenMadeBankruptCheckPage(_context);
        }
        #endregion

        #region Section-6 People In Control Criminal And Compliance Checks
        public ConfirmGatewayOutcomePage Access_Section7_ConfirmGateWayOutcome()
        {
            NavigateToTask(OverallGatewayOutcome, OverallGatewayOutcome_1);
            return new ConfirmGatewayOutcomePage(_context);
        }
        #endregion
    }
}