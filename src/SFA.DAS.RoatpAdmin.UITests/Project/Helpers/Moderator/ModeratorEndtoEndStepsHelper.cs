using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Clarification;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class ModeratorEndtoEndStepsHelper
    {
        protected readonly Moderator_Section1Helper _section1Helper;
        protected readonly Moderator_Section2Helper _section2Helper;
        protected readonly Moderator_Section3Helper _section3Helper;
        protected readonly Moderator_Section4Helper _section4Helper;
        protected readonly Moderator_Section5Helper _section5Helper;

        public ModeratorEndtoEndStepsHelper()
        {
            _section1Helper = new Moderator_Section1Helper();
            _section2Helper = new Moderator_Section2Helper();
            _section3Helper = new Moderator_Section3Helper();
            _section4Helper = new Moderator_Section4Helper();
            _section5Helper = new Moderator_Section5Helper();
        }

        public ModeratorEndtoEndStepsHelper(
            Clarification_Section1Helper moderator_Section1Helper,
            Clarification_Section2Helper moderator_Section2Helper,
            Clarification_Section3Helper moderator_Section3Helper,
            Clarification_Section4Helper moderator_Section4Helper,
            Clarification_Section5Helper moderator_Section5Helper)
        {
            _section1Helper = moderator_Section1Helper;
            _section2Helper = moderator_Section2Helper;
            _section3Helper = moderator_Section3Helper;
            _section4Helper = moderator_Section4Helper;
            _section5Helper = moderator_Section5Helper;
        }

        public ModerationApplicationAssessmentOverviewPage VerifySubSectionsAsPass(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = _section1Helper.VerifySubSectionsAsPass(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section2Helper.VerifySubSectionsAsPass(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section3Helper.VerifySubSectionsAsPass(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section4Helper.VerifySubSectionsAsPass(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section5Helper.VerifySubSectionsAsPass(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage VerifySubSectionsAsFail(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = _section1Helper.VerifySubSectionsAsFail(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section2Helper.VerifySubSectionsAsFail(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section4Helper.VerifySubSectionsAsFail(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
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
            moderationApplicationAssessmentOverviewPage = _section1Helper.PassContinuityPlanForApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section1Helper.PassEqualityAndDiversityPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _section1Helper.PassSafeguardingAndPreventDutyPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _section1Helper.PassHealthAndSafetyPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _section1Helper.PassActingAsASubcontractor(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage FailWorkingWithSubcontractors(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return _section1Helper.FailWorkingWithSubcontractors(moderationApplicationAssessmentOverviewPage);
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection2Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = _section2Helper.PassEngagingWithEmployers(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section2Helper.PassComplaintsPolicy(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section2Helper.PassContractForServicesTemplate(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section2Helper.PassCommitmentStatementTemplate(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section2Helper.PassPriorLearningOfApprentices(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section2Helper.PassWorkingWithSubcontractors(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection3Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = _section3Helper.PassTypeOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section3Helper.PassSupportingApprentices(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section3Helper.PassForecastingStarts(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section3Helper.PassOffTheJobTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section3Helper.PassWhereWillYourApprenticesBeTrained(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage FailTypeOfApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            return _section3Helper.FailTypeOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection4Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = _section4Helper.PassOverallAccountabilityForApprenticeships(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _section4Helper.PassManagementHierarchyForApprenticeships(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _section4Helper.PassQualityAndHighStandardsInApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _section4Helper.PassDevelopingAndDeliveringTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section4Helper.PassYourSectorsAndEmployees(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _section4Helper.PassPolicyForProfessionalDevelopmentOfEmployees(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage FailYourSectorsAndEmployees(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return _section4Helper.FailYourSectorsAndEmployees(moderationApplicationAssessmentOverviewPage);
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection5Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = _section5Helper.PassProcessForEvaluatingTheQualityOfTrainingDelivered(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _section5Helper.PassProcessForEvaluatingTheQualityOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _section5Helper.PassSystemsAndProcessesToCollectApprenticeshipData(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
        }

        public RoatpAssessorApplicationsHomePage CompleteModeratorOutcomeSectionAsPass(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section6_ReadyForModeration()
                .SelectPassAndContinueAreYouSurePage()
                .SelectYesPassAndContinueOutcomePage()
                .GoToRoATPAssessorApplicationsPage();
        }

        public RoatpAssessorApplicationsHomePage CompleteModeratorOutcomeSectionAsFail(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section6_ReadyForModeration()
                .SelectFailAndContinueAreYouSurePage()
                .SelectYesFailAndContinueOutcomePage()
                .GoToRoATPAssessorApplicationsPage();
        }

        public RoatpAssessorApplicationsHomePage CompleteModeratorOutcomeSectionAsAskClarification(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section6_ReadyForModeration()
                .SelectAskForClarificationAndContinueAreYouSurePage()
                .SelectYesAskAndContinueOutcomePage()
                .GoToRoATPAssessorApplicationsPage();
        }
    }
}
