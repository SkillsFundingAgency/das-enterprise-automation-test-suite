using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Clarification
{
    public class ClarificationEndtoEndStepsHelper : ModeratorEndtoEndStepsHelper
    {
        public ClarificationEndtoEndStepsHelper() : base(
            new Clarification_Section1Helper(),
            new Clarification_Section2Helper(),
            new Clarification_Section3Helper(),
            new Clarification_Section4Helper(),
            new Clarification_Section5Helper())
        {

        }

        public RoatpAssessorApplicationsHomePage CompleteClarificationOutcomeSectionAsPass(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return CompleteModeratorOutcomeSectionAsPass(moderationApplicationAssessmentOverviewPage);
        }

        public RoatpAssessorApplicationsHomePage CompleteClarificationOutcomeSectionAsFail(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return CompleteModeratorOutcomeSectionAsFail(moderationApplicationAssessmentOverviewPage);
        }

        public ModerationApplicationAssessmentOverviewPage CompleteSomeSectionsWithFail(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderationApplicationAssessmentOverviewPage = _section1Helper.FailSafeguardingAndPreventDutyPolicy(moderationApplicationAssessmentOverviewPage);
            moderationApplicationAssessmentOverviewPage = _section2Helper.FailCommitmentStatementTemplate(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section2Helper.FailWorkingWithSubcontractors(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section3Helper.FailWhereWillYourApprenticesBeTrained(moderationApplicationAssessmentOverviewPage, applicationroute);
            moderationApplicationAssessmentOverviewPage = _section4Helper.FailQualityAndHighStandardsInApprenticeshipTraining(moderationApplicationAssessmentOverviewPage); 
            moderationApplicationAssessmentOverviewPage = _section4Helper.FailPolicyForProfessionalDevelopmentOfEmployees(moderationApplicationAssessmentOverviewPage);
            return moderationApplicationAssessmentOverviewPage;
        }
    }
}
