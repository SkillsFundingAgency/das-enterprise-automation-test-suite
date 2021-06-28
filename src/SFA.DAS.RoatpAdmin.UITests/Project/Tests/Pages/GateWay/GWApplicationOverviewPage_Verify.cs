using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public partial class GWApplicationOverviewPage : RoatpGateWayBasePage
    {
        //Verify Sections

        #region Section1
        public GWApplicationOverviewPage Verify2ApplicationIn12Months_Section1(string status) => Verify_Section1(OrganisationChecks_1, status);
        public GWApplicationOverviewPage VerifyLegalName_Section1(string status) => Verify_Section1(OrganisationChecks_2, status);
        public GWApplicationOverviewPage VerifyTradingName_Section1(string status) => Verify_Section1(OrganisationChecks_3, status);
        public GWApplicationOverviewPage VerifyOrganisationStatus_Section1(string status) => Verify_Section1(OrganisationChecks_4, status);
        public GWApplicationOverviewPage VerifyAddress_Section1(string status) => Verify_Section1(OrganisationChecks_5, status);
        public GWApplicationOverviewPage VerifyICOregistrationnumber_Section1(string status) => Verify_Section1(OrganisationChecks_6, status);
        public GWApplicationOverviewPage VerifyWebsiteaddress_Section1(string status) => Verify_Section1(OrganisationChecks_7, status);
        public GWApplicationOverviewPage VerifyOrganisationhighrisk_Section1(string status) => Verify_Section1(OrganisationChecks_8, status);
        #endregion

        #region Section2
        public GWApplicationOverviewPage VerifyPeopleincontrol_Section2(string status) => Verify_Section2(PeopleInControlChecks_1, status);
        public GWApplicationOverviewPage VerifyPeopleincontrolhighrisk_Section2(string status) => Verify_Section2(PeopleInControlChecks_2, status);
        #endregion

        #region Section3
        public GWApplicationOverviewPage VerifyRoATP_Section3(string status) => Verify_Section3(RegisterChecks_1, status);
        public GWApplicationOverviewPage VerifyRegisterofendpointassessmentorganisations_Section3(string status) => Verify_Section3(RegisterChecks_2, status);
        #endregion

        #region Section4
        public GWApplicationOverviewPage VerifyOfficeforStudent_OFS_Section4(string status) => Verify_Section4(ExperienceAndAccreditationChecks_1, status);
        public GWApplicationOverviewPage VerifyInitialteachertraining_ITT_Section4(string status) => Verify_Section4(ExperienceAndAccreditationChecks_2, status);
        public GWApplicationOverviewPage VerifyOfsted_Section4(string status) => Verify_Section4(ExperienceAndAccreditationChecks_3, status);
        public GWApplicationOverviewPage VerifySubcontractordeclaration_Section4(string status) => Verify_Section4(ExperienceAndAccreditationChecks_4, status);
        #endregion

        #region Section5
        public GWApplicationOverviewPage VerifyCompositionwithcreditors_Section5(string status) => Verify_Section5(OrganisationsCriminalAndComplianceChecks_1, status);
        public GWApplicationOverviewPage VerifyFailedtopaybackfunds_Section5(string status) => Verify_Section5(OrganisationsCriminalAndComplianceChecks_2, status);
        public GWApplicationOverviewPage VerifyContractterminatedearlybyapublicbody_Section5(string status) => Verify_Section5(OrganisationsCriminalAndComplianceChecks_3, status);
        public GWApplicationOverviewPage VerifyWithdrawnfromacontractwithapublicbody_Section5(string status) => Verify_Section5(OrganisationsCriminalAndComplianceChecks_4, status);
        public GWApplicationOverviewPage VerifyRegisterofTrainingOrganisations_RoTO_Section5(string status) => Verify_Section5(OrganisationsCriminalAndComplianceChecks_5, status);
        public GWApplicationOverviewPage VerifyFundingremovedfromanyeducationbodies_Section5(string status) => Verify_Section5(OrganisationsCriminalAndComplianceChecks_6, status);
        public GWApplicationOverviewPage VerifyRemovedfromanyprofessionalortraderegisters_Section5(string status) => Verify_Section5(OrganisationsCriminalAndComplianceChecks_7, status);
        public GWApplicationOverviewPage VerifyInitialTeacherTrainingaccreditation_Section5(string status) => Verify_Section5(OrganisationsCriminalAndComplianceChecks_8, status);
        public GWApplicationOverviewPage VerifyRemovedfromanycharityregister_Section5(string status) => Verify_Section5(OrganisationsCriminalAndComplianceChecks_9, status);
        public GWApplicationOverviewPage VerifyInvestigatedduetosafeguardingissues_Section5(string status) => Verify_Section5(OrganisationsCriminalAndComplianceChecks_10, status);
        public GWApplicationOverviewPage VerifyInvestigatedduetowhistleblowingissues_Section5(string status) => Verify_Section5(OrganisationsCriminalAndComplianceChecks_11, status);
        public GWApplicationOverviewPage VerifyInsolvencyorwindingupproceedings_Section5(string status) => Verify_Section5(OrganisationsCriminalAndComplianceChecks_12, status);
        #endregion

        #region Section6
        public GWApplicationOverviewPage VerifyUnspentcriminalconvictions_Section6(string status) => Verify_Section6(PeopleInControlsCriminalAndComplianceChecks_1, status);
        public GWApplicationOverviewPage VerifyFailedtopaybackfunds_Section6(string status) => Verify_Section6(PeopleInControlsCriminalAndComplianceChecks_2, status);
        public GWApplicationOverviewPage VerifyInvestigatedforfraudorirregularities_Section6(string status) => Verify_Section6(PeopleInControlsCriminalAndComplianceChecks_3, status);
        public GWApplicationOverviewPage VerifyOngoinginvestigationsforfraudorirregularities_Section6(string status) => Verify_Section6(PeopleInControlsCriminalAndComplianceChecks_4, status);
        public GWApplicationOverviewPage VerifyContractterminatedearlybyapublicbody_Section6(string status) => Verify_Section6(PeopleInControlsCriminalAndComplianceChecks_5, status);
        public GWApplicationOverviewPage VerifyWithdrawnfromacontractwithapublicbody_Section6(string status) => Verify_Section6(PeopleInControlsCriminalAndComplianceChecks_6, status);
        public GWApplicationOverviewPage VerifyBreachedtaxpaymentsorsocialsecuritycontributions_Section6(string status) => Verify_Section6(PeopleInControlsCriminalAndComplianceChecks_7, status);
        public GWApplicationOverviewPage VerifyRegisterofRemovedTrustees_Section6(string status) => Verify_Section6(PeopleInControlsCriminalAndComplianceChecks_8, status);
        public GWApplicationOverviewPage VerifyBeenmadebankrupt_Section6(string status) => Verify_Section6(PeopleInControlsCriminalAndComplianceChecks_9, status);
        public GWApplicationOverviewPage VerifyProhibitionOrder_Section6(string status) => Verify_Section6(PeopleInControlsCriminalAndComplianceChecks_10, status);
        public GWApplicationOverviewPage VerifyBanFromManagement_Section6(string status) => Verify_Section6(PeopleInControlsCriminalAndComplianceChecks_11, status);
        #endregion

        #region Section7
        public GWApplicationOverviewPage VerifyConfirmgatewayoutcome_Section7(string status) => Verify_Section7(OverallGatewayOutcome_1, status);
        #endregion

        private GWApplicationOverviewPage Verify_Section1(string taskName, string status) => VerifySections(OrganisationChecks, taskName, status);
        private GWApplicationOverviewPage Verify_Section2(string taskName, string status) => VerifySections(PeopleInControlChecks, taskName, status);
        private GWApplicationOverviewPage Verify_Section3(string taskName, string status) => VerifySections(RegisterChecks, taskName, status);
        private GWApplicationOverviewPage Verify_Section4(string taskName, string status) => VerifySections(ExperienceAndAccreditationChecks, taskName, status);
        private GWApplicationOverviewPage Verify_Section5(string taskName, string status) => VerifySections(OrganisationsCriminalAndComplianceChecks, taskName, status);
        private GWApplicationOverviewPage Verify_Section6(string taskName, string status) => VerifySections(PeopleInControlsCriminalAndComplianceChecks, taskName, status);
        private GWApplicationOverviewPage Verify_Section7(string taskName, string status) => VerifySections(OverallGatewayOutcome, taskName, status);

        private GWApplicationOverviewPage VerifySections(string sectionName, string taskName, string status, int index = 0)
        {
            VerifyElement(GetTaskStatusElement(sectionName, taskName, index), status, (null));
            return new GWApplicationOverviewPage(_context);
        }
    }
}