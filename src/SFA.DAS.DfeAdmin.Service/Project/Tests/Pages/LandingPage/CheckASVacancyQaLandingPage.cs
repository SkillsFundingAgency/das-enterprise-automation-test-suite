using SFA.DAS.UI.Framework.TestSupport.CheckPage;

namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class CheckASVacancyQaLandingPage(ScenarioContext context) : CheckPageTitleShorterTimeOut(context)
{
    protected override string PageTitle => ASVacancyQaLandingPage.ASVacancyQaPageTitle;

    protected override By Identifier => ASLandingBasePage.ASLandingPageheader;
}