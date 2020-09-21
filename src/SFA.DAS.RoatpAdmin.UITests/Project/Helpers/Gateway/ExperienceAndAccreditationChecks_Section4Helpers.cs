using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Gateway
{
    public class ExperienceAndAccreditationChecks_Section4Helpers
    {
        internal GWApplicationOverviewPage PassExperienceAndAccreditationChecks_OfficeForStudent(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section4_OFS()
            .SelectPassAndContinue()
            .VerifyOfficeforStudent_OFS_Section4(StatusHelper.StatusPass);
        }
        internal GWApplicationOverviewPage PassExperienceAndAccreditationChecks_InitialTeacherTraining(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section4_ITT()
            .SelectPassAndContinue()
            .VerifyInitialteachertraining_ITT_Section4(StatusHelper.StatusPass);
        }
        internal GWApplicationOverviewPage NotRequiredExperienceAndAccreditationChecks_OFS_ITT(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
           .VerifyOfficeforStudent_OFS_Section4(StatusHelper.NotRequired)
           .VerifyInitialteachertraining_ITT_Section4(StatusHelper.NotRequired);
        }
        internal GWApplicationOverviewPage NotRequiredExperienceAndAccreditationChecks_SubContractor(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
           .VerifySubcontractordeclaration_Section4(StatusHelper.NotRequired);
        }
        internal GWApplicationOverviewPage PassExperienceAndAccreditationChecks_SubContractor(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section4_SubcontractorDeclaration()
            .SelectPassAndContinue()
           .VerifySubcontractordeclaration_Section4(StatusHelper.StatusPass);
        }
        internal GWApplicationOverviewPage PassExperienceAndAccreditationChecks_Ofsted(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section4_Ofstead()
            .SelectPassAndContinue()
            .VerifyOfsted_Section4(StatusHelper.StatusPass);
        }
        internal GWApplicationOverviewPage NotRequiredExperienceAndAccreditationChecks_Ofsted(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .VerifyOfsted_Section4(StatusHelper.NotRequired);
        }
        internal GWApplicationOverviewPage PassExperienceAndAccreditationChecks_SubcontractorDeclaration(GWApplicationOverviewPage gwApplicationOverviewPage)
        {
            return gwApplicationOverviewPage
            .Access_Section4_SubcontractorDeclaration()
            .SelectPassAndContinue()
            .VerifySubcontractordeclaration_Section4(StatusHelper.StatusPass);
        }
    }
}
