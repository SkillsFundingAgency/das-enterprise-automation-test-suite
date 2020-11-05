using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Clarification;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Clarification
{
    public class ClarificationEndtoEndStepsHelper
    {
        private readonly Clarification_Section1Helper _clarification_Section1Helper;
        private readonly Moderator_Section2Helper _moderator_Section2Helper;
        private readonly Moderator_Section3Helper _moderator_Section3Helper;
        private readonly Moderator_Section4Helper _moderator_Section4Helper;
        private readonly Moderator_Section5Helper _moderator_Section5Helper;

        public ClarificationEndtoEndStepsHelper()
        {
            _clarification_Section1Helper = new Clarification_Section1Helper();
            _moderator_Section2Helper = new Moderator_Section2Helper();
            _moderator_Section3Helper = new Moderator_Section3Helper();
            _moderator_Section4Helper = new Moderator_Section4Helper();
            _moderator_Section5Helper = new Moderator_Section5Helper();
        }

        public ModerationApplicationAssessmentOverviewPage CompleteAllSectionsWithPass(ModerationApplicationAssessmentOverviewPage ClarificationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            ClarificationApplicationAssessmentOverviewPage = CompleteModeratorSection1Checks(ClarificationApplicationAssessmentOverviewPage, applicationroute);
            //ClarificationApplicationAssessmentOverviewPage = CompleteModeratorSection2Checks(ClarificationApplicationAssessmentOverviewPage, applicationroute);
            //ClarificationApplicationAssessmentOverviewPage = CompleteModeratorSection3Checks(ClarificationApplicationAssessmentOverviewPage, applicationroute);
            //ClarificationApplicationAssessmentOverviewPage = CompleteModeratorSection4Checks(ClarificationApplicationAssessmentOverviewPage, applicationroute);
            //ClarificationApplicationAssessmentOverviewPage = CompleteModeratorSection5Checks(ClarificationApplicationAssessmentOverviewPage, applicationroute);
            return ClarificationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage CompleteModeratorSection1Checks(ModerationApplicationAssessmentOverviewPage ClarificationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            ClarificationApplicationAssessmentOverviewPage = _clarification_Section1Helper.PassContinuityPlanForApprenticeshipTraining(ClarificationApplicationAssessmentOverviewPage, applicationroute);
            ClarificationApplicationAssessmentOverviewPage = _clarification_Section1Helper.PassEqualityAndDiversityPolicy(ClarificationApplicationAssessmentOverviewPage);
            ClarificationApplicationAssessmentOverviewPage = _clarification_Section1Helper.PassSafeguardingAndPreventDutyPolicy(ClarificationApplicationAssessmentOverviewPage);
            ClarificationApplicationAssessmentOverviewPage = _clarification_Section1Helper.PassHealthAndSafetyPolicy(ClarificationApplicationAssessmentOverviewPage);
            ClarificationApplicationAssessmentOverviewPage = _clarification_Section1Helper.PassActingAsASubcontractor(ClarificationApplicationAssessmentOverviewPage);
            return ClarificationApplicationAssessmentOverviewPage;
        }
        
        //public ClarificationApplicationAssessmentOverviewPage CompleteModeratorSection2Checks(ClarificationApplicationAssessmentOverviewPage ClarificationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        //{
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassEngagingWithEmployers(ClarificationApplicationAssessmentOverviewPage, applicationroute);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassComplaintsPolicy(ClarificationApplicationAssessmentOverviewPage, applicationroute);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassContractForServicesTemplate(ClarificationApplicationAssessmentOverviewPage, applicationroute);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassCommitmentStatementTemplate(ClarificationApplicationAssessmentOverviewPage, applicationroute);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassPriorLearningOfApprentices(ClarificationApplicationAssessmentOverviewPage, applicationroute);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section2Helper.PassWorkingWithSubcontractors(ClarificationApplicationAssessmentOverviewPage, applicationroute);
        //    return ClarificationApplicationAssessmentOverviewPage;
        //}

        //public ClarificationApplicationAssessmentOverviewPage CompleteModeratorSection3Checks(ClarificationApplicationAssessmentOverviewPage ClarificationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        //{
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassTypeOfApprenticeshipTraining(ClarificationApplicationAssessmentOverviewPage, applicationroute);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassSupportingApprentices(ClarificationApplicationAssessmentOverviewPage, applicationroute);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassForecastingStarts(ClarificationApplicationAssessmentOverviewPage, applicationroute);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassOffTheJobTraining(ClarificationApplicationAssessmentOverviewPage, applicationroute);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section3Helper.PassWhereWillYourApprenticesBeTrained(ClarificationApplicationAssessmentOverviewPage, applicationroute);
        //    return ClarificationApplicationAssessmentOverviewPage;
        //}

        //public ClarificationApplicationAssessmentOverviewPage FailTypeOfApprenticeshipTraining(ClarificationApplicationAssessmentOverviewPage ClarificationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        //{
        //    return _moderator_Section3Helper.FailTypeOfApprenticeshipTraining(ClarificationApplicationAssessmentOverviewPage, applicationroute);
        //}

        //public ClarificationApplicationAssessmentOverviewPage CompleteModeratorSection4Checks(ClarificationApplicationAssessmentOverviewPage ClarificationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        //{
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassOverallAccountabilityForApprenticeships(ClarificationApplicationAssessmentOverviewPage);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassManagementHierarchyForApprenticeships(ClarificationApplicationAssessmentOverviewPage);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassQualityAndHighStandardsInApprenticeshipTraining(ClarificationApplicationAssessmentOverviewPage);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassDevelopingAndDeliveringTraining(ClarificationApplicationAssessmentOverviewPage, applicationroute);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassYourSectorsAndEmployees(ClarificationApplicationAssessmentOverviewPage);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section4Helper.PassPolicyForProfessionalDevelopmentOfEmployees(ClarificationApplicationAssessmentOverviewPage);
        //    return ClarificationApplicationAssessmentOverviewPage;
        //}

        //public ClarificationApplicationAssessmentOverviewPage FailYourSectorsAndEmployees(ClarificationApplicationAssessmentOverviewPage ClarificationApplicationAssessmentOverviewPage)
        //{
        //    return _moderator_Section4Helper.FailYourSectorsAndEmployees(ClarificationApplicationAssessmentOverviewPage);
        //}

        //public ClarificationApplicationAssessmentOverviewPage CompleteModeratorSection5Checks(ClarificationApplicationAssessmentOverviewPage ClarificationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        //{
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section5Helper.PassProcessForEvaluatingTheQualityOfTrainingDelivered(ClarificationApplicationAssessmentOverviewPage);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section5Helper.PassProcessForEvaluatingTheQualityOfApprenticeshipTraining(ClarificationApplicationAssessmentOverviewPage);
        //    ClarificationApplicationAssessmentOverviewPage = _moderator_Section5Helper.PassSystemsAndProcessesToCollectApprenticeshipData(ClarificationApplicationAssessmentOverviewPage, applicationroute);
        //    return ClarificationApplicationAssessmentOverviewPage;
        //}

        //public ModerationApplicationsPage CompleteModeratorOutcomeSectionAsPass(ClarificationApplicationAssessmentOverviewPage ClarificationApplicationAssessmentOverviewPage)
        //{
        //    return ClarificationApplicationAssessmentOverviewPage
        //        .Access_Section6_ReadyForModeration()
        //        .SelectPassAndContinueAreYouSurePage()
        //        .SelectYesPassAndContinueOutcomePage()
        //        .GoToRoATPAssessorApplicationsPage();
        //}

        //public ModerationApplicationsPage CompleteModeratorOutcomeSectionAsFail(ClarificationApplicationAssessmentOverviewPage ClarificationApplicationAssessmentOverviewPage)
        //{
        //    return ClarificationApplicationAssessmentOverviewPage
        //        .Access_Section6_ReadyForModeration()
        //        .SelectFailAndContinueAreYouSurePage()
        //        .SelectYesFailAndContinueOutcomePage()
        //        .GoToRoATPAssessorApplicationsPage();
        //}

        //public ModerationApplicationsPage CompleteModeratorOutcomeSectionAsAskClarification(ClarificationApplicationAssessmentOverviewPage ClarificationApplicationAssessmentOverviewPage)
        //{
        //    return ClarificationApplicationAssessmentOverviewPage
        //        .Access_Section6_ReadyForModeration()
        //        .SelectAskForClarificationAndContinueAreYouSurePage()
        //        .SelectYesAskAndContinueOutcomePage()
        //        .GoToRoATPAssessorApplicationsPage();
        //}
    }
}
