using SFA.DAS.EPAO.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ApplyToAssessStandard;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAOHomePageHelper
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        private readonly EPAOApplySqlDataHelper _ePAOSqlDataHelper;

        public EPAOHomePageHelper(ScenarioContext context)
        {
            _context = context;
            _tabHelper = context.Get<TabHelper>();
            _ePAOSqlDataHelper = context.Get<EPAOApplySqlDataHelper>();
        }

        public StaffDashboardPage LoginToEpaoAdminHomePage(bool openInNewTab = false)
        {
            var serviceStartPage = OpenAdminBaseUrl(openInNewTab);

            serviceStartPage.StartNow().LoginToAccess1Staff();

            return new SignInPage(_context).SignInWithValidDetails();
        }

        public AS_LandingPage GoToEpaoAssessmentLandingPage(bool openInNewTab = false)
        {
            OpenUrl(UrlConfig.EPAOAssessmentService_BaseUrl, openInNewTab);

            return new AS_LandingPage(_context);
        }

        public AS_ApplyForAStandardPage GoToEpaoApplyForAStandardPage() => GoToEpaoAssessmentLandingPage(true).AlreadyLoginGoToApplyForAStandardPage();

      public StaffDashboardPage AlreadyLoginGoToEpaoAdminStaffDashboardPage()
      {
            OpenAdminBaseUrl(true).ClickStartNowButton();

            return new StaffDashboardPage(_context);
      }

        public AP_PR1_SearchForYourOrganisationPage LoginInAsApplyUser(LoginUser loginUser) => GoToEpaoAssessmentLandingPage().GoToLoginPage().SignInAsApplyUser(loginUser);

        public AS_LoggedInHomePage LoginInAsNonApplyUser(LoginUser loginUser) => GoToEpaoAssessmentLandingPage().GoToLoginPage().SignInWithValidDetails(loginUser);

        public AS_LoggedInHomePage LoginInAsStandardApplyUser(LoginUser loginUser, string standardcode, string organisationId)
        {
            _ePAOSqlDataHelper.DeleteStandardApplicication(standardcode, organisationId, loginUser.Username);

            return LoginInAsNonApplyUser(loginUser);
        }

        private ServiceStartPage OpenAdminBaseUrl(bool openInNewTab)
        {
            OpenUrl(UrlConfig.Admin_BaseUrl, openInNewTab);

            return new ServiceStartPage(_context);
        }

        private void OpenUrl(string url, bool openInNewTab)
        {
            if (openInNewTab) { _tabHelper.OpenInNewTab(url); } else { _tabHelper.GoToUrl(url); }
        }

        public AS_LoggedInHomePage StageTwoEPAOStandardCancelUser(LoginUser loginUser) => GoToEpaoAssessmentLandingPage().GoToLoginPage().SignInWithValidDetails(loginUser);
    }
}
