using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers;

public class ProviderHomePageStepsHelper
{
    private readonly ScenarioContext _context;

    public ProviderHomePageStepsHelper(ScenarioContext context) => _context = context;

    public ProviderHomePage GoToProviderHomePage(bool newTab) => GoToProviderHomePage(_context.GetProviderConfig<ProviderConfig>(), newTab);

    public ProviderHomePage GoToProviderHomePage(ProviderLoginUser login, bool newTab)
    {
        var objectContext = _context.Get<ObjectContext>();

        var tabHelper = _context.Get<TabHelper>();

        if (newTab) tabHelper.OpenNewTab();

        tabHelper.GoToUrl(UrlConfig.Provider_BaseUrl);

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
        var loginHelper = new ProviderPortalLoginHelper(_context);

        if (loginHelper.IsIndexPageDisplayed()) loginHelper.StartNow();

        if (loginHelper.IsSignInPageDisplayed()) loginHelper.SubmitValidLoginDetails(login);

        if (loginHelper.IsSelectYourOrganisationDisplayed()) return loginHelper.SelectOrganisation(login);

        if (loginHelper.IsProviderHomePageDisplayed(login.Ukprn)) return new ProviderHomePage(_context);

        return new ProviderHomePage(_context);
    }
}