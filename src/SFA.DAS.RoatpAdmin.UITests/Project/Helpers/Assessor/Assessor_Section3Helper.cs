using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class Assessor_Section3Helper
    {
        private readonly ScenarioContext _context;

        public Assessor_Section3Helper(ScenarioContext context) => _context = context;

        public ApplicationAssessmentOverviewPage PassTypeOfApprenticeshipTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadas01"))
            {
                return applicationAssessmentOverviewPage
                    .Access_Section3_TypeOfApprenticeshipTraining()
                    .SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_MP()
                    .SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
                    .SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link1Status(StatusHelper.StatusPass);
            }
            else if (_context.ScenarioInfo.Tags.Contains("rpadas02"))
            {
                return applicationAssessmentOverviewPage
                    .Access_Section3_TypeOfApprenticeshipTraining()
                    .SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_SP()
                    .SelectPassAndContinueInOfferingApprenticeshipFrameworksPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link1Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage
                    .Access_Section3_TypeOfApprenticeshipTraining()
                    .SelectPassAndContinueInTypeOfApprenticeshipTrainingPage_SP()
                    .SelectPassAndContinueInOfferingApprenticeshipFrameworksPage()
                    .SelectPassAndContinueInTransitioningFromApprenticeshipFrameworksToApprenticeshipStandardsPage()
                    .SelectPassAndContinueInEngagingWithEndpointAssessmentOrganisationsPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link1Status(StatusHelper.StatusPass);
            }
        }

        public ApplicationAssessmentOverviewPage PassSupportingApprentices(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadas03"))
            {
                return applicationAssessmentOverviewPage
                    .Access_Section3_SupportingApprentices()
                    .SelectPassAndContinueInSupportingApprenticesPage()
                    .SelectPassAndContinueInWaysOfSupportingApprenticesPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link1Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage.VerifySection3Link2Status(StatusHelper.NotRequired);
            }
        }

        public ApplicationAssessmentOverviewPage PassForecastingStarts(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadas01") || _context.ScenarioInfo.Tags.Contains("rpadas03"))
            {
                return applicationAssessmentOverviewPage
                    .Access_Section3_ForecastingStarts()
                    .SelectPassAndContinueInForecastingStartsPage()
                    .SelectPassAndContinueInReadyToDeliverTrainingAgainstForecastPage()
                    .SelectPassAndContinueInRecruitNewStaffToDeliverTrainingAgainstForecastPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link3Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage
                    .VerifySection3Link3Status(StatusHelper.NotRequired);
            }
        }

        public ApplicationAssessmentOverviewPage PassOffTheJobTraining(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadas01") || _context.ScenarioInfo.Tags.Contains("rpadas03"))
            {
                return applicationAssessmentOverviewPage
                    .Access_Section3_OffTheJobTraining()
                    .SelectPassAndContinueInOffTheJobTrainingPage()
                    .SelectPassAndContinue()
                    .VerifySection3Link4Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage.
                    VerifySection3Link4Status(StatusHelper.NotRequired);
            }
        }

        public ApplicationAssessmentOverviewPage PassWhereWillYourApprenticesBeTrained(ApplicationAssessmentOverviewPage applicationAssessmentOverviewPage)
        {
            if (_context.ScenarioInfo.Tags.Contains("rpadas01") || _context.ScenarioInfo.Tags.Contains("rpadas03"))
            {
                return applicationAssessmentOverviewPage
                .Access_Section3_WhereWillYourApprenticesBeTrained()
                .SelectPassAndContinue()
                .VerifySection3Link5Status(StatusHelper.StatusPass);
            }
            else
            {
                return applicationAssessmentOverviewPage.
                    VerifySection3Link5Status(StatusHelper.NotRequired);
            }
        }
    }
}
