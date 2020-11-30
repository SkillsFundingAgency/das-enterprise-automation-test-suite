using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Clarification;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class ModeratorEndtoEndStepsHelper
    {
        protected readonly Moderator_Section1Helper section1Helper;
        protected readonly Moderator_Section2Helper section2Helper;
        protected readonly Moderator_Section3Helper section3Helper;
        protected readonly Moderator_Section4Helper section4Helper;
        protected readonly Moderator_Section5Helper section5Helper;

        public ModeratorEndtoEndStepsHelper()
        {
            section1Helper = new Moderator_Section1Helper();
            section2Helper = new Moderator_Section2Helper();
            section3Helper = new Moderator_Section3Helper();
            section4Helper = new Moderator_Section4Helper();
            section5Helper = new Moderator_Section5Helper();
        }

        public ModeratorEndtoEndStepsHelper(
            Clarification_Section1Helper moderator_Section1Helper,
            Clarification_Section2Helper moderator_Section2Helper,
            Clarification_Section3Helper moderator_Section3Helper,
            Clarification_Section4Helper moderator_Section4Helper,
            Clarification_Section5Helper moderator_Section5Helper)
        {
            section1Helper = moderator_Section1Helper;
            section2Helper = moderator_Section2Helper;
            section3Helper = moderator_Section3Helper;
            section4Helper = moderator_Section4Helper;
            section5Helper = moderator_Section5Helper;
        }

        public ModerationApplicationAssessmentOverviewPage VerifySubSectionsAsPass(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = section1Helper.VerifySubSectionsAsPass(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section2Helper.VerifySubSectionsAsPass(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section3Helper.VerifySubSectionsAsPass(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section4Helper.VerifySubSectionsAsPass(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section5Helper.VerifySubSectionsAsPass(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage VerifySubSectionsAsFail(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage = section1Helper.VerifySubSectionsAsFail(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section2Helper.VerifySubSectionsAsFail(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section4Helper.VerifySubSectionsAsFail(moderationApplicationAssessmentOverviewPage);
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


        public ModerationApplicationAssessmentOverviewPage CompleteAllSectionsWithFail(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = FailModeratorSection1Checks(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = FailModeratorSection2Checks(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = FailModeratorSection3Checks(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = FailModeratorSection4Checks(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = FailModeratorSection5Checks(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage CompleteSomeSectionsWithFail(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = section1Helper.FailSafeguardingAndPreventDutyPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section2Helper.FailCommitmentStatementTemplate(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section2Helper.FailWorkingWithSubcontractors(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section3Helper.FailWhereWillYourApprenticesBeTrained(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section4Helper.FailQualityAndHighStandardsInApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section4Helper.FailPolicyForProfessionalDevelopmentOfEmployees(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }


        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection1Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = section1Helper.PassContinuityPlanForApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section1Helper.PassEqualityAndDiversityPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section1Helper.PassSafeguardingAndPreventDutyPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section1Helper.PassHealthAndSafetyPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section1Helper.PassActingAsASubcontractor(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage FailModeratorSection1Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = section1Helper.FailContinuityPlanForApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section1Helper.FailEqualityAndDiversityPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section1Helper.FailSafeguardingAndPreventDutyPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section1Helper.FailHealthAndSafetyPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section1Helper.FailActingAsASubcontractor(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }


        public ModerationApplicationAssessmentOverviewPage FailWorkingWithSubcontractors(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return section1Helper.FailWorkingWithSubcontractors(moderationApplicationAssessmentOverviewPage);
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection2Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = section2Helper.PassEngagingWithEmployers(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section2Helper.PassComplaintsPolicy(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section2Helper.PassContractForServicesTemplate(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section2Helper.PassCommitmentStatementTemplate(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section2Helper.PassPriorLearningOfApprentices(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section2Helper.PassWorkingWithSubcontractors(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage FailModeratorSection2Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = section2Helper.FailEngagingWithEmployers(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section2Helper.FailComplaintsPolicy(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section2Helper.FailContractForServicesTemplate(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section2Helper.FailCommitmentStatementTemplate(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section2Helper.FailPriorLearningOfApprentices(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section2Helper.FailAllWorkingWithSubcontractors(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection3Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = section3Helper.PassTypeOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section3Helper.PassTrainingApprentices(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section3Helper.PassSupportingApprentices(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section3Helper.PassForecastingStarts(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section3Helper.PassOffTheJobTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section3Helper.PassWhereWillYourApprenticesBeTrained(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage FailModeratorSection3Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = section3Helper.FailAllTypeOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section3Helper.FailTrainingApprentices(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section3Helper.FailSupportingApprentices(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section3Helper.FailForecastingStarts(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section3Helper.FailOffTheJobTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section3Helper.FailWhereWillYourApprenticesBeTrained(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage FailTypeOfApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            return section3Helper.FailTypeOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection4Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = section4Helper.PassOverallAccountabilityForApprenticeships(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section4Helper.PassManagementHierarchyForApprenticeships(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section4Helper.PassQualityAndHighStandardsInApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section4Helper.PassDevelopingAndDeliveringTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section4Helper.PassYourSectorsAndEmployees(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section4Helper.PassPolicyForProfessionalDevelopmentOfEmployees(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage FailModeratorSection4Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = section4Helper.FailOverallAccountabilityForApprenticeships(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section4Helper.FailManagementHierarchyForApprenticeships(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section4Helper.FailAllQualityAndHighStandardsInApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section4Helper.FailDevelopingAndDeliveringTraining(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = section4Helper.FailYourSectorsAndEmployees(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section4Helper.FailAllPolicyForProfessionalDevelopmentOfEmployees(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage FailYourSectorsAndEmployees(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return section4Helper.FailYourSectorsAndEmployees(moderationApplicationAssessmentOverviewPage);
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection5Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = section5Helper.PassProcessForEvaluatingTheQualityOfTrainingDelivered(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section5Helper.PassProcessForEvaluatingTheQualityOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section5Helper.PassSystemsAndProcessesToCollectApprenticeshipData(moderationApplicationAssessmentOverviewPage, applicationroute);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage FailModeratorSection5Checks(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = section5Helper.FailProcessForEvaluatingTheQualityOfTrainingDelivered(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section5Helper.FailProcessForEvaluatingTheQualityOfApprenticeshipTraining(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = section5Helper.FailSystemsAndProcessesToCollectApprenticeshipData(moderationApplicationAssessmentOverviewPage, applicationroute);
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
