using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class AssessorEndtoEndStepsHelper
    {
        private readonly Assessor_Section1Helper _assessor_Section1Helper;
        private readonly Assessor_Section2Helper _assessor_Section2Helper;
        private readonly Assessor_Section3Helper _assessor_Section3Helper;

        public AssessorEndtoEndStepsHelper()
        {
            _assessor_Section1Helper = new Assessor_Section1Helper();
            _assessor_Section2Helper = new Assessor_Section2Helper();
            _assessor_Section3Helper = new Assessor_Section3Helper();
        }

        public ApplicationAssessmentOverviewPage CompleteAllSectionsWithPass(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            CompleteAssessorSection1Checks(applicationAssessmentOverviewPage);
            CompleteAssessorSection2Checks(applicationAssessmentOverviewPage);
            CompleteAssessorSection3Checks(applicationAssessmentOverviewPage);
            return applicationAssessmentOverviewPage;
        }

        public ApplicationAssessmentOverviewPage CompleteAssessorSection1Checks(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            applicationAssessmentOverviewPage = _assessor_Section1Helper.PassContinuityPlanForApprenticeshipTraining(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section1Helper.PassEqualityAndDiversityPolicy(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section1Helper.PassSafeguardingAndPreventDutyPolicy(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section1Helper.PassHealthAndSafetyPolicy(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section1Helper.PassActingAsASubcontractor(applicationAssessmentOverviewPage);
            return applicationAssessmentOverviewPage;
        }

        public ApplicationAssessmentOverviewPage CompleteAssessorSection2Checks(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            applicationAssessmentOverviewPage = _assessor_Section2Helper.PassEngagingWithEmployers(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section2Helper.PassComplaintsPolicy(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section2Helper.PassContractForServicesTemplate(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section2Helper.PassCommitmentStatementTemplate(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section2Helper.PassPriorLearningOfApprentices(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section2Helper.PassWorkingWithSubcontractors(applicationAssessmentOverviewPage);
            return applicationAssessmentOverviewPage;
        }

        public ApplicationAssessmentOverviewPage CompleteAssessorSection3Checks(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            applicationAssessmentOverviewPage = _assessor_Section3Helper.PassTypeOfApprenticeshipTraining(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section3Helper.CheckSupportingApprentices(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section3Helper.PassForecastingStarts(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section3Helper.PassOffTheJobTraining(applicationAssessmentOverviewPage);
            applicationAssessmentOverviewPage = _assessor_Section3Helper.PassWhereWillYourApprenticesBeTrained(applicationAssessmentOverviewPage);
            return applicationAssessmentOverviewPage;
        }
    }
}
