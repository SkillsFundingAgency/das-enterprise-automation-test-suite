namespace SFA.DAS.FAAV2.UITests.Project.Pages.ApplicationQuestions;

public class AdditionQuestion2Page(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => advertDataHelper.AdditionalQuestion2;

    private static By AdditionalQuestionAnswer => By.CssSelector("#AdditionalQuestionAnswer");

    public FAA_ApplicationOverviewPage SelectYesAndCompleteSection()
    {
        formCompletionHelper.EnterText(AdditionalQuestionAnswer, faaDataHelper.AdditionalQuestions2Answer);

        SelectRadioOptionByForAttribute("IsSectionCompleted");

        Continue();

        return new(context);
    }
}