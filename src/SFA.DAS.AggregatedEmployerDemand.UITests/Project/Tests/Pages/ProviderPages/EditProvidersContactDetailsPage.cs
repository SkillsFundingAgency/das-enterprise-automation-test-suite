namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages;

public class EditProvidersContactDetailsPage : AedBasePage
{
    protected override string PageTitle => "Edit";

    protected override bool TakeFullScreenShot => false;

    public EditProvidersContactDetailsPage(ScenarioContext context) : base(context)  { }

    #region Locators
    private static By EmailAddressTextBox => By.CssSelector("#EmailAddress");
    private static By TelephoneNumberTextBox => By.CssSelector("#PhoneNumber");
    private static By WebsiteTextBox => By.CssSelector("#Website");
    #endregion

    private EditProvidersContactDetailsPage EnterProvidersContactDetails(string email, string telephone, string website)
    {
        formCompletionHelper.EnterText(EmailAddressTextBox, email);
        formCompletionHelper.EnterText(TelephoneNumberTextBox, telephone);
        formCompletionHelper.EnterText(WebsiteTextBox, website);
        return this;
    }

    public EditProvidersContactDetailsPage DoNotEnterDetails() => StayOnEditProvidersContactDetailsPage();

    public EditProvidersContactDetailsPage EnterInvalidDetails()
    {
        EnterProvidersContactDetails($"{dataHelper.Email}@gmail.com", $"{dataHelper.TelephoneNumber}ABC", dataHelper.RandomWebsiteAddress);
        return StayOnEditProvidersContactDetailsPage();
    }

    public ConfirmProvidersContactDetailsPage EnterValidDetails()
    {
        EnterProvidersContactDetails(dataHelper.Email, dataHelper.TelephoneNumber, dataHelper.RandomWebsiteAddress);
        Continue();
        return new ConfirmProvidersContactDetailsPage(context);
    }

    public WhichEmployersAreYouInterestedInPage BackToWhichEmployersAreYouInterestedInPage()
    {
        formCompletionHelper.Click(BackLink);
        return new WhichEmployersAreYouInterestedInPage(context);
    }

    private EditProvidersContactDetailsPage StayOnEditProvidersContactDetailsPage()
    {
        Continue();
        return new EditProvidersContactDetailsPage(context);
    }
}
