namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_SignedOutPage : EPAO_BasePage
{
    protected override string PageTitle => "You have successfully signed out";

    #region Locators
    private static By SignBackInLink => By.XPath("//span[text()='sign back in']");
    #endregion

    public AS_SignedOutPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_LandingPage ClickSignBackInLink()
    {
        formCompletionHelper.Click(SignBackInLink);
        return new(context);
    }
}
