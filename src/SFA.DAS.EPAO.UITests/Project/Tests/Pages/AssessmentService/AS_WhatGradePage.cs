namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_WhatGradePage : EPAOAssesment_BasePage
{
    protected override string PageTitle => "What grade did the apprentice achieve?";
    protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

    #region Locators
    private static By PassRadioButton => By.Id("Pass");
    private static By FailRadioButton => By.Id("Fail");
    private static By PassWithExcellenceRadioButton => By.Id("Pass_with_excellence");
    #endregion

    public AS_WhatGradePage(ScenarioContext context) : base(context) => VerifyPage();

    public void SelectGradeAndEnterDate(string grade) => SelectGrade(grade).EnterAchievementGradeDateAndContinue();

    public AS_AchievementDatePage SelectGradeAsPass() => SelectGradeAsPass(PassRadioButton);

    private AS_GradeDateBasePage SelectGrade(string grade)
    {
        return grade switch
        {
            "PassWithExcellence" => SelectGradeAsPass(PassWithExcellenceRadioButton),
            "fail" => SelectGradeAsFail(),
            _ => SelectGradeAsPass(),
        };
    }

    private AS_ApprenticeFailedDatePage SelectGradeAsFail()
    {
        SelectGrade(FailRadioButton);
        return new AS_ApprenticeFailedDatePage(context);
    }

    private AS_AchievementDatePage SelectGradeAsPass(By by)
    {
        SelectGrade(by);
        return new AS_AchievementDatePage(context);
    }

    private void SelectGrade(By by)
    {
        formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(by));
        Continue();
    }
}