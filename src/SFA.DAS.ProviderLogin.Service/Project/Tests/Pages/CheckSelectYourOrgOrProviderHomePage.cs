using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class CheckSelectYourOrgOrProviderHomePage(ScenarioContext context, string ukprn) : CheckMultipleHomePage(context)
{
    public override string[] PageIdentifierCss => [SelectYourOrganisationPage.SyoPageIdentifierCss, ProviderHomePage.ProviderHomePageIdentifierCss];

    public override string[] PageTitles => [SelectYourOrganisationPage.SyoPageTitle, ukprn];

    public bool IsSelectYourOrganisationDisplayed() => ActualDisplayedPage(SelectYourOrganisationPage.SyoPageTitle);
}
