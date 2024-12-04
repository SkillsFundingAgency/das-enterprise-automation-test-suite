namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class YouveLoggedOutPage : RegistrationBasePage
{
    protected override By PageHeader => By.ClassName("govuk-heading-l");
    protected override string PageTitle => "You have signed out";
    protected override bool TakeFullScreenShot => false;
    private static By SigninLink => By.LinkText("sign in");

    #region Locators
    protected override By ContinueButton => By.LinkText("Continue");
    #endregion

    public YouveLoggedOutPage(ScenarioContext context) : base(context) => pageInteractionHelper.Verify(() =>
    {
        var result = IsPageCurrent;

        return result.Item1 ? result.Item1 : throw new Exception(MessageHelper.GetExceptionMessage("Page", PageTitle, result.Item2));

    }, () => pageInteractionHelper.WaitUntilAnyElements(ContinueButton));


    public SignInToYourApprenticeshipServiceAccountPage CickContinueInYouveLoggedOutPage()
    {
        formCompletionHelper.ClickElement(SigninLink);
        return new SignInToYourApprenticeshipServiceAccountPage(context);
    }

}
