namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class ContactDetailsPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Contact details"; 
    private static By LinkedlnUrlField => By.Id("LinkedinUrl");
    private static By LinkedlnInformationCheckbox = By.Id("ShowLinkedinUrl");

    public YourAmbassadorProfilePage ChangeLinkedlnUrlAndContinue()
    {
        formCompletionHelper.EnterText(LinkedlnUrlField, RandomDataGenerator.GenerateRandomAlphabeticString(12));
        Continue();
        return new YourAmbassadorProfilePage(context);
    }
    public YourAmbassadorProfilePage HideLinkedlnInformation()
    {
        formCompletionHelper.UnSelectCheckbox(LinkedlnInformationCheckbox);
        Continue();
        return new YourAmbassadorProfilePage(context);
    }
    public YourAmbassadorProfilePage DisplayLinkedlnInformation()
    {
        formCompletionHelper.SelectCheckbox(LinkedlnInformationCheckbox);
        Continue();
        return new YourAmbassadorProfilePage(context);
    }
}
