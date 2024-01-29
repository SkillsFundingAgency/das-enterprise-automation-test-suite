using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.DfeSignPages;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;
using SFA.DAS.Login.Service;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;

namespace SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;

public class DfeAdminLoginStepsHelper(ScenarioContext context)
{

    #region Login
    public void NavigateAndLoginToASAdmin()
    {
        context.Get<TabHelper>().GoToUrl(UrlConfig.Admin_BaseUrl);

        LoginToAsAdmin();
    }

    public void LoginToAsAssessor1() => CheckAndLoginToAsAdmin(context.GetUser<AsAssessor1User>());

    public void LoginToAsAssessor2() => CheckAndLoginToAsAdmin(context.GetUser<AsAssessor2User>());

    public void LoginToAsAdmin() => SubmitValidLoginDetails(new ASAdminLandingPage(context), GetAsAdminUser());

    public void LoginToSupportConsole(DfeAdminUser dfeAdminUser) => SubmitValidLoginDetails(new ASEmpSupportConsoleLandingPage(context), dfeAdminUser);

    public void LoginToSupportTool(DfeAdminUser dfeAdminUser) => SubmitValidLoginDetails(new ASEmpSupportToolLandingPage(context), dfeAdminUser);

    public void SubmitValidAsLoginDetails(ASLandingBasePage landingPage) => SubmitValidLoginDetails(landingPage, GetAsAdminUser());

    #endregion

    #region CheckAndLogin

    public void CheckAndLoginToAsAdmin() => CheckAndLoginToAsAdmin(GetAsAdminUser());

    public void CheckAndLoginToAsAdmin(DfeAdminUser dfeAdminUser) => CheckAndLoginTo(new CheckASAdminLandingPage(context), () => new ASAdminLandingPage(context), dfeAdminUser);

    public void CheckAndLoginToSupportTool(DfeAdminUser dfeAdminUser) => CheckAndLoginTo(new CheckASEmpSupportToolLandingPage(context), () => new ASEmpSupportToolLandingPage(context), dfeAdminUser);

    #endregion

    #region CheckAndLoginToASVacancyQa

    public void CheckAndLoginToASVacancyQa()
    {
        if (new CheckASVacancyQaLandingPage(context).IsPageDisplayed()) new ASVacancyQaLandingPage(context).ClickStartNowButton();

        if (new CheckDfeSignInOrReviewHomePage(context).IsDfeSignPageDisplayed()) SubmitValidLoginDetails(context.GetUser<VacancyQaUser>());
    }

    #endregion

    private void CheckAndLoginTo(CheckPageTitleShorterTimeOut checkPage, Func<ASLandingBasePage> landingPage, DfeAdminUser dfeAdminUser)
    {
        if (checkPage.IsPageDisplayed()) landingPage().ClickStartNowButton();

        if (new CheckDfeSignInPage(context).IsPageDisplayed()) SubmitValidLoginDetails(dfeAdminUser);
    }

    private void SubmitValidLoginDetails(ASLandingBasePage landingPage, DfeAdminUser dfeAdminUser)
    {
        landingPage.ClickStartNowButton();

        SubmitValidLoginDetails(dfeAdminUser);
    }

    private void SubmitValidLoginDetails(DfeAdminUser dfeAdminUser) => new DfeSignInPage(context).SubmitValidLoginDetails(dfeAdminUser);

    private AsAdminUser GetAsAdminUser() => context.GetUser<AsAdminUser>();
}