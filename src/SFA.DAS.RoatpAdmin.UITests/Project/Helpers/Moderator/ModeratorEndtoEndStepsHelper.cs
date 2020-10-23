using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class ModeratorEndtoEndStepsHelper
    {
        private readonly Moderator_Section1Helper _moderator_Section1Helper;
        private readonly Moderator_Section2Helper _moderator_Section2Helper;
        private readonly Moderator_Section3Helper _moderator_Section3Helper;
        private readonly Moderator_Section4Helper _moderator_Section4Helper;
        private readonly Moderator_Section5Helper _moderator_Section5Helper;

        public ModeratorEndtoEndStepsHelper(ScenarioContext context)
        {
            _moderator_Section1Helper = new Moderator_Section1Helper(context);
            _moderator_Section2Helper = new Moderator_Section2Helper(context);
            _moderator_Section3Helper = new Moderator_Section3Helper(context);
            _moderator_Section4Helper = new Moderator_Section4Helper(context);
            _moderator_Section5Helper = new Moderator_Section5Helper(context);
        }

        public ModerationApplicationAssessmentOverviewPage CompleteAllSectionsWithPass(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage = CompleteModeratorSection1Checks(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = CompleteModeratorSection2Checks(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = CompleteModeratorSection3Checks(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = CompleteModeratorSection4Checks(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = CompleteModeratorSection5Checks(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection1Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage = _moderator_Section1Helper.PassContinuityPlanForApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section1Helper.PassEqualityAndDiversityPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section1Helper.PassSafeguardingAndPreventDutyPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section1Helper.PassHealthAndSafetyPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section1Helper.PassActingAsASubcontractor(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection2Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassEngagingWithEmployers(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassComplaintsPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassContractForServicesTemplate(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassCommitmentStatementTemplate(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassPriorLearningOfApprentices(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassWorkingWithSubcontractors(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection3Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassTypeOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassSupportingApprentices(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassForecastingStarts(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassOffTheJobTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassWhereWillYourApprenticesBeTrained(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection4Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassOverallAccountabilityForApprenticeships(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassManagementHierarchyForApprenticeships(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassQualityAndHighStandardsInApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassDevelopingAndDeliveringTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassYourSectorsAndEmployees(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassPolicyForProfessionalDevelopmentOfEmployees(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection5Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage = _moderator_Section5Helper.PassProcessForEvaluatingTheQualityOfTrainingDelivered(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section5Helper.PassProcessForEvaluatingTheQualityOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section5Helper.PassSystemsAndProcessesToCollectApprenticeshipData(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }

        public void ModerationApplicationAssessmentOverviewPage(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage
                .Access_Section6_ReadyForModeration()
                .SelectYesAndContinueInAreYouSureThisApplicationIsReadyForModerationPage()
                .GoToRoATPAssessorApplicationsPage();
        }
    }
}
