namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class YourApprenticeshipInformationPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "Your apprenticeship information";
    private static By AddressLine2 => By.Id("EmployerAddress2");
    private static By ApprenticeShipInformationCheckbox => By.Id("ShowApprenticeshipInformation");
    public YourAmbassadorProfilePage ChangeSeconLineAddressAndContinue()
    {
        formCompletionHelper.EnterText(AddressLine2, RandomDataGenerator.GenerateRandomAlphabeticString(12));
        Continue();
        return new YourAmbassadorProfilePage(context);
    }

    public YourAmbassadorProfilePage HideApprenticeshipInformation()
    {
        formCompletionHelper.UnSelectCheckbox(ApprenticeShipInformationCheckbox);
        Continue();
        return new YourAmbassadorProfilePage(context);
    }
    public YourAmbassadorProfilePage DisplayApprenticeshipInformation()
    {
        formCompletionHelper.SelectCheckbox(ApprenticeShipInformationCheckbox);
        Continue();
        return new YourAmbassadorProfilePage(context);
    }
}
