namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_AssessmentRecordedPage : EPAO_BasePage
{
    protected override string PageTitle => "Assessment recorded";

    #region Locators
    private static By RecordAnotherGradeLink => By.LinkText("Record another grade");
    #endregion

    public AS_AssessmentRecordedPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_RecordAGradePage ClickRecordAnotherGradeLink()
    {
        formCompletionHelper.Click(RecordAnotherGradeLink);
        return new AS_RecordAGradePage(context);
    }
}
