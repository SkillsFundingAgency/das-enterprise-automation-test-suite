using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class AssessorEndtoEndStepsHelper
    {
        private readonly Assessor_Section1Helper _assessor_Section1Helper;

        public AssessorEndtoEndStepsHelper()
        {
            _assessor_Section1Helper = new Assessor_Section1Helper();
        }

        public ApplicationAssessmentOverviewPage CompleteAllSectionsWithPass(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            CompleteAssessorSection1Checks(applicationAssessmentOverviewPage);
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
    }
}
