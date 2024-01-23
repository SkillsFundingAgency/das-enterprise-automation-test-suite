using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.DfeSignPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class CheckDfeSignInOrProviderHomePage(ScenarioContext context, string ukprn) : CheckMultipleProviderHomePage(context)
{
    public override string[] PageIdentifierCss => [DfeSignInPage.DfePageIdentifierCss, ProviderHomePage.ProviderHomePageIdentifierCss];

    public override string[] PageTitles => [DfeSignInPage.DfePageTitle, ukprn];

    public bool IsProviderHomePageDisplayed() => ActualDisplayedPage(ukprn);
}
