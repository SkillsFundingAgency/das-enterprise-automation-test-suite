using SFA.DAS.UI.Framework.TestSupport.CheckPage;

namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class CheckASEmpSupportConsoleLandingPage(ScenarioContext context) : CheckPageTitleShorterTimeOut(context)
{
    protected override string PageTitle => ASEmpSupportConsoleLandingPage.ASEmpSupportConsolePageTitle;

    protected override By Identifier => ASLandingBasePage.ASLandingPageheader;
}
