using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Clarification
{
    public class Clarification_Section2Helper : Moderator_Section2Helper
    {
        public override ModerationApplicationAssessmentOverviewPage PassEngagingWithEmployers(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderatorApplicationAssessmentOverviewPage.VerifySection2Link1Status(StatusHelper.StatusClarification);

            return base.PassEngagingWithEmployers(moderatorApplicationAssessmentOverviewPage, applicationroute);
        }

        public override ModerationApplicationAssessmentOverviewPage PassComplaintsPolicy(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderatorApplicationAssessmentOverviewPage.VerifySection2Link2Status(StatusHelper.StatusClarification);

            return base.PassComplaintsPolicy(moderatorApplicationAssessmentOverviewPage, applicationroute);
        }

        public override ModerationApplicationAssessmentOverviewPage PassContractForServicesTemplate(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderatorApplicationAssessmentOverviewPage.VerifySection2Link3Status(StatusHelper.StatusClarification);

            return base.PassContractForServicesTemplate(moderatorApplicationAssessmentOverviewPage, applicationroute);
        }

        public override ModerationApplicationAssessmentOverviewPage PassCommitmentStatementTemplate(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                moderatorApplicationAssessmentOverviewPage.VerifySection2Link4Status(StatusHelper.StatusClarification);
            }
            return base.PassCommitmentStatementTemplate(moderatorApplicationAssessmentOverviewPage, applicationroute);
        }

        public override ModerationApplicationAssessmentOverviewPage PassPriorLearningOfApprentices(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderatorApplicationAssessmentOverviewPage.VerifySection2Link5Status(StatusHelper.StatusClarification);

            return base.PassPriorLearningOfApprentices(moderatorApplicationAssessmentOverviewPage, applicationroute);
        }

        public override ModerationApplicationAssessmentOverviewPage PassWorkingWithSubcontractors(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                moderatorApplicationAssessmentOverviewPage.VerifySection2Link6Status(StatusHelper.StatusClarification);
            }
            return base.PassWorkingWithSubcontractors(moderatorApplicationAssessmentOverviewPage, applicationroute);
        }

        public override ModerationApplicationAssessmentOverviewPage FailCommitmentStatementTemplate(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                moderatorApplicationAssessmentOverviewPage.VerifySection2Link4Status(StatusHelper.StatusClarification);
            }

            return base.FailCommitmentStatementTemplate(moderatorApplicationAssessmentOverviewPage, applicationroute);
        }

        public override ModerationApplicationAssessmentOverviewPage FailWorkingWithSubcontractors(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                moderatorApplicationAssessmentOverviewPage.VerifySection2Link6Status(StatusHelper.StatusClarification);
            }

            return base.FailWorkingWithSubcontractors(moderatorApplicationAssessmentOverviewPage, applicationroute);
        }
    }
}
