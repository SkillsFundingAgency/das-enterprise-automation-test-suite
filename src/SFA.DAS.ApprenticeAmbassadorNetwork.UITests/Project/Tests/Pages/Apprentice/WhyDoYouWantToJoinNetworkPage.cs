namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

public class WhyDoYouWantToJoinNetworkPage : AanBasePage
{
    protected override string PageTitle => "Why do you want to join the network?";

    private static By ReasonForJoining => By.Id("ReasonForJoiningTheNetwork");

    public WhyDoYouWantToJoinNetworkPage(ScenarioContext context) : base(context) => VerifyPage();

    public AreasOfInterestPage EnterInformationToJoinNetwork()
    {
        formCompletionHelper.EnterText(ReasonForJoining, aanDataHelpers.UpdateProviderDescriptionText);
        Continue();
        return new AreasOfInterestPage(context);
    }
}



