using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator
{
    public class Moderator_Section2Helper
    {
        public ModerationApplicationAssessmentOverviewPage PassEngagingWithEmployers(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section2_EngagingWithEmployers()
                    .SelectPassAndContinueInEngagingWithEmployersPage()
                    .SelectPassAndContinueInManagingRelationshipWithEmployersPage()
                    .SelectPassAndContinueInOverallResponsibilityForManagingRelationshipsWithEmployersPage()
                    .SelectPassAndContinue()
                    .VerifySection2Link1Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage
                    .VerifySection2Link1Status(StatusHelper.NotRequired);
            }
        }

        public ModerationApplicationAssessmentOverviewPage PassComplaintsPolicy(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section2_ComplaintsPolicy()
                    .SelectPassAndContinueInComplaintsPolicyPage()
                    .SelectPassAndContinue()
                    .VerifySection2Link2Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage
                    .VerifySection2Link2Status(StatusHelper.NotRequired);
            }
        }

        public ModerationApplicationAssessmentOverviewPage PassContractForServicesTemplate(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section2_ContractForServicesTemplate()
                    .SelectPassAndContinue()
                    .VerifySection2Link3Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage
                    .VerifySection2Link3Status(StatusHelper.NotRequired);
            }
        }

        public ModerationApplicationAssessmentOverviewPage PassCommitmentStatementTemplate(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section2_CommitmentStatementTemplate()
                    .SelectPassAndContinue()
                    .VerifySection2Link4Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage
                    .VerifySection2Link4Status(StatusHelper.NotRequired);
            }
        }

        public ModerationApplicationAssessmentOverviewPage PassPriorLearningOfApprentices(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section2_PriorLearningOfApprentices()
                    .SelectPassAndContinueInPriorLearningOfApprenticesPage()
                    .SelectPassAndContinue()
                    .VerifySection2Link5Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage
                    .VerifySection2Link5Status(StatusHelper.NotRequired);
            }
        }

        public ModerationApplicationAssessmentOverviewPage PassWorkingWithSubcontractors(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                return moderatorApplicationAssessmentOverviewPage
                    .Access_Section2_WorkingWithSubcontractors()
                    .SelectPassAndContinueInWorkingWithSubcontractorsPage()
                    .SelectPassAndContinue()
                    .VerifySection2Link6Status(StatusHelper.StatusPass);
            }
            else
            {
                return moderatorApplicationAssessmentOverviewPage
                    .VerifySection2Link6Status(StatusHelper.NotRequired);
            }
        }
    }
}
