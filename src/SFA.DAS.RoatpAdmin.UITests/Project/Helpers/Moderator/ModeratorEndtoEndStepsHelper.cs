using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class ModeratorEndtoEndStepsHelper
    {
        private readonly Moderator_Section1Helper _moderator_Section1Helper;
        private readonly Moderator_Section2Helper _moderator_Section2Helper;
        private readonly Moderator_Section3Helper _moderator_Section3Helper;
        private readonly Moderator_Section4Helper _moderator_Section4Helper;
        private readonly Moderator_Section5Helper _moderator_Section5Helper;

        public ModeratorEndtoEndStepsHelper()
        {
            _moderator_Section1Helper = new Moderator_Section1Helper();
            _moderator_Section2Helper = new Moderator_Section2Helper();
            _moderator_Section3Helper = new Moderator_Section3Helper();
            _moderator_Section4Helper = new Moderator_Section4Helper();
            _moderator_Section5Helper = new Moderator_Section5Helper();
        }

        public ModerationApplicationAssessmentOverviewPage CompleteAllSectionsWithPass(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = CompleteModeratorSection1Checks(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = CompleteModeratorSection2Checks(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = CompleteModeratorSection3Checks(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = CompleteModeratorSection4Checks(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = CompleteModeratorSection5Checks(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection1Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = _moderator_Section1Helper.PassContinuityPlanForApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _moderator_Section1Helper.PassEqualityAndDiversityPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section1Helper.PassSafeguardingAndPreventDutyPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section1Helper.PassHealthAndSafetyPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section1Helper.PassActingAsASubcontractor(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }
        public ModerationApplicationAssessmentOverviewPage FailWorkingWithSubcontractors(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return _moderator_Section1Helper.FailWorkingWithSubcontractors(moderationApplicationAssessmentOverviewPage);
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection2Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassEngagingWithEmployers(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassComplaintsPolicy(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassContractForServicesTemplate(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassCommitmentStatementTemplate(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassPriorLearningOfApprentices(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassWorkingWithSubcontractors(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection3Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassTypeOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassSupportingApprentices(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassForecastingStarts(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassOffTheJobTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassWhereWillYourApprenticesBeTrained(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage FailTypeOfApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            return _moderator_Section3Helper.FailTypeOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection4Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassOverallAccountabilityForApprenticeships(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassManagementHierarchyForApprenticeships(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassQualityAndHighStandardsInApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassDevelopingAndDeliveringTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassYourSectorsAndEmployees(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassPolicyForProfessionalDevelopmentOfEmployees(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage FailYourSectorsAndEmployees(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return _moderator_Section4Helper.FailYourSectorsAndEmployees(moderationApplicationAssessmentOverviewPage);
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection5Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = _moderator_Section5Helper.PassProcessForEvaluatingTheQualityOfTrainingDelivered(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section5Helper.PassProcessForEvaluatingTheQualityOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _moderator_Section5Helper.PassSystemsAndProcessesToCollectApprenticeshipData(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationsPage CompleteModeratorOutcomeSectionAsPass(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section6_ReadyForModeration()
                .SelectPassAndContinueAreYouSurePage()
                .SelectYesPassAndContinueOutcomePage()
                .GoToRoATPAssessorApplicationsPage();
        }

        public ModerationApplicationsPage CompleteModeratorOutcomeSectionAsFail(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section6_ReadyForModeration()
                .SelectFailAndContinueAreYouSurePage()
                .SelectYesFailAndContinueOutcomePage()
                .GoToRoATPAssessorApplicationsPage();
        }

        public ModerationApplicationsPage CompleteModeratorOutcomeSectionAsAskClarification(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section6_ReadyForModeration()
                .SelectAskForClarificationAndContinueAreYouSurePage()
                .SelectYesAskAndContinueOutcomePage()
                .GoToRoATPAssessorApplicationsPage();
        }
    }
}
