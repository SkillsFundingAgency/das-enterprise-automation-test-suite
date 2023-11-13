using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

namespace SFA.DAS.EPAO.UITests.Project.Helpers;

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
        OpenAdminUrl(openInNewTab);

        new DfeAdminLoginStepsHelper(_context).SubmitValidAsLoginDetails(serviceStartPage);

        return new StaffDashboardPage(_context);
    }

    public AS_LandingPage GoToEpaoAssessmentLandingPage(bool openInNewTab = false)
    {
        OpenUrl(UrlConfig.EPAOAssessmentService_BaseUrl, openInNewTab);

        return new AS_LandingPage(_context);
    }

    public AS_ApplyForAStandardPage GoToEpaoApplyForAStandardPage() => GoToEpaoAssessmentLandingPage(true).AlreadyLoginGoToApplyForAStandardPage();

    public StaffDashboardPage AlreadyLoginGoToEpaoAdminStaffDashboardPage()
    {
        OpenAdminUrl(true);

        var startNowPage = new CheckStartNowButtonPage(_context);

        if (startNowPage.IsPageDisplayed()) startNowPage.ClickStartNowButton();

        if (new CheckEpaoDfeSignInPage(_context).IsPageDisplayed()) new EpaoDfeSignInPage(_context).SignInWithValidDetails();

        if (new CheckDfeSignInPage(_context).IsPageDisplayed()) { }

        return new StaffDashboardPage(_context);
    }

    public AP_PR1_SearchForYourOrganisationPage LoginInAsApplyUser(NonEasAccountUser loginUser) => GoToEpaoAssessmentLandingPage().GoToLoginPage().SignInAsApplyUser(loginUser);

    public AS_LoggedInHomePage LoginInAsNonApplyUser(NonEasAccountUser loginUser) => GoToEpaoAssessmentLandingPage().GoToLoginPage().SignInWithValidDetails(loginUser);

    public AS_LoggedInHomePage LoginInAsStandardApplyUser(NonEasAccountUser loginUser, string standardcode, string organisationId)
    {
        _ePAOSqlDataHelper.DeleteStandardApplicication(standardcode, organisationId, loginUser.Username);

        return LoginInAsNonApplyUser(loginUser);
    }

    private ASAdminLandingPage OpenAdminBaseUrl(bool openInNewTab)
    {
        OpenUrl(UrlConfig.Admin_BaseUrl, openInNewTab);

        return new ASAdminLandingPage(_context);
    }

    private void OpenUrl(string url, bool openInNewTab)
    {
        if (openInNewTab) { _tabHelper.OpenInNewTab(url); } else { _tabHelper.GoToUrl(url); }
    }

    public AS_LoggedInHomePage StageTwoEPAOStandardCancelUser(NonEasAccountUser loginUser) => GoToEpaoAssessmentLandingPage().GoToLoginPage().SignInWithValidDetails(loginUser);
}
