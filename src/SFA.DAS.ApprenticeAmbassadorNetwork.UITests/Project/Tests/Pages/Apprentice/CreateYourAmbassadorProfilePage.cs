namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

public class CreateYourAmbassadorProfilePage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Create your ambassador profile";

    public SearchEmployerNamePage ContinueToSearchEmployerNamePage()
    {
        Continue();
        return new SearchEmployerNamePage(context);
    }
}