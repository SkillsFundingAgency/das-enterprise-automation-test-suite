namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class SignAgreementPage : RegistrationBasePage
{
    protected override string PageTitle => objectContext.GetOrganisationName();

    protected override string AccessibilityPageTitle => "Sign an agreement page";

    protected override bool TakeFullScreenShot => false;

    #region Locators
    private static By WantToSignRadioButton => By.CssSelector("label[for=want-to-sign]");
    private static By DoNotWantToSignRadioButton => By.CssSelector("label[for=do-not-want-to-sign]");
    private static By ContinueToYourAgreementButton => By.LinkText("Continue to your agreement");
    protected override By ContinueButton => By.CssSelector("input.govuk-button, input.button");
    #endregion

    public SignAgreementPage(ScenarioContext context) : base(context) => VerifyPage(WantToSignRadioButton);

    public YouHaveAcceptedTheEmployerAgreementPage SignAgreement()
    {
        formCompletionHelper.ClickElement(WantToSignRadioButton);

        formCompletionHelper.ClickElement(ContinueButton);

        return new YouHaveAcceptedTheEmployerAgreementPage(context);
    }
}