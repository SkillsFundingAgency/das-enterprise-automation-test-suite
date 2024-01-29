using SFA.DAS.UI.Framework.TestSupport.CheckPage;

namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.DfeSignPages;

public class CheckDfeSignInPage(ScenarioContext context) : CheckPageTitleShorterTimeOut(context)
{
    protected override string PageTitle => DfeSignInPage.DfePageTitle;

    protected override By Identifier => DfeSignInPage.DfePageIdentifier;
}
