namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

public class YourRegionalNetworkPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Your regional network";

    public CreateYourAmbassadorProfilePage ContinueToAmbassadorProfilePage()
    {
        Continue();
        return new CreateYourAmbassadorProfilePage(context);
    }
        
}