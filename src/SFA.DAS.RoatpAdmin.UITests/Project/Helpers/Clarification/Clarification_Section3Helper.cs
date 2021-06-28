using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Moderator;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Clarification
{
    public class Clarification_Section3Helper : Moderator_Section3Helper
    {
        public override ModerationApplicationAssessmentOverviewPage PassTypeOfApprenticeshipTraining(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderatorApplicationAssessmentOverviewPage.VerifySection3Link1Status(StatusHelper.StatusClarification);

            return base.PassTypeOfApprenticeshipTraining(moderatorApplicationAssessmentOverviewPage, applicationroute);

        }

        public override ModerationApplicationAssessmentOverviewPage PassTrainingApprentices(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                moderatorApplicationAssessmentOverviewPage.VerifySection3Link2Status(StatusHelper.StatusClarification);
            }

            return base.PassSupportingApprentices(moderatorApplicationAssessmentOverviewPage, applicationroute);
        }

        public override ModerationApplicationAssessmentOverviewPage PassSupportingApprentices(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                moderatorApplicationAssessmentOverviewPage.VerifySection3Link3Status(StatusHelper.StatusClarification);
            }

            return base.PassSupportingApprentices(moderatorApplicationAssessmentOverviewPage, applicationroute);
        }

        public override ModerationApplicationAssessmentOverviewPage PassForecastingStarts(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderatorApplicationAssessmentOverviewPage.VerifySection3Link4Status(StatusHelper.StatusClarification);

            return base.PassForecastingStarts(moderatorApplicationAssessmentOverviewPage, applicationroute);
        }

        public override ModerationApplicationAssessmentOverviewPage PassOffTheJobTraining(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            moderatorApplicationAssessmentOverviewPage.VerifySection3Link5Status(StatusHelper.StatusClarification);

            return base.PassOffTheJobTraining(moderatorApplicationAssessmentOverviewPage, applicationroute);
        }

        public override ModerationApplicationAssessmentOverviewPage PassWhereWillYourApprenticesBeTrained(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                moderatorApplicationAssessmentOverviewPage.VerifySection3Link6Status(StatusHelper.StatusClarification);
            }

            return base.PassWhereWillYourApprenticesBeTrained(moderatorApplicationAssessmentOverviewPage, applicationroute);
        }

        public override ModerationApplicationAssessmentOverviewPage FailWhereWillYourApprenticesBeTrained(ModerationApplicationAssessmentOverviewPage moderatorApplicationAssessmentOverviewPage, ApplicationRoute applicationroute)
        {
            if (applicationroute == ApplicationRoute.MainProviderRoute || applicationroute == ApplicationRoute.EmployerProviderRoute)
            {
                moderatorApplicationAssessmentOverviewPage.VerifySection3Link6Status(StatusHelper.StatusClarification);
            }
            return base.PassWhereWillYourApprenticesBeTrained(moderatorApplicationAssessmentOverviewPage, applicationroute);
        }
    }
}
