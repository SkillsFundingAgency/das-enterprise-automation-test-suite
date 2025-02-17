namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

public class WhyDoYouWantToJoinNetworkPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Why do you want to join the network?";

    private static By ReasonForJoining => By.Id("ReasonForJoiningTheNetwork");

    public ReceiveNotificationsPage EnterInformationToJoinNetwork()
    {
        formCompletionHelper.EnterText(ReasonForJoining, aanDataHelpers.UpdateProviderDescriptionText);
        Continue();
        return new ReceiveNotificationsPage(context);
    }
}