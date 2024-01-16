using SFA.DAS.UI.Framework.TestSupport.CheckPage;

namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class CheckASEmpSupportToolLandingPage(ScenarioContext context) : CheckPageTitleShorterTimeOut(context)
{
    protected override string PageTitle => ASEmpSupportToolLandingPage.ASEmpSupportToolPageTitle;

    protected override By Identifier => ASLandingBasePage.ASLandingPageheader;
}