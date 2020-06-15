using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;
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
        private readonly EPAOApplySqlDataHelper _ePAOSqlDataHelper;

        public EPAOHomePageHelper(ScenarioContext context)
        {
            _context = context;
            _tabHelper = context.Get<TabHelper>();
            _ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
            _ePAOSqlDataHelper = context.Get<EPAOApplySqlDataHelper>();
        }

        public StaffDashboardPage LoginToEpaoAdminHomePage(bool openInNewTab = false)
        {
            OpenAdminBaseUrl(openInNewTab);

            new ServiceStartPage(_context).ClickStartNow().LoginToAccess1Staff();

            return new SignInPage(_context).SignInWithValidDetails();
        }

        public AS_LandingPage GoToEpaoAssessmentLandingPage(bool openInNewTab = false)
        {
            OpenAssessmentServiceUrl(openInNewTab);

            return new AS_LandingPage(_context);
        }

        public AS_ApplyForAStandardPage GoToEpaoApplyForAStandardPage() => GoToEpaoAssessmentLandingPage(true).AlreadyLoginClickStartNowButton();

        public StaffDashboardPage GoToEpaoAdminStaffDashboardPage()
        {
            OpenAdminBaseUrl(true);

            return new StaffDashboardPage(_context);
        }

        public AP_PR1_SearchForYourOrganisationPage LoginInAsApplyUser(LoginUser loginUser) => GoToEpaoAssessmentLandingPage().ClickStartNowButton().SignInAsApplyUser(loginUser);

        public AS_LoggedInHomePage LoginInAsNonApplyUser(LoginUser loginUser) => GoToEpaoAssessmentLandingPage().ClickStartNowButton().SignInWithValidDetails(loginUser);

        public AS_LoggedInHomePage LoginInAsStandardApplyUser(LoginUser loginUser, string standardcode, string organisationId)
        {
            _ePAOSqlDataHelper.DeleteStandardApplicication(standardcode, organisationId, loginUser.Username);

            return LoginInAsNonApplyUser(loginUser);
        }

        private void OpenAssessmentServiceUrl(bool openInNewTab) => OpenUrl(_ePAOConfig.AssessmentServiceUrl, openInNewTab);

        private void OpenAdminBaseUrl(bool openInNewTab) => OpenUrl(_ePAOConfig.AdminBaseUrl, openInNewTab);

        private void OpenUrl(string url, bool openInNewTab)
        {
            if (openInNewTab) { _tabHelper.OpenInNewTab(url); } else { _tabHelper.GoToUrl(url); }
        }
    }
}