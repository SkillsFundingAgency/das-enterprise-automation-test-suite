namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

public class ReceiveNotificationsPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Do you want to get a monthly email about upcoming events?";

    public EngagedWithAmbassadorPage SelectNoAndContinue()
    {
        formCompletionHelper.SelectRadioOptionByText("No");
        Continue();
        return new EngagedWithAmbassadorPage(context);
    }
}