using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public partial class ApplicationOverviewPage : RoatpBasePage
    {
        //Verify Sections 

        #region Section9
        public ApplicationOverviewPage VerifyApplicationPermissions_Section9(string status) => Verify_Section9(Finish_1, status);
        public ApplicationOverviewPage VerifyQualityStatement_Section9(string status) => Verify_Section9(Finish_2, status);
        public ApplicationOverviewPage VerifyTermsAndConditions_Section9(string status) => Verify_Section9(Finish_3, status);
        #endregion

        #region Section8
        public ApplicationOverviewPage VerifyIntroductionStatus_Section8(string status) => Verify_Section8(EvaluatingApprenticeshipTraining_1, status);
        public ApplicationOverviewPage VerifyQualityOfTheTrainingDeleivered_Section8(string status) => Verify_Section8(EvaluatingApprenticeshipTraining_2, status);
        public ApplicationOverviewPage VerifyQualityOfTheTraining_Section8(string status) => Verify_Section8(EvaluatingApprenticeshipTraining_3, status);
        public ApplicationOverviewPage VerifySystemsAndProcesses_Section8(string status) => Verify_Section8(EvaluatingApprenticeshipTraining_4, status);
        #endregion

        #region Section7
        public ApplicationOverviewPage VerifyIntroductionStatus_Section7(string status) => Verify_Section7(DeliveringApprenticeshipTraining_1, status);
        public ApplicationOverviewPage VerifyOverallAccountability_Section7(string status) => Verify_Section7(DeliveringApprenticeshipTraining_2, status);
        public ApplicationOverviewPage VerifyManagementHierarchy_Section7(string status) => Verify_Section7(DeliveringApprenticeshipTraining_3, status);
        public ApplicationOverviewPage VerifyQualityAndHighStandards_Section7(string status) => Verify_Section7(DeliveringApprenticeshipTraining_4, status);
        public ApplicationOverviewPage VerifyDevelopingAndDelivering_Section7(string status) => Verify_Section7(DeliveringApprenticeshipTraining_5, status);
        public ApplicationOverviewPage VerifyYourSectorsAndEmployees_Section7(string status) => Verify_Section7(DeliveringApprenticeshipTraining_6, status);
        public ApplicationOverviewPage VerifyPolicyForProfessionalDevelopment_Section7(string status) => Verify_Section7(DeliveringApprenticeshipTraining_7, status);
        #endregion

        #region Section6
        public ApplicationOverviewPage VerifyIntroductionStatus_Section6(string status) => Verify_Section6(PlanningApprenticeshipTraining_1, status);
        public ApplicationOverviewPage VerifyTypeOfTrainning_Section6(string status) => Verify_Section6(PlanningApprenticeshipTraining_2, status);
        public ApplicationOverviewPage VerifySupporting_Section6(string status) => Verify_Section6(PlanningApprenticeshipTraining_3, status);
        public ApplicationOverviewPage VerifyForecasting_Section6(string status) => Verify_Section6(PlanningApprenticeshipTraining_4, status);
        public ApplicationOverviewPage VerifyOffTheJobTrainning_Section6(string status) => Verify_Section6(PlanningApprenticeshipTraining_5, status);
        public ApplicationOverviewPage VerifyWhereWillYourApprenticesBeTrained_Section6(string status) => Verify_Section6(PlanningApprenticeshipTraining_6, status);
        #endregion

        #region Section5
        public ApplicationOverviewPage VerifyIntroductionStatus_Section5(string status) => Verify_Section5(ReadinessToEngage_1, status);
        public ApplicationOverviewPage VerifyEngaging_Section5(string status) => Verify_Section5(ReadinessToEngage_2, status);
        public ApplicationOverviewPage VerifyComplaints_Section5(string status) => Verify_Section5(ReadinessToEngage_3, status);
        public ApplicationOverviewPage VerifyContract_Section5(string status) => Verify_Section5(ReadinessToEngage_4, status);
        public ApplicationOverviewPage VerifyCommitment_Section5(string status) => Verify_Section5(ReadinessToEngage_5, status);
        public ApplicationOverviewPage VerifyPriorLearning_Section5(string status) => Verify_Section5(ReadinessToEngage_6, status);
        public ApplicationOverviewPage VerifyWorkingWithSubcontractors_Section5(string status) => Verify_Section5(ReadinessToEngage_7, status);
        #endregion

        #region Section4
        public ApplicationOverviewPage VerifyIntroductionStatus_Section4(string status) => Verify_Section4(ProtectingYourApprentices_1, status);
        public ApplicationOverviewPage VerifyContinuity_Section4(string status) => Verify_Section4(ProtectingYourApprentices_2, status);
        public ApplicationOverviewPage VerifyEquality_Section4(string status) => Verify_Section4(ProtectingYourApprentices_3, status);
        public ApplicationOverviewPage VerifySafeguarding_Section4(string status) => Verify_Section4(ProtectingYourApprentices_4, status);
        public ApplicationOverviewPage VerifyHealthAndSafety_Section4(string status) => Verify_Section4(ProtectingYourApprentices_5, status);
        public ApplicationOverviewPage VerifyActingAsASubContractor(string status) => Verify_Section4(ProtectingYourApprentices_6, status);
        #endregion

        #region Section3
        public ApplicationOverviewPage VerifyIntroductionStatus_Section3(string status) => Verify_Section3(CriminalAndComplianceChecks_1, status);
        public ApplicationOverviewPage VerifyChecksOnYourOrganisations_Section3(string status) => Verify_Section3(CriminalAndComplianceChecks_2, status);
        public ApplicationOverviewPage VerifyIntroductionStatusControl_Section3(string status) => Verify_Section3(CriminalAndComplianceChecks_3, status);
        public ApplicationOverviewPage VerifyCheckWhoIsInControl_Section3(string status) => Verify_Section3(CriminalAndComplianceChecks_4, status);
        #endregion

        #region Section2
        public ApplicationOverviewPage VerifyIntroductionStatus_Section2(string status) => Verify_Section2(FinancialEvidence_1, status);
        public ApplicationOverviewPage VerifyYourOrganisationsFinancialEvidence_Section2(string status) => Verify_Section2(FinancialEvidence_2, status);
        public ApplicationOverviewPage VerifyYourUkUltimateParentCompany_Section3(string status) => Verify_Section2(FinancialEvidence_3, status);
        #endregion

        #region Section1
        public ApplicationOverviewPage VerifyIntroductionStatus(string status) => Verify_Section1(YourOrganisation_1, status);
        public ApplicationOverviewPage VerifyOrganisationInformation(string status) => Verify_Section1(YourOrganisation_2, status);
        public ApplicationOverviewPage VerifyTellUsWhosInControlStatus(string status) => Verify_Section1(YourOrganisation_3, status);
        public ApplicationOverviewPage VerifyDescribeYourOrganisationStatus(string status) => Verify_Section1(YourOrganisation_4, status);
        public ApplicationOverviewPage VerifyExperienceAndAccreditationsStatus(string status) => Verify_Section1(YourOrganisation_5, status);
        #endregion

        private ApplicationOverviewPage Verify_Section9(string taskName, string status) => VerifySections(Finish, taskName, status);
        private ApplicationOverviewPage Verify_Section8(string taskName, string status) => VerifySections(EvaluatingApprenticeshipTraining, taskName, status);
        private ApplicationOverviewPage Verify_Section7(string taskName, string status) => VerifySections(DeliveringApprenticeshipTraining, taskName, status);
        private ApplicationOverviewPage Verify_Section6(string taskName, string status) => VerifySections(PlanningApprenticeshipTraining, taskName, status);
        private ApplicationOverviewPage Verify_Section5(string taskName, string status) => VerifySections(ReadinessToEngage, taskName, status);
        private ApplicationOverviewPage Verify_Section4(string taskName, string status) => VerifySections(ProtectingYourApprentices, taskName, status);
        private ApplicationOverviewPage Verify_Section3(string taskName, string status) => VerifySections(CriminalAndComplianceChecks, taskName, status);
        private ApplicationOverviewPage Verify_Section2(string taskName, string status) => VerifySections(FinancialEvidence, taskName, status);
        private ApplicationOverviewPage Verify_Section1(string taskName, string status) => VerifySections(Yourorganisation, taskName, status);

        private ApplicationOverviewPage VerifySections(string sectionName, string taskName, string status)
        {
            VerifyElement(GetTaskStatusElement(sectionName, taskName), status);
            return new ApplicationOverviewPage(_context);
        }
    }
}
