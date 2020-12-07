using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class AssessorEndtoEndStepsHelper
    {
        private readonly Assessor_Section1Helper _assessor_Section1Helper;
        private readonly Assessor_Section2Helper _assessor_Section2Helper;
        private readonly Assessor_Section3Helper _assessor_Section3Helper;
        private readonly Assessor_Section4Helper _assessor_Section4Helper;
        private readonly Assessor_Section5Helper _assessor_Section5Helper;

        public AssessorEndtoEndStepsHelper()
        {
            _assessor_Section1Helper = new Assessor_Section1Helper();
            _assessor_Section2Helper = new Assessor_Section2Helper();
            _assessor_Section3Helper = new Assessor_Section3Helper();
            _assessor_Section4Helper = new Assessor_Section4Helper();
            _assessor_Section5Helper = new Assessor_Section5Helper();
        }

        public ApplicationAssessmentOverviewPage CompleteAllSectionsWithPass(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            CompleteAssessorSection1Checks(applicationAssessmentOverviewPage, applicationroute);
            CompleteAssessorSection2Checks(applicationAssessmentOverviewPage, applicationroute);
            CompleteAssessorSection3Checks(applicationAssessmentOverviewPage, applicationroute);
            CompleteAssessorSection4Checks(applicationAssessmentOverviewPage, applicationroute);
            CompleteAssessorSection5Checks(applicationAssessmentOverviewPage, applicationroute);
            return applicationAssessmentOverviewPage;
        }

        public ApplicationAssessmentOverviewPage CompleteAssessorSection1Checks(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            applicationAssessmentOverviewPage = _assessor_Section1Helper.PassContinuityPlanForApprenticeshipTraining(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = _assessor_Section1Helper.PassEqualityAndDiversityPolicy(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section1Helper.PassSafeguardingAndPreventDutyPolicy(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section1Helper.PassHealthAndSafetyPolicy(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section1Helper.PassActingAsASubcontractor(applicationAssessmentOverviewPage);
            return applicationAssessmentOverviewPage;
        }

        public ApplicationAssessmentOverviewPage CompleteAssessorSection2Checks(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            applicationAssessmentOverviewPage = _assessor_Section2Helper.PassEngagingWithEmployers(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = _assessor_Section2Helper.PassComplaintsPolicy(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = _assessor_Section2Helper.PassContractForServicesTemplate(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = _assessor_Section2Helper.PassCommitmentStatementTemplate(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = _assessor_Section2Helper.PassPriorLearningOfApprentices(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = _assessor_Section2Helper.PassWorkingWithSubcontractors(applicationAssessmentOverviewPage, applicationroute);
            return applicationAssessmentOverviewPage;
        }

        public ApplicationAssessmentOverviewPage CompleteAssessorSection3Checks(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            applicationAssessmentOverviewPage = _assessor_Section3Helper.PassTypeOfApprenticeshipTraining(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = _assessor_Section3Helper.PassTrainingApprentices(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = _assessor_Section3Helper.PassSupportingApprentices(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = _assessor_Section3Helper.PassForecastingStarts(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = _assessor_Section3Helper.PassOffTheJobTraining(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = _assessor_Section3Helper.PassWhereWillYourApprenticesBeTrained(applicationAssessmentOverviewPage, applicationroute);
            return applicationAssessmentOverviewPage;
        }

        public ApplicationAssessmentOverviewPage CompleteAssessorSection4Checks(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            applicationAssessmentOverviewPage = _assessor_Section4Helper.PassOverallAccountabilityForApprenticeships(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section4Helper.PassManagementHierarchyForApprenticeships(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section4Helper.PassQualityAndHighStandardsInApprenticeshipTraining(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section4Helper.PassDevelopingAndDeliveringTraining(applicationAssessmentOverviewPage, applicationroute);
            applicationAssessmentOverviewPage = _assessor_Section4Helper.PassYourSectorsAndEmployees(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section4Helper.PassPolicyForProfessionalDevelopmentOfEmployees(applicationAssessmentOverviewPage);
            return applicationAssessmentOverviewPage;
        }

        public ApplicationAssessmentOverviewPage CompleteAssessorSection5Checks(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            applicationAssessmentOverviewPage = _assessor_Section5Helper.PassProcessForEvaluatingTheQualityOfTrainingDelivered(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section5Helper.PassProcessForEvaluatingTheQualityOfApprenticeshipTraining(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section5Helper.PassSystemsAndProcessesToCollectApprenticeshipData(applicationAssessmentOverviewPage, applicationroute);
            return applicationAssessmentOverviewPage;
        }

        public void MarkApplicationAsReadyForModeration(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            applicationAssessmentOverviewPage
                .Access_Section6_ReadyForModeration()
                .SelectYesAndContinueInAreYouSureThisApplicationIsReadyForModerationPage()
                .GoToRoATPAssessorApplicationsPage();
        }
    }
}
