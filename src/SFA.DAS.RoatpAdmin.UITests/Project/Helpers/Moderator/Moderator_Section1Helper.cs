using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class Moderator_Section1Helper
    {
        public ModerationApplicationAssessmentOverviewPage VerifySubSectionsAsPass(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection1Link1Status(StatusHelper.StatusPass);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection1Link2Status(StatusHelper.StatusPass);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection1Link3Status(StatusHelper.StatusPass);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection1Link4Status(StatusHelper.StatusPass);
            moderationApplicationAssessmentOverviewPage = moderationApplicationAssessmentOverviewPage.VerifySection1Link5Status(StatusHelper.StatusPass);
            return moderationApplicationAssessmentOverviewPage;
        }

        public ModerationApplicationAssessmentOverviewPage VerifySubSectionsAsFail(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage.VerifySection1Link3Status(StatusHelper.StatusFail);
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassContinuityPlanForApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return moderationApplicationAssessmentOverviewPage
                    .Access_Section1_ContinuityPlanForApprenticeshipTraining()
                    .SelectPassAndContinue()
                    .VerifySection1Link1Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderationApplicationAssessmentOverviewPage
                    .VerifySection1Link1Status(StatusHelper.NotRequired);
            }
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailContinuityPlanForApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return moderationApplicationAssessmentOverviewPage
                    .Access_Section1_ContinuityPlanForApprenticeshipTraining()
                    .SelectFailAndContinue()
                    .VerifySection1Link1Status(StatusHelper.StatusFail);
            }
            else
            {
                return moderationApplicationAssessmentOverviewPage
                    .VerifySection1Link1Status(StatusHelper.NotRequired);
            }
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassEqualityAndDiversityPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section1_EqualityAndDiversityPolicy()
                .SelectPassAndContinue()
                .VerifySection1Link2Status(StatusHelper.StatusPass);
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailEqualityAndDiversityPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section1_EqualityAndDiversityPolicy()
                .SelectFailAndContinue()
                .VerifySection1Link2Status(StatusHelper.StatusFail);
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassSafeguardingAndPreventDutyPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section1_SafeguardingAndPreventDutyPolicy()
                .SelectPassAndContinueInSafeguardingAndPreventDutyPolicyPage()
                .SelectPassAndContinueInAssessorOverallResponsibilityForSafeguardingPage()
                .SelectPassAndContinue()
                .VerifySection1Link3Status(StatusHelper.StatusPass);
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailSafeguardingAndPreventDutyPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section1_SafeguardingAndPreventDutyPolicy()
                .SelectFailAndContinueInSafeguardingAndPreventDutyPolicyPage()
                .SelectFailAndContinueInAssessorOverallResponsibilityForSafeguardingPage()
                .SelectFailAndContinue()
                .VerifySection1Link3Status(StatusHelper.StatusFail);
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassHealthAndSafetyPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section1_HealthAndSafetyPolicy()
                .SelectPassAndContinueInHealthAndSafetyPolicyPage()
                .SelectPassAndContinue()
                .VerifySection1Link4Status(StatusHelper.StatusPass);
        }
        public virtual ModerationApplicationAssessmentOverviewPage FailHealthAndSafetyPolicy(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section1_HealthAndSafetyPolicy()
                .SelectFailAndContinueInHealthAndSafetyPolicyPage()
                .SelectFailAndContinue()
                .VerifySection1Link4Status(StatusHelper.StatusFail);
        }

        public virtual ModerationApplicationAssessmentOverviewPage PassActingAsASubcontractor(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section1_ActingAsASubcontractor()
                .SelectPassAndContinue()
                .VerifySection1Link5Status(StatusHelper.StatusPass);
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailActingAsASubcontractor(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section1_ActingAsASubcontractor()
                .SelectFailAndContinue()
                .VerifySection1Link5Status(StatusHelper.StatusFail);
        }

        public virtual ModerationApplicationAssessmentOverviewPage FailWorkingWithSubcontractors(ModerationApplicationAssessmentOverviewPage moderationApplicationAssessmentOverviewPage)
        {
            return moderationApplicationAssessmentOverviewPage
                .Access_Section1_ActingAsASubcontractor()
                .SelectFailAndContinue()
                .VerifySection1Link5Status(StatusHelper.StatusFail);
        }
    }
}
