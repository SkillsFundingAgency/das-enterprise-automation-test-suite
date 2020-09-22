using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class Moderator_Section5Helper
    {
        private readonly ScenarioContext _context;

        public Moderator_Section5Helper(ScenarioContext context) => _context = context;

        public ModerationApplicationAssessmentOverviewPage PassProcessForEvaluatingTheQualityOfTrainingDelivered(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section5_ProcessForEvaluatingTheQualityOfTrainingDelivered()
                .SelectPassAndContinueInProcessForEvaluatingTheQualityOfTrainingDeliveredPage()
                .SelectPassAndContinue()
                .VerifySection5Link1Status(StatusHelper.StatusPass);
        }

        public ModerationApplicationAssessmentOverviewPage PassProcessForEvaluatingTheQualityOfApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section5_ProcessOfEvaluatingTheQualityOfApprenticeshipTraining()
                .SelectPassAndContinueInProcessForEvaluatingTheQualityOfApprenticeshipTrainingPage()
                .SelectPassAndContinue()
                .VerifySection5Link2Status(StatusHelper.StatusPass);
        }

        public ModerationApplicationAssessmentOverviewPage PassSystemsAndProcessesToCollectApprenticeshipData(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadmod01") || _context.ScenarioInfo.Tags.Contains("rpadmod03"))
            {
                return moderationApplicationAssessmentOverviewPage
                    .Access_Section5_SystemsAndProcessesToCollectApprenticeshipData()
                    .SelectPassAndContinueInSystemsAndProcessesToCollectApprenticeshipDataPage()
                    .SelectPassAndContinue()
                    .VerifySection5Link3Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderationApplicationAssessmentOverviewPage
                    .VerifySection5Link3Status(StatusHelper.NotRequired);
            }
        }
    }
}
