
using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.ExperienceAndAccreditationChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OrganisationsCriminalAndComplianceChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OverallGatewayOutcome;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.PeopleIncontrolChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.PeopleInControlCriminalAndComplianceChecks;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.RegisterChecks;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public partial class GWApplicationOverviewPage : RoatpGateWayBasePage
    {
        private void NavigateToTask(string sectionName, string taskName, int index = 0) => formCompletionHelper.ClickElement(GetTaskLinkElement(sectionName, taskName, index));

        #region Section-1 Organisation Checks

        public OneApplicationsIn12MonthsPage Access_Section1_1ApplicationInTwelveMonths()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_1);
            return new OneApplicationsIn12MonthsPage(_context);
        }
        public LegalNameCheckPage Access_Section1_LegalName()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_2);
            return new LegalNameCheckPage(_context);
        }
        public TradingNameCheckPage Access_Section1_TradingName()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_3);
            return new TradingNameCheckPage(_context);
        }
        public OrganisationStatusCheckPage Access_Section1_OrganisationStatus()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_4);
            return new OrganisationStatusCheckPage(_context);
        }
        public AddressCheckPage Access_Section1_Address()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_5);
            return new AddressCheckPage(_context);
        }
        public ICONumberCheckPage Access_Section1_IcoRegistrationNumber()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_6);
            return new ICONumberCheckPage(_context);
        }
        public WebsiteAddressCheckPage Access_Section1_WebsiteAddress()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_7);
            return new WebsiteAddressCheckPage(_context);
        }
        public OrganisationHighRiskCheckPage Access_Section1_OrganisationHighRisk()
        {
            NavigateToTask(OrganisationChecks, OrganisationChecks_8);
            return new OrganisationHighRiskCheckPage(_context);
        }
        #endregion

        #region Section-2 People In Control Checks
        public PeopleInControlCheckPage Access_Section2_PeopleInControl()
        {
            NavigateToTask(PeopleInControlChecks, PeopleInControlChecks_1);
            return new PeopleInControlCheckPage(_context);
        }
        public PeopleInControlHighRiskCheckPage Access_Section2_PeopleInControlHighRisk()
        {
            NavigateToTask(PeopleInControlChecks, PeopleInControlChecks_2);
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
        public CompositionWithCreditorsCheckPage Access_Section5_CompositionWithCreditors()
        {
            NavigateToTask(OrganisationsCriminalAndComplianceChecks, OrganisationsCriminalAndComplianceChecks_1);
            return new CompositionWithCreditorsCheckPage(_context);
        }
        public FailedToPayBackFundsCheckPage Access_Section5_FailedToPayBackFunds()
        {
            NavigateToTask(OrganisationsCriminalAndComplianceChecks, OrganisationsCriminalAndComplianceChecks_2);
            return new FailedToPayBackFundsCheckPage(_context);
        }
        public ContractTerminatedEarlyCheckPage Access_Section5_ContractTErminatedEarlyByPublicBody()
        {
            NavigateToTask(OrganisationsCriminalAndComplianceChecks, OrganisationsCriminalAndComplianceChecks_3);
            return new ContractTerminatedEarlyCheckPage(_context);
        }
        public WithdrawnFromContractWithPublicBodyCheckPage Access_Section5_WithdrawnFromContractWithPublicBody()
        {
            NavigateToTask(OrganisationsCriminalAndComplianceChecks, OrganisationsCriminalAndComplianceChecks_4);
            return new WithdrawnFromContractWithPublicBodyCheckPage(_context);
        }
        public RemovedFromROTOCheckPage Access_Section5_ROTO()
        {
            NavigateToTask(OrganisationsCriminalAndComplianceChecks, OrganisationsCriminalAndComplianceChecks_5);
            return new RemovedFromROTOCheckPage(_context);
        }
        public FundingRemovedFromEducationalBodiesCheckPage Access_Section5_FundingRemovedFromEducationBodies()
        {
            NavigateToTask(OrganisationsCriminalAndComplianceChecks, OrganisationsCriminalAndComplianceChecks_6);
            return new FundingRemovedFromEducationalBodiesCheckPage(_context);
        }
        public RemovedFromProfessionalOrTradeRegistersCheckPage Access_Section5_RemovedFromProfessionalOrTradeRegisters()
        {
            NavigateToTask(OrganisationsCriminalAndComplianceChecks, OrganisationsCriminalAndComplianceChecks_7);
            return new RemovedFromProfessionalOrTradeRegistersCheckPage(_context);
        }
        public ITTInLastThreeYearsCheckPage Access_Section5_InitialTeacherTrainingAccreditation()
        {
            NavigateToTask(OrganisationsCriminalAndComplianceChecks, OrganisationsCriminalAndComplianceChecks_8);
            return new ITTInLastThreeYearsCheckPage(_context);
        }
        public RemovedFromAnyCharityRegisterCheckPage Access_Section5_RemovedFromCharityRegister()
        {
            NavigateToTask(OrganisationsCriminalAndComplianceChecks, OrganisationsCriminalAndComplianceChecks_9);
            return new RemovedFromAnyCharityRegisterCheckPage(_context);
        }
        public InvestigatedDuetoSafeguardingIssuesCheckPage Access_Section5_InvestigatedDueToSafeguarding()
        {
            NavigateToTask(OrganisationsCriminalAndComplianceChecks, OrganisationsCriminalAndComplianceChecks_10);
            return new InvestigatedDuetoSafeguardingIssuesCheckPage(_context);
        }
        public InvestigatedDuetoWhistleBlowingIssuesCheckPage Access_Section5_InvestigatedDueToWhistleblowig()
        {
            NavigateToTask(OrganisationsCriminalAndComplianceChecks, OrganisationsCriminalAndComplianceChecks_11);
            return new InvestigatedDuetoWhistleBlowingIssuesCheckPage(_context);
        }
        public SubjectToInsolvencyCheckPage Access_Section5_InsolvencyOrWindingUpProceedings()
        {
            NavigateToTask(OrganisationsCriminalAndComplianceChecks, OrganisationsCriminalAndComplianceChecks_12);
            return new SubjectToInsolvencyCheckPage(_context);
        }
        #endregion

        #region Section-6 People In Control Criminal And Compliance Checks
        public UnspentCriminalConvictionsCheckPage Access_Section6_UnspentCriminalConvictions()
        {
            NavigateToTask(PeopleInControlsCriminalAndComplianceChecks, PeopleInControlsCriminalAndComplianceChecks_1);
            return new UnspentCriminalConvictionsCheckPage(_context);
        }
        public FailedToPayBackFundsPage Access_Section6_FailedToPayBackFunds()
        {
            NavigateToTask(PeopleInControlsCriminalAndComplianceChecks, PeopleInControlsCriminalAndComplianceChecks_2);
            return new FailedToPayBackFundsPage(_context);
        }
        public InvestigatedForFraudOrIrregularitiesPage Access_Section6_InvestigatedForFraudorIrregularities()
        {
            NavigateToTask(PeopleInControlsCriminalAndComplianceChecks, PeopleInControlsCriminalAndComplianceChecks_3);
            return new InvestigatedForFraudOrIrregularitiesPage(_context);
        }
        public OngoingInvestigationsForFraudOrIrregularitiesCheckPage Access_Section6_OngoingInvestigationsForFraudorIrregularities()
        {
            NavigateToTask(PeopleInControlsCriminalAndComplianceChecks, PeopleInControlsCriminalAndComplianceChecks_4);
            return new OngoingInvestigationsForFraudOrIrregularitiesCheckPage(_context);
        }
        public ContractTerminatedByPublicBodyCheckPage Access_Section6_ContractTerminateEarlyByPublicBody()
        {
            NavigateToTask(PeopleInControlsCriminalAndComplianceChecks, PeopleInControlsCriminalAndComplianceChecks_5);
            return new ContractTerminatedByPublicBodyCheckPage(_context);
        }
        public WithdrawnFromContractWithPublicBodyCheckPage Access_Section6_WithdrawnFromContractWithPublicBody()
        {
            NavigateToTask(PeopleInControlsCriminalAndComplianceChecks, PeopleInControlsCriminalAndComplianceChecks_6);
            return new WithdrawnFromContractWithPublicBodyCheckPage(_context);
        }
        public BreachedTaxPaymentsCheckPage Access_Section6_BreachedTaxPaymentsOrSocialSecurityPayments()
        {
            NavigateToTask(PeopleInControlsCriminalAndComplianceChecks, PeopleInControlsCriminalAndComplianceChecks_7);
            return new BreachedTaxPaymentsCheckPage(_context);
        }
        public RegisterOfRemovedTrusteesCheckPage Access_Section6_RegisterOfRemovedTrustees()
        {
            NavigateToTask(PeopleInControlsCriminalAndComplianceChecks, PeopleInControlsCriminalAndComplianceChecks_8);
            return new RegisterOfRemovedTrusteesCheckPage(_context);
        }
        public BeenMadeBankruptCheckPage Access_Section6_BeenMadeBankrupt()
        {
            NavigateToTask(PeopleInControlsCriminalAndComplianceChecks, PeopleInControlsCriminalAndComplianceChecks_9);
            return new BeenMadeBankruptCheckPage(_context);
        }
        #endregion

        #region Section-7 OverallGatewayOutcome
        public ConfirmGatewayOutcomePage Access_Section7_ConfirmGateWayOutcome()
        {
            formCompletionHelper.ClickLinkByText("Confirm gateway outcome");
            return new ConfirmGatewayOutcomePage(_context);
        }
        #endregion
    }
}