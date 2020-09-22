using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class Moderator_Section3Helper
    {
        private readonly ScenarioContext _context;

        public Moderator_Section3Helper(ScenarioContext context) => _context = context;

        public ModerationApplicationAssessmentOverviewPage PassTypeOfApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadmod01"))
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_TypeOfApprenticeshipTraining()
                    .SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_MP()
                    .SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
                    .SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link1Status(StatusHelper.StatusPass);
            }
            else if (_context.ScenarioInfo.Tags.Contains("rpadmod02"))
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_TypeOfApprenticeshipTraining()
                    .SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_SP()
                    .SelectPassAndContinueInOfferingApprenticeshipFrameworksPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link1Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_TypeOfApprenticeshipTraining()
                    .SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_SP()
                    .SelectPassAndContinueInOfferingApprenticeshipFrameworksPage()
                    .SelectPassAndContinueInTransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage()
                    .SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link1Status(StatusHelper.StatusPass);
            }
        }

        public ModerationApplicationAssessmentOverviewPage PassSupportingApprentices(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadmod03"))
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_SupportingApprentices()
                    .SelectPassAndContinueInSupportingApprenticesPage()
                    .SelectPassAndContinueInWaysOfSupportingApprenticesPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link1Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage.VerifySection3Link2Status(StatusHelper.NotRequired);
            }
        }

        public ModerationApplicationAssessmentOverviewPage PassForecastingStarts(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadmod01") || _context.ScenarioInfo.Tags.Contains("rpadmod03"))
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_ForecastingStarts()
                    .SelectPassAndContinueInForecastingStartsPage()
                    .SelectPassAndContinueInReadyToDeliverTrainingAgainstForecastPage()
                    .SelectPassAndContinueInRecruitNewStaffToDeliverTrainingAgainstForecastPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link3Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage
                    .VerifySection3Link3Status(StatusHelper.NotRequired);
            }
        }

        public ModerationApplicationAssessmentOverviewPage PassOffTheJobTraining(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadmod01") || _context.ScenarioInfo.Tags.Contains("rpadmod03"))
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section3_OffTheJobTraining()
                    .SelectPassAndContinueInOffTheJobTrainingPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link4Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage.
                    VerifySection3Link4Status(StatusHelper.NotRequired);
            }
        }

        public ModerationApplicationAssessmentOverviewPage PassWhereWillYourApprenticesBeTrained(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadmod01") || _context.ScenarioInfo.Tags.Contains("rpadmod03"))
            {
                return moderatorApplicationAssessmentOverviewPage
                .Access_Section3_WhereWillYourApprenticesBeTrained()
                .SelectPassAndContinue()
                .VerifySection3Link5Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage.
                    VerifySection3Link5Status(StatusHelper.NotRequired);
            }
        }
    }
}
