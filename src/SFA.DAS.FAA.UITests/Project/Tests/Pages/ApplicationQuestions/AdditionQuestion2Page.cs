namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.ApplicationQuestions;

public class AdditionQuestion2Page(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => advertDataHelper.AdditionalQuestion2;
    protected override By PageHeader => By.CssSelector("label[for='AdditionalQuestionAnswer']");

    private static By AdditionalQuestionAnswer => By.CssSelector("#AdditionalQuestionAnswer");

    public FAA_ApplicationOverviewPage SelectYesAndCompleteSection()
    {
        formCompletionHelper.EnterText(AdditionalQuestionAnswer, faaDataHelper.AdditionalQuestions2Answer);

        SelectRadioOptionByForAttribute("IsSectionCompleted");

        Continue();

        return new(context);
    }
}