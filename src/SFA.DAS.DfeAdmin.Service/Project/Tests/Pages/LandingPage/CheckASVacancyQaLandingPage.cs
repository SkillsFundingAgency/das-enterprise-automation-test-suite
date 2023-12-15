namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class CheckASVacancyQaLandingPage(ScenarioContext context) : CheckPageUsingPageTitle(context)
{
    protected override string PageTitle => ASVacancyQaLandingPage.ASVacancyQaPageTitle;

    protected override By Identifier => ASLandingBasePage.ASLandingPageheader;
}