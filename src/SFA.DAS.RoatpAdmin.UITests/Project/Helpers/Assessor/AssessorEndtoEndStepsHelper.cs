using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class AssessorEndtoEndStepsHelper()
    {
        public ApplicationAssessmentOverviewPage CompleteAllSectionsWithPass(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            CompleteAssessorSection1Checks(applicationAssessmentOverviewPage, applicationroute);
            CompleteAssessorSection2Checks(applicationAssessmentOverviewPage, applicationroute);
            CompleteAssessorSection3Checks(applicationAssessmentOverviewPage, applicationroute);
            CompleteAssessorSection4Checks(applicationAssessmentOverviewPage, applicationroute);
            CompleteAssessorSection5Checks(applicationAssessmentOverviewPage, applicationroute);
            return applicationAssessmentOverviewPage;
        }

        public static ApplicationAssessmentOverviewPage CompleteAssessorSection1Checks(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            applicationAssessmentOverviewPage = Assessor_Section1Helper.PassContinuityPlanForApprenticeshipTraining(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = Assessor_Section1Helper.PassEqualityAndDiversityPolicy(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = Assessor_Section1Helper.PassSafeguardingAndPreventDutyPolicy(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = Assessor_Section1Helper.PassHealthAndSafetyPolicy(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = Assessor_Section1Helper.PassActingAsASubcontractor(applicationAssessmentOverviewPage);
            return applicationAssessmentOverviewPage;
        }

        public static ApplicationAssessmentOverviewPage CompleteAssessorSection2Checks(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            applicationAssessmentOverviewPage = Assessor_Section2Helper.PassEngagingWithEmployers(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = Assessor_Section2Helper.PassComplaintsPolicy(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = Assessor_Section2Helper.PassContractForServicesTemplate(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = Assessor_Section2Helper.PassCommitmentStatementTemplate(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = Assessor_Section2Helper.PassPriorLearningOfApprentices(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = Assessor_Section2Helper.PassEnglishAndMathsAssessment(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = Assessor_Section2Helper.PassWorkingWithSubcontractors(applicationAssessmentOverviewPage, applicationroute);
            return applicationAssessmentOverviewPage;
        }

        public static ApplicationAssessmentOverviewPage CompleteAssessorSection3Checks(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            applicationAssessmentOverviewPage = Assessor_Section3Helper.PassTypeOfApprenticeshipTraining(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = Assessor_Section3Helper.PassTrainingApprentices(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = Assessor_Section3Helper.PassSupportingApprentices(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = Assessor_Section3Helper.PassForecastingStarts(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = Assessor_Section3Helper.PassOffTheJobTraining(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = Assessor_Section3Helper.PassWhereWillYourApprenticesBeTrained(applicationAssessmentOverviewPage, applicationroute);
            return applicationAssessmentOverviewPage;
        }

        public static ApplicationAssessmentOverviewPage CompleteAssessorSection4Checks(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            applicationAssessmentOverviewPage = Assessor_Section4Helper.PassOverallAccountabilityForApprenticeships(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = Assessor_Section4Helper.PassManagementHierarchyForApprenticeships(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = Assessor_Section4Helper.PassQualityAndHighStandardsInApprenticeshipTraining(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = Assessor_Section4Helper.PassDevelopingAndDeliveringTraining(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = Assessor_Section4Helper.PassYourSectorsAndEmployees(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = Assessor_Section4Helper.PassPolicyForProfessionalDevelopmentOfEmployees(applicationAssessmentOverviewPage);
            return applicationAssessmentOverviewPage;
        }

        public static ApplicationAssessmentOverviewPage CompleteAssessorSection5Checks(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            applicationAssessmentOverviewPage = Assessor_Section5Helper.PassProcessForEvaluatingTheQualityOfTrainingDelivered(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = Assessor_Section5Helper.PassProcessForEvaluatingTheQualityOfApprenticeshipTraining(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = Assessor_Section5Helper.PassSystemsAndProcessesToCollectApprenticeshipData(applicationAssessmentOverviewPage, applicationroute);
            return applicationAssessmentOverviewPage;
        }

        public static void MarkApplicationAsReadyForModeration(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            applicationAssessmentOverviewPage
                .Access_Section6_ReadyForModeration()
                .SelectYesAndContinueInAreYouSureThisApplicationIsReadyForModerationPage()
                .GoToRoATPAssessorApplicationsPage();
        }
    }
}
