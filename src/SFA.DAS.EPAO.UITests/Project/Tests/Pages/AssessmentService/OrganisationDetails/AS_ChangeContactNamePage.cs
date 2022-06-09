namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails;

public class AS_ChangeContactNamePage : EPAO_BasePage
{
    protected override string PageTitle => "Change contact name";

    #region Locators
    private static By PrimaryContactNameRadioButton => By.XPath("//label[contains(text(),'Mr Preprod Epao0007')]/../input");
    private static By SecondaryContactNameRadioButton => By.XPath("//label[contains(text(),'Liz Kemp')]/../input");
    #endregion

    public AS_ChangeContactNamePage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_ConfirmContactNamePage SelectContactNameRadioButtonAndClickSave()
    {
        var radioButtonToClick = pageInteractionHelper.GetElementSelectedStatus(PrimaryContactNameRadioButton) ? SecondaryContactNameRadioButton : PrimaryContactNameRadioButton;
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(radioButtonToClick));

        Continue();
        return new(context);
    }
}

public class AS_ConfirmContactNamePage : EPAO_BasePage
{
    protected override string PageTitle => "Confirm contact name";

    public AS_ConfirmContactNamePage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_ContactNameUpdatedPage ClickConfirmButtonInConfirmContactNamePage()
    {
        Continue();
        return new(context);
    }
}

public class AS_ContactNameUpdatedPage : AS_ChangeOrgDetailsBasePage
{
    protected override string PageTitle => "Contact name updated";

    public AS_ContactNameUpdatedPage(ScenarioContext context) : base(context) => VerifyPage();
}
