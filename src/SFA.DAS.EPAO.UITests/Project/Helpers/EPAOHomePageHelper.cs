using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAOHomePageHelper
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        private readonly EPAOConfig _ePAOConfig;
        private readonly EPAOSqlDataHelper _ePAOSqlDataHelper;

        public EPAOHomePageHelper(ScenarioContext context)
        {
            _context = context;
            _tabHelper = context.Get<TabHelper>();
            _ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
            _ePAOSqlDataHelper = context.Get<EPAOSqlDataHelper>();
        }

        public StaffDashboardPage GoToEpaoAdminHomePage()
        {
            new ServiceStartPage(_context).ClickStartNow().LoginToAccess1Staff();

            return new SignInPage(_context).SignInWithValidDetails();
        }

        public AS_LandingPage GoToEpaoAssessmentLandingPage()
        {
            _tabHelper.GoToUrl(_ePAOConfig.AssessmentServiceUrl);

            return new AS_LandingPage(_context);
        }

        public AP_PR1_SearchForYourOrganisationPage LoginInAsApplyUser(LoginUser loginUser)
        {
            _ePAOSqlDataHelper.ResetApplyUser(loginUser.Username);

            return GoToEpaoAssessmentLandingPage().ClickStartButton().SignInAsApplyUser(loginUser);
        }

        public AS_LoggedInHomePage LoginInAsNonApplyUser(LoginUser loginUser) => GoToEpaoAssessmentLandingPage().ClickStartButton().SignInWithValidDetails(loginUser);

        public AS_LoggedInHomePage LoginInAsNonApplyUser(LoginUser loginUser, string standardReference, string organisationId)
        {
            _ePAOSqlDataHelper.DeleteStandardApplicication(standardReference, organisationId, loginUser.Username);

            return GoToEpaoAssessmentLandingPage().ClickStartButton().SignInWithValidDetails(loginUser);
        }

    }
}
