using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.EPAO.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    public class EPAOBaseSteps
    {
        protected readonly EPAOConfig ePAOConfig;
        protected readonly ObjectContext objectContext;
        protected readonly TabHelper tabHelper;

        protected readonly EPAOE2EApplyUser ePAOE2EApplyUser;
        protected readonly EPAOApplyUser ePAOApplyUser;
        protected readonly EPAOStageTwoStandardCancelUser ePAOStageTwoStandardCancelUser;

        protected readonly EPAOAdminDataHelper ePAOAdminDataHelper;
        protected readonly EPAOApplyDataHelper ePAOApplyDataHelper;
        protected readonly EPAOAssesmentServiceDataHelper ePAOAssesmentServiceDataHelper;
        protected readonly EPAOApplyStandardDataHelper ePAOApplyStandardData;

        protected readonly EPAOAdminSqlDataHelper ePAOAdminSqlDataHelper;
        protected readonly EPAOAdminCASqlDataHelper ePAOAdminCASqlDataHelper;
        protected readonly EPAOApplySqlDataHelper ePAOApplySqlDataHelper;

        protected readonly AssessmentServiceStepsHelper assessmentServiceStepsHelper;
        protected readonly EPAOHomePageHelper ePAOHomePageHelper;
        protected readonly ApplyStepsHelper applyStepsHelper;
        protected readonly AdminStepshelper adminStepshelper;
        protected readonly EPAOWithdrawalHelper ePAOWithdrawalHelper;

        protected CertificateDetailsPage certificateDetailsPage;
        protected OrganisationDetailsPage organisationDetailsPage;
        protected StaffDashboardPage staffdashboardPage;

        protected AP_ApplicationOverviewPage applicationOverviewPage;
        protected AS_CreateAnAccountPage createAnAccountPage;
        protected AP_PR1_SearchForYourOrganisationPage searchForYourOrganisationPage;

        protected AO_HomePage homePage;

        protected AS_RecordAGradePage recordAGradePage;
        protected AS_AchievementDatePage achievementDatePage;
        protected AS_CheckAndSubmitAssessmentPage checkAndSubmitAssessmentPage;
        protected AS_LoggedInHomePage loggedInHomePage;
        protected AS_EditUserPermissionsPage editUserPermissionsPage;
        protected AS_UserDetailsPage userDetailsPage;
        protected AS_OrganisationDetailsPage aS_OrganisationDetailsPage;

        protected EPAOBaseSteps(ScenarioContext context)
        {
            objectContext = context.Get<ObjectContext>();
            ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
            tabHelper = context.Get<TabHelper>();

            ePAOE2EApplyUser = context.GetUser<EPAOE2EApplyUser>();
            ePAOApplyUser = context.GetUser<EPAOApplyUser>();
            ePAOStageTwoStandardCancelUser = context.GetUser<EPAOStageTwoStandardCancelUser> ();

            ePAOAdminDataHelper = context.Get<EPAOAdminDataHelper>();
            ePAOApplyDataHelper = context.Get<EPAOApplyDataHelper>();
            ePAOAssesmentServiceDataHelper = context.Get<EPAOAssesmentServiceDataHelper>();
            ePAOApplyStandardData = context.Get<EPAOApplyStandardDataHelper>();

            ePAOAdminSqlDataHelper = context.Get<EPAOAdminSqlDataHelper>();
            ePAOAdminCASqlDataHelper = context.Get<EPAOAdminCASqlDataHelper>();
            ePAOApplySqlDataHelper = context.Get<EPAOApplySqlDataHelper>();

            adminStepshelper = new AdminStepshelper();
            ePAOHomePageHelper = new EPAOHomePageHelper(context);
            applyStepsHelper = new ApplyStepsHelper(context);
            assessmentServiceStepsHelper = new AssessmentServiceStepsHelper(context);
            ePAOWithdrawalHelper = new EPAOWithdrawalHelper(context);
        }
    }
}