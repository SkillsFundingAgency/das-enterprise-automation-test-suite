using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Clarification
{
    public class Clarification_Section2Helper : Moderator_Section2Helper
    {
        public new ModerationApplicationAssessmentOverviewPage PassEngagingWithEmployers(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
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

        public new ModerationApplicationAssessmentOverviewPage PassComplaintsPolicy(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
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

        public new ModerationApplicationAssessmentOverviewPage PassContractForServicesTemplate(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
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

        public new ModerationApplicationAssessmentOverviewPage PassCommitmentStatementTemplate(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
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

        public new ModerationApplicationAssessmentOverviewPage PassPriorLearningOfApprentices(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
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

        public new ModerationApplicationAssessmentOverviewPage PassWorkingWithSubcontractors(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
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
