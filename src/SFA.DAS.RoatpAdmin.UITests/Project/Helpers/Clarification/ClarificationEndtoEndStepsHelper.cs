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

        public RoatpApplicationsHomePage CompleteClarificationOutcomeSectionAsPass(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return CompleteModeratorOutcomeSectionAsPass(moderationApplicationAssessmentOverviewPage);
        }
    }
}
