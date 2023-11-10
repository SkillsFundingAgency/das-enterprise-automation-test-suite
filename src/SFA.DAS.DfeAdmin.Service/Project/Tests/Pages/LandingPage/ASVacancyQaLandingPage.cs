namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

public class ASVacancyQaLandingPage : ASLandingBasePage
{
    public static string ASVacancyQaPageTitle => "Apprenticeship service vacancy QA";

    protected override string PageTitle => ASVacancyQaPageTitle;

    public ASVacancyQaLandingPage(ScenarioContext context) : base(context) { }
}
