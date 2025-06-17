using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.StubPages;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_SignedOutPage : EPAO_BasePage
{
    protected override string PageTitle => "You have successfully signed out";

    #region Locators
    private static By SignBackInLink => By.CssSelector("a.govuk-button[href='/Dashboard']");
    #endregion

    public AS_SignedOutPage(ScenarioContext context) : base(context) => VerifyPage();

    public StubSignInAssessorPage ClickSignBackInLink()
    {
        formCompletionHelper.Click(SignBackInLink);
        return new(context);
    }
}
