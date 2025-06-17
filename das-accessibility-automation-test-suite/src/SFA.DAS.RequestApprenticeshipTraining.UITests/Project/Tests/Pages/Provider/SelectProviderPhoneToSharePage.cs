namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Provider;

public class SelectProviderPhoneToSharePage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "Select the telephone number to share";

    #region Locators
    private static By PhoneNumbers => By.CssSelector(".govuk-radios label");
    #endregion

    public CheckYourAnswersPage SelectPhoneNumber()
    {
        var phonenumbers = pageInteractionHelper.FindElements(PhoneNumbers);

        var randomNumber = RandomDataGenerator.GetRandomElementFromListOfElements(phonenumbers);

        formCompletionHelper.ClickElement(randomNumber);

        Continue();

        return new(context);
    }
}
