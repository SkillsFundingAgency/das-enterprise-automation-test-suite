using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers;

public class ProviderHomePageStepsHelper(ScenarioContext context)
{
    private readonly ObjectContext objectContext = context.Get<ObjectContext>();

    private static string Provider_BaseUrl => UrlConfig.Provider_BaseUrl;

    public ProviderHomePage GoToProviderHomePage(bool newTab) => GoToProviderHomePage(context.GetProviderConfig<ProviderConfig>(), newTab);

    public ProviderHomePage GoToProviderHomePage(ProviderLoginUser login, bool newTab)
    {
        var tabHelper = context.Get<TabHelper>();

        if (newTab) tabHelper.OpenNewTab();

        tabHelper.GoToUrl(Provider_BaseUrl);

        objectContext.SetUkprn(login.Ukprn);

        return GoToProviderHomePage(login);
    }

    public ProviderHomePage GoToProviderHomePage(ProviderConfig login, bool newTab)
    {
        var loginUser = new ProviderLoginUser { Username = login.Username, Password = login.Password, Ukprn = login.Ukprn };

        return GoToProviderHomePage(loginUser, newTab);
    }

    private ProviderHomePage GoToProviderHomePage(ProviderLoginUser login)
    {
        var loginHelper = new ProviderPortalLoginHelper(context);

        bool IsProviderHomePageDisplayed() => loginHelper.IsProviderHomePageDisplayed(login.Ukprn);

        if (loginHelper.IsLandingPageDisplayed()) loginHelper.ClickStartNow();

        // provider relogin check
        if (objectContext.GetDebugInformations(Provider_BaseUrl).Count > 1)
        {
            if (IsProviderHomePageDisplayed()) return GoToProviderHomePage();
        }

        if (loginHelper.IsStubSignInPageDisplayed()) loginHelper.SubmitValidLoginDetails(login);

        if (loginHelper.IsSelectYourOrganisationDisplayed()) return loginHelper.SelectOrganisation(login);

        if (IsProviderHomePageDisplayed()) return GoToProviderHomePage();

        return GoToProviderHomePage();
    }

    private ProviderHomePage GoToProviderHomePage() => new (context);
}