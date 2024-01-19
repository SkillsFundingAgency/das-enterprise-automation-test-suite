using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;

namespace SFA.DAS.EPAO.UITests.Project.Helpers;

public class EPAOHomePageHelper
{
    private readonly ScenarioContext _context;
    private readonly TabHelper _tabHelper;
    private readonly EPAOApplySqlDataHelper _ePAOSqlDataHelper;
    private readonly DfeAdminLoginStepsHelper _dfeAdminLoginStepsHelper;

    public EPAOHomePageHelper(ScenarioContext context)
    {
        _context = context;
        _tabHelper = context.Get<TabHelper>();
        _ePAOSqlDataHelper = context.Get<EPAOApplySqlDataHelper>();
        _dfeAdminLoginStepsHelper = new DfeAdminLoginStepsHelper(_context);
    }

    public StaffDashboardPage LoginToEpaoAdminHomePage(bool openInNewTab)
    {
        OpenUrl(UrlConfig.Admin_BaseUrl, openInNewTab);

        _dfeAdminLoginStepsHelper.CheckAndLoginToAsAdmin();

        return new StaffDashboardPage(_context);
    }

    public AS_LandingPage GoToEpaoAssessmentLandingPage(bool openInNewTab = false)
    {
        OpenUrl(UrlConfig.EPAOAssessmentService_BaseUrl, openInNewTab);

        return new AS_LandingPage(_context);
    }

    public AS_ApplyForAStandardPage GoToEpaoApplyForAStandardPage() => GoToEpaoAssessmentLandingPage(true).AlreadyLoginGoToApplyForAStandardPage();

    public AP_PR1_SearchForYourOrganisationPage LoginInAsApplyUser(GovSignUser loginUser) { StubSign(loginUser); return new AP_PR1_SearchForYourOrganisationPage(_context); }

    public AS_LoggedInHomePage LoginInAsNonApplyUser(GovSignUser loginUser) { StubSign(loginUser); return new AS_LoggedInHomePage(_context); }

    public AS_LoggedInHomePage LoginInAsStandardApplyUser(GovSignUser loginUser, string standardcode, string organisationId)
    {
        _ePAOSqlDataHelper.DeleteStandardApplicication(standardcode, organisationId, loginUser.Username);

        return LoginInAsNonApplyUser(loginUser);
    }

    private void OpenUrl(string url, bool openInNewTab)
    {
        if (openInNewTab) { _tabHelper.OpenInNewTab(url); } else { _tabHelper.GoToUrl(url); }
    }

    public AS_LoggedInHomePage StageTwoEPAOStandardCancelUser(GovSignUser loginUser) => LoginInAsNonApplyUser(loginUser);

    private void StubSign(GovSignUser loginUser)
    {
        GoToEpaoAssessmentLandingPage().GoToStubSign().SubmitValidUserDetails(loginUser).Continue();

        _context.Get<EPAOAdminDataHelper>().LoginEmailAddress = loginUser.Username;

        _context.Set(new EPAOAssessorPortalLoggedInUser { Username = loginUser.Username, IdOrUserRef = loginUser.IdOrUserRef });
    }
}
